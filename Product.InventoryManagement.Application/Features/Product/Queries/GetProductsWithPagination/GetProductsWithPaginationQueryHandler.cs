using AutoMapper;
using MediatR;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetProductsWithPagination
{
    public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginationResult<Domain.Entities.Product>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductsWithPaginationQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        async Task<PaginationResult<Domain.Entities.Product>> IRequestHandler<GetProductsWithPaginationQuery, PaginationResult<Domain.Entities.Product>>.Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.PaginationResultAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
    }
}
