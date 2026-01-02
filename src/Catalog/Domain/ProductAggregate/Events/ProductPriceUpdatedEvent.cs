namespace Catalog.Domain.Products.Events;

public record ProductPriceUpdatedEvent(Guid ProductId, decimal Cost, decimal Price) : DomainEvent;
