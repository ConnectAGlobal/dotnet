using ConnectA.Domain.Entities;

namespace ConnectA.Tests.Builders;

public static class UserBuilder
{
    public static User CreateValidSenior(Profile profile)
    {
        return new User(
            "Senior Tester", 
            $"senior{Guid.NewGuid()}@gmail.com", 
            "123456789", 
            "Senior", 
            profile);
    }

    public static User CreateValidJovem(Profile profile)
    {
        return new User(
            "Jovem Tester",
            $"jovem{Guid.NewGuid()}@mail.com",
            "ValidPass123@",
            "Jovem",
            profile
        );
    }
    
}