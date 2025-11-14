namespace ConnectA.Domain.Helper;

public static class TransformInEnum
{
    public static T ParseEnum<T>(string value) where T : struct, Enum
    {
        try
        {
            return Enum.Parse<T>(value, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}