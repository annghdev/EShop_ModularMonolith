namespace Payment.Domain;

public record PaymentGatewayEnabledEvent(
    Guid GatewayId,
    string Name,
    PaymentProvider Provider) : DomainEvent;
