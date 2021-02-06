using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using E_Shop.Api.Domain.Models;
using E_Shop.Api.Repositories;
using E_Shop.Persistence.Models;

namespace E_Shop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        public ProductService(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return mapper.Map<IEnumerable<Product>>(await repository.Get());
        }

        public async Task<Product> Get(string id)
        {
            return mapper.Map<Product>(await repository.Get(id));
        }

        public async Task<string> Create(Product product)
        {
            var result = await repository.Create(mapper.Map<ProductEntity>(product));
            return result.Id;
        }

        public async Task Update(string id, Product product)
        {
            await repository.Update(id, mapper.Map<ProductEntity>(product));
        }

        public async Task Delete(string id)
        {
            await repository.Remove(id);
        }
    }
}
