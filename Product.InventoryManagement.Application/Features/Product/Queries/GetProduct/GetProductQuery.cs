using MediatR;
using Product.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetProduct
{
    public record GetProductQuery(Guid id) : IRequest<ProductItem>
    {
    }
}
