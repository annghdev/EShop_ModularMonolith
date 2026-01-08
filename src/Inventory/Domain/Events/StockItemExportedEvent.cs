namespace Inventory.Domain;

public record StockItemExportedEvent(
    Guid ItemId,
    string Name,
    string Sku,
    int ReserveQuantity,
    int Quantity) : DomainEvent;