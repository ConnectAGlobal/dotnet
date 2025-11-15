namespace ConnectA.Domain.Exceptions;

public class InvalidSeniorRoleException(Guid seniorId) : Exception($"The user with ID {seniorId} is not a SENIOR.");