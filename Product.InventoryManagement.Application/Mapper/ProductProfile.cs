using AutoMapper;
using Product.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile() { 
            CreateMap<ProductDto, ProductItem>().ReverseMap();
        }
    }
}
