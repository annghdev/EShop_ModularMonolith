namespace Inventory.Domain;

public record StockReleasedEvent(
    Guid StockItemId,
    Guid OrderId,
    int ReleasedQuantity,
    int AvailableQuantity) : DomainEvent;
