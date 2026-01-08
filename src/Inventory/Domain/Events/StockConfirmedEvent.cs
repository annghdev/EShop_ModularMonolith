namespace Inventory.Domain;

public record StockConfirmedEvent(
    Guid StockItemId,
    Guid OrderId,
    int ConfirmedQuantity,
    int RemainingQuantity) : DomainEvent;
