namespace ConnectA.Domain.Helper;

public class TransformInEnum
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