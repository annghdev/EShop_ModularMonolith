namespace Payment.Domain;

public record PaymentGatewayDisabledEvent(
    Guid GatewayId,
    string Name,
    PaymentProvider Provider) : DomainEvent;
