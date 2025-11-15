using ConnectA.Domain.Entities;

namespace ConnectA.Tests.Builders;

public static class ProfileBuilder
{
    public static Profile CreateValidProfile()
    {
        return new Profile(
            "Test Bio",
            "Programação, Engenheiro de Software, Git",
            "Experiências de Trabalho",
            "Conseguir vaga em tecnologia",
            "SP",
            "en,pt"
        );
    }
    
}