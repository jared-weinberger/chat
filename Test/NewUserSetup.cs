using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

namespace Test;

public class NewUserSetup : IDisposable
{
    private readonly PostgresContainer container;
    public NewUserSetup()
    {
        container = new PostgresContainer("podman", "foobar", 5432, "16");
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        container.Dispose();
    }

    [Fact]
    public void ItStoresNewUsers()
    {
        var storage = new Data.StorageContext($"Host=localhost;User={container.User};Password={container.Password}");
        var setup = new Core.NewUserSetup(storage.Users);
        var newUser = new Core.NewUser { Handle = "palpy", Password = "order66LOL" };
        setup.SetupNewUser(newUser);
        var storedUser = storage.Users.Find(new Data.User { Handle = "palpy" });
        Assert.NotNull(storedUser);
    }
}

class PostgresContainer : IDisposable

{
    public string Engine { get; }
    public string Id { get; }
    public string User { get; } = "postgres";
    public string Password { get; }
    public int Port { get; }
    public string Version { get; }

    public PostgresContainer(string engine, string password, int port, string version)
    {
        Engine = engine;
        Password = password;
        Port = port;
        Version = version;
        Id = start();

    }
    private string start()
    {
        var proc = new Process();
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.FileName = Engine;
        proc.StartInfo.Arguments = $"""run --rm -e POSTGRES_PASSWORD="{Password}" -p 5432:{Port} -d docker.io/postgres:{Version}""";
        proc.Start();
        proc.WaitForExit();

        if (proc.ExitCode != 0)
        {
            throw new Exception($"Couldn't start postgres container: {proc.StandardError.ReadToEnd()}");
        }
        var output = proc.StandardOutput.ReadToEnd();
        return output.Trim();
    }
    public void Dispose()
    {
        var proc = Process.Start(Engine, $"stop {Id}");
        proc.WaitForExit();
        if (proc.ExitCode != 0)
        {
            throw new Exception("Couldn't stop postgres container");
        }
    }
}