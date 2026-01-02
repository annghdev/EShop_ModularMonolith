namespace Catalog.Domain;

public class Category : AggregateRoot
{
    public required string Name { get; set; }
    public string? Image { get; set; }
    public ICollection<Category> Children { get; set; } = [];
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<CategoryDefaultAttribute> DefaultAttributes { get; set; } = [];
}

public class CategoryDefaultAttribute : BaseEntity
{
    public Guid AttributeId { get; set; }
    public Attribute? Attribute { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public int DisplayOrder { get; set; }
}