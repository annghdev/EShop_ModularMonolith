namespace Payment.Domain;

public record RefundCompletedEvent(
    Guid RefundId,
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    Money RefundAmount) : DomainEvent;
