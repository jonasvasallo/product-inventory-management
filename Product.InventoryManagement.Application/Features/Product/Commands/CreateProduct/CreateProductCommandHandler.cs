using AutoMapper;
using MediatR;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Product", validationResult);
            }

            var productToBeCreated = _mapper.Map<Domain.Entities.Product>(request);

            await _productRepository.CreateAsync(productToBeCreated);
            return productToBeCreated.Id;
        }
    }
}
