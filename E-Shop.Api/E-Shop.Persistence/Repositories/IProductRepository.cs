using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Persistence.Models;

namespace E_Shop.Api.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> Create(ProductEntity item);
        Task<IEnumerable<ProductEntity>> Get();
        Task<ProductEntity> Get(string id);
        Task Remove(ProductEntity item);
        Task Remove(string id);
        Task Update(string id, ProductEntity item);
    }
}