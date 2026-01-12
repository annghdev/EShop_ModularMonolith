namespace Payment.Domain;

public record PaymentCancelledEvent(
    Guid TransactionId,
    string TransactionNumber,
    Guid OrderId,
    string Reason) : DomainEvent;
