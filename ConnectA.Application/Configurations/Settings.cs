namespace ConnectA.Application.Configurations;

public class Settings
{
    public required ConnectionSettings ConnectionStrings { get; set;  }
    public required SwaggerSettings Swagger { get; set; }
}