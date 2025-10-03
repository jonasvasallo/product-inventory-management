using FluentValidation;
using Product.InventoryManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.InventoryTransaction.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        private readonly IProductRepository _productRepository;
        public CreateTransactionCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(entity => entity)
                .MustAsync(ProductExists).WithMessage("{PropertyName} does not exist");

            RuleFor(entity => entity.UnitsAdded)
                .LessThanOrEqualTo(999).WithMessage("{PropertyName} must not exceed 999 units")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cannot be less than 0");
                
            RuleFor(entity => entity.UnitsRemoved)
                .LessThanOrEqualTo(999).WithMessage("{PropertyName} must not exceed 999 units")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cannot be less than 0");
            RuleFor(entity => entity.Reason)
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters");

        }

        private async Task<bool> ProductExists(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            return product != null;
        }
    }
}
