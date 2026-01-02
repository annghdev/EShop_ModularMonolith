namespace Catalog.Domain.Products.Events;

public record VariantAddedEvent(Variant Payload) : DomainEvent;
public record VariantRemovedEvent(Variant Payload) : DomainEvent;