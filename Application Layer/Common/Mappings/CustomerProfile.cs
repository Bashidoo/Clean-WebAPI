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
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ForMember(obj => obj.Id, opt => opt.Ignore()); // DTO → Entity ignore to not override ID
            CreateMap<Customer, CustomerDto>(); // Entity → DTO (if needed)
        }
    }
}
