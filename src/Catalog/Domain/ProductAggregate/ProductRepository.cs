namespace Catalog.Domain;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(Guid id);
    Task<Product?> FindAsync(Guid id);
    Task<bool> CheckExistsAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
}
