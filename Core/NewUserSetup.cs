using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class NewUserSetup(DbSet<Data.User> storedUsers)
{
    private readonly DbSet<Data.User> storedUsers = storedUsers;

    public Result<Data.User> SetupNewUser(NewUser user) {
        return Result.Fail("Oof");
    }

}
