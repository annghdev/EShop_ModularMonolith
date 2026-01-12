namespace Payment.Domain;

public record PaymentGatewayConfigurationUpdatedEvent(
    Guid GatewayId,
    string Name) : DomainEvent;
