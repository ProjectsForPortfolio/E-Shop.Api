﻿using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Api.Models;

namespace E_Shop.Api.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Create(Product item);
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string id);
        Task Remove(Product item);
        Task Remove(string id);
        Task Update(string id, Product item);
    }
}