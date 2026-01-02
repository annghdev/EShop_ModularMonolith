namespace Catalog.Domain;

public class Attribute : AggregateRoot
{
    public required string Name { get; set; }
    public string? Icon { get; set; }
    public string? ValueStyleCss { get; set; }
    public bool DisplayText { get; set; }
    public ICollection<AttributeValue> Values { get; set; } = [];
}
