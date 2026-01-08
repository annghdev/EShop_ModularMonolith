namespace Inventory.Domain;

public record StockReservationFailedEvent(
    Guid StockItemId,
    Guid OrderId,
    int RequestedQuantity,
    int AvailableQuantity,
    string Reason) : DomainEvent;
