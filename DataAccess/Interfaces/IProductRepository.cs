using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}
