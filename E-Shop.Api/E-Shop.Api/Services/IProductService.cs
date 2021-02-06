using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Api.Domain.Models;

namespace E_Shop.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string id);
        Task<string> Create(Product product);
        Task Update(string id, Product product);
        Task Delete(string id);
    }
}