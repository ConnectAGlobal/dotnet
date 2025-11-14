namespace ConnectA.Domain.Exceptions;

public class ProfileAlreadyExistsException(Guid userId) : Exception($"User '{userId}' already has a profile.");