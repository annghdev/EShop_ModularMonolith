namespace Payment.Domain;

public record PaymentInitiatedEvent(
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    string OrderNumber,
    Money Amount,
    PaymentProvider Provider,
    Guid CustomerId) : DomainEvent;
