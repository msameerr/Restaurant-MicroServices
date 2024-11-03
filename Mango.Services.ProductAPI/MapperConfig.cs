using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mapperConfiguration = new MapperConfiguration(config => {
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });

            return mapperConfiguration;
        }
    }
}
