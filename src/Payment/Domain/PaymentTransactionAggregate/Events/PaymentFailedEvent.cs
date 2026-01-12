namespace Payment.Domain;

public record PaymentFailedEvent(
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    string OrderNumber,
    Money Amount,
    PaymentProvider Provider,
    string? ResponseCode,
    string? ResponseMessage) : DomainEvent;
