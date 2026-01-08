namespace Inventory.Domain;

public class StockLog : BaseEntity
{
    public Guid StockItemId { get; set; }
    public StockItem? StockItem { get; set; }
    public Guid? OrderId { get; set; } // Nullable for backward compatibility with manual import/export
    public int Quantity { get; set; }
    public int SnapshotTotalQuantity { get; set; }
    public StockTransactionType Type { get; set; } = StockTransactionType.Import;
}

public enum StockTransactionType
{
    Import,
    Export,
    Reserve,
    Release,
    Confirm
}