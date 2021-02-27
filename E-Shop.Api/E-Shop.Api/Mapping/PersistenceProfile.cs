using AutoMapper;
using E_Shop.Domain.Models;
using E_Shop.Persistence.Models;

namespace E_Shop.Api.Mapping
{
    public class PersistenceProfile : Profile
    {
        public PersistenceProfile()
        {
            CreateMap<ProductEntity, Product>()
                .ReverseMap();
        }
    }
}
