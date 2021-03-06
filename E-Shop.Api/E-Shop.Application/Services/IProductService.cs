﻿using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Domain.Models;

namespace E_Shop.Application.Services
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