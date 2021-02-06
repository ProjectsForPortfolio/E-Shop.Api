using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Persistence.Models;
using MongoDB.Driver;

namespace E_Shop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductEntity> collection;
        public ProductRepository(IMongoDatabase mongoDb)
        {
            collection = mongoDb.GetCollection<ProductEntity>("Products");
        }

        public async Task<IEnumerable<ProductEntity>> Get()
        {
            return (await collection.FindAsync(item => true)).ToList();
        }

        public async Task<ProductEntity> Get(string id)
        {
            return (await collection.FindAsync(item => item.Id == id)).FirstOrDefault();
        }

        public async Task<ProductEntity> Create(ProductEntity item)
        {
            await collection.InsertOneAsync(item);
            return item;
        }

        public async Task Update(string id, ProductEntity item)
        {
            await collection.ReplaceOneAsync(record => record.Id == id, item);
        }

        public async Task Remove(ProductEntity item) =>
             await Remove(item.Id);

        public async Task Remove(string id) =>
            await collection.DeleteOneAsync(record => record.Id == id);
    }
}
