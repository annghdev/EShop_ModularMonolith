namespace Payment.Domain;

public record PaymentCompletedEvent(
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    string OrderNumber,
    Money Amount,
    PaymentProvider Provider,
    Guid CustomerId,
    string? ExternalTransactionId) : DomainEvent;
