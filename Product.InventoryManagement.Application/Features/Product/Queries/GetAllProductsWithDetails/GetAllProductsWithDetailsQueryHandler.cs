using AutoMapper;
using MediatR;
using Product.InventoryManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetAllProductsWithDetails
{
    public class GetAllProductsWithDetailsQueryHandler : IRequestHandler<GetAllProductsWithDetailsQuery, List<Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsWithDetailsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<Domain.Entities.Product>> Handle(GetAllProductsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetBySpAsync();
            var data = _mapper.Map<List<Domain.Entities.Product>>(products);
            return data;
        }
    }
}
