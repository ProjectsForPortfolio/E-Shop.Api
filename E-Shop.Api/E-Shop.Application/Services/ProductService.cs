using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Domain.Models;
using E_Shop.Repositories;

namespace E_Shop.Application.Services
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

        public async Task<string> Create(Product product)
        {
            var result = await repository.Create(product);
            return result.Id;
        }

        public async Task Update(string id, Product product)
        {
            await repository.Update(id, product);
        }

        public async Task Delete(string id)
        {
            await repository.Remove(id);
        }
    }
}
