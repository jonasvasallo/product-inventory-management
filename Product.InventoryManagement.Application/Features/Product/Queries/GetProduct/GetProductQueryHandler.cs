using MediatR;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductItem>
    {
        private readonly IProductRepository _productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<ProductItem> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(request.id);

            if(product == null)
            {
                throw new NotFoundException(nameof(product));
            }



            return product;
        }
    }
}
