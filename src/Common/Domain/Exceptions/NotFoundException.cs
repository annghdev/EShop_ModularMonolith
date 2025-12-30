namespace Common;

public class NotFoundException(string entityType, object id)
    : DomainException($"{entityType} not found with ID: {id}", 404);
