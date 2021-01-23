using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Api.Models;
using E_Shop.Api.Repositories;

namespace E_Shop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await repository.Get();
        }

        public async Task<Product> Get(string id)
        {
            return await repository.Get(id);
        }
        public async Task Create(Product product)
        {
            await repository.Create(product);
        }

        public async Task Update(string id,Product product)
        {
            await repository.Update(id,product);
        }

        public async Task Delete(string id)
        {
            await repository.Remove(id);
        }
    }
}
