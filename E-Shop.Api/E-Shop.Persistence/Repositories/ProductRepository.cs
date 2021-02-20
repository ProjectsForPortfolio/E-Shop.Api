using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using E_Shop.Domain.Models;
using E_Shop.Persistence.Models;
using MongoDB.Driver;

namespace E_Shop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductEntity> collection;
        private readonly IMapper mapper;
        public ProductRepository(IMongoDatabase mongoDb, IMapper mapper)
        {
            collection = mongoDb.GetCollection<ProductEntity>("Products");
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return mapper.Map<IEnumerable<Product>>(
                (await collection.FindAsync(item => true)).ToList());
        }

        public async Task<Product> Get(string id)
        {
            return mapper.Map<Product>(
                (await collection.FindAsync(item => item.Id == id)).FirstOrDefault());
        }

        public async Task<Product> Create(Product item)
        {
            await collection.InsertOneAsync(mapper.Map<ProductEntity>(item));
            return item;
        }

        public async Task Update(string id, Product item)
        {
            await collection.ReplaceOneAsync(record => record.Id == id, mapper.Map<ProductEntity>(item));
        }

        public async Task Remove(Product item) =>
             await Remove(item.Id);

        public async Task Remove(string id) =>
            await collection.DeleteOneAsync(record => record.Id == id);
    }
}
