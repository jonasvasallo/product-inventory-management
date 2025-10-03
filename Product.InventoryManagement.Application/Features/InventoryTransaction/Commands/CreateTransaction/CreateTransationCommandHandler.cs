using AutoMapper;
using MediatR;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction = Product.InventoryManagement.Domain.Entities.InventoryTransaction;

namespace Product.InventoryManagement.Application.Features.InventoryTransaction.Commands.CreateTransaction
{
    public class CreateTransationCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateTransationCommandHandler(ITransactionRepository transactionRepository, IProductRepository productRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransactionCommandValidator(_productRepository);
            var validationResults = await validator.ValidateAsync(request, cancellationToken);
            if(validationResults.Errors.Any())
            {
                throw new BadRequestException("Invalid Inventory Transaction",validationResults);
            }

            var transactionToBeCreated = _mapper.Map<Transaction>(request);
            await _transactionRepository.CreateAsync(transactionToBeCreated);
            return transactionToBeCreated.Id;
        }
    }
}
