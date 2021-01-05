using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using E_Shop.Domain;
using MediatR;

namespace e_Shop.Application
{
    public class ProductQuery: IRequest<List<Product>>
    {
        
    }

    public class ProductQueryHandler : IRequestHandler<ProductQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return new List<Product> {new Product {Id = 1}};
        }
    }

}