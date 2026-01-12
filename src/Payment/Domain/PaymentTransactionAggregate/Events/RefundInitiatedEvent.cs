namespace Payment.Domain;

public record RefundInitiatedEvent(
    Guid RefundId,
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    Money RefundAmount,
    string Reason,
    Guid? RefundedBy) : DomainEvent;
