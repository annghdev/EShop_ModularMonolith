namespace Inventory.Domain;

public class StockReservation : BaseEntity
{
    public Guid OrderId { get; private set; }
    public int Quantity { get; private set; }
    public Guid StockItemId { get; private set; }
    public StockItem? StockItem { get; private set; }

    private StockReservation() { } // EF Core

    public StockReservation(Guid orderId, int quantity, Guid stockItemId)
    {
        if (orderId == Guid.Empty)
            throw new DomainException("Order ID cannot be empty");

        if (quantity <= 0)
            throw new DomainException("Reservation quantity must be greater than 0");

        OrderId = orderId;
        Quantity = quantity;
        StockItemId = stockItemId;
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new DomainException("Reservation quantity must be greater than 0");

        Quantity = newQuantity;
    }
}
