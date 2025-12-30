namespace Product.Domain;

public class Variant : AuditableEntity
{
    public required string Sku { get; set; }
    public decimal OverrideCost { get; set; }
    public decimal OverridePrice { get; set; }
    public string? MainImage { get; set; }
    public List<string> Images { get; set; } = [];
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public List<VariantAttributeValue> AttributeValues { get; set; } = [];
}
