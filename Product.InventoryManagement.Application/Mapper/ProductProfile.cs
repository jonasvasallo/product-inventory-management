using AutoMapper;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.Application.Features.Product.Commands.CreateProduct;
using Product.InventoryManagement.Application.Features.Product.Commands.UpdateProduct;
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
            CreateMap<CreateProductCommand, ProductItem>();
            CreateMap<UpdateProductCommand, ProductItem>();
            CreateMap<UpdateProductCommand, ProductDto>();
        }
    }
}
