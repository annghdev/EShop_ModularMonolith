namespace Inventory.Domain;

public record StockLogCreatedEvent(
    Guid StockItemId,
    Guid? OrderId,
    int Quantity,
    int SnapshotTotalQuantity,
    StockTransactionType Type) : DomainEvent;
