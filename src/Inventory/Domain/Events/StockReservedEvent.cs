namespace Inventory.Domain;

public record StockReservedEvent(
    Guid StockItemId,
    Guid OrderId,
    int ReservedQuantity,
    int AvailableQuantity) : DomainEvent;
