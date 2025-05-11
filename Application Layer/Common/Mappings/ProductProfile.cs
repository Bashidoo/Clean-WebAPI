using Application_Layer.Dtos;
using AutoMapper;
using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Common.Mappings
{
    
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Domain → DTO
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            // 'Id' and 'CreatedAt' are ignored in the DTO by default since they don't exist in ProductDto

            // DTO → Domain (for creating/updating products)
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                // AutoMapper will ignore 'Id' and 'CreatedAt' unless explicitly set
                .AfterMap((src, dest) =>
                {
                    // If Id is 0 (unset), assume this is a new product (optional)
                    if (dest.Id == 0)
                        dest.Id = new Random().Next(1000, 9999); // Replace with your ID generation logic
                });
        }
    }
}
