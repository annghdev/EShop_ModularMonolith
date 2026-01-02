namespace Catalog.Domain.Products.Events;

public record ProductThumbnailUpdatedEvent(Guid ProductId, string ImageUrl) : DomainEvent;
