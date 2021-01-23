using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Api.Models;
using MongoDB.Driver;

namespace E_Shop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> collection;
        public ProductRepository(IMongoDatabase mongoDb)
        {
            collection = mongoDb.GetCollection<Product>("Products");
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return (await collection.FindAsync(item => true)).ToList();
        }

        public async Task<Product> Get(string id)
        {
            return (await collection.FindAsync(item => item.Id == id)).FirstOrDefault();
        }

        public async Task<Product> Create(Product item)
        {
            await collection.InsertOneAsync(item);
            return item;
        }

        public async Task Update(string id, Product item)
        {
            await collection.ReplaceOneAsync(record => record.Id == id, item);
        }

        public async Task Remove(Product item) =>
             await Remove(item.Id);

        public async Task Remove(string id) =>
            await collection.DeleteOneAsync(record => record.Id == id);
    }
}
