namespace Product.Domain;

public class Product : AggregateRoot
{
    public required string Name { get; set; }

    public required string Sku { get; set; }

    public required Money Cost { get; set; }

    public required Money Price { get; set; }

    public string? MainImage { get; set; }
    public List<string> Images { get; set; } = [];

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public Guid BrandId { get; set; }
    public Brand? Brand { get; set; }

    public List<ProductAttribute> Attributes { get; set; } = [];

    public List<Variant> Variants { get; set; } = [];
}
