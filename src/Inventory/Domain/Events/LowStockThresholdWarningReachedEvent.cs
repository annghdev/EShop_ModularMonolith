namespace Inventory.Domain;

public record LowStockThresholdWarningReachedEvent(
    Guid StockItemId,
    string Name,
    string Sku,
    int Quantity) : DomainEvent;
