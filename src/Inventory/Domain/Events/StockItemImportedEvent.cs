namespace Inventory.Domain;

public record StockItemImportedEvent(
    Guid ItemId, 
    string Name, 
    string Sku, 
    int ImportQuantity, 
    int Quantity) : DomainEvent;