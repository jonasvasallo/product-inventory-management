using FluentValidation;
using Product.InventoryManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");
            RuleFor(product => product.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                .LessThan(999).WithMessage("{PropertyName} must not exceed 999");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                .LessThan(999999999).WithMessage("{PropertyName} must not exceed 999 million");
            RuleFor(product => product)
                .MustAsync(ProductNotExisting).WithMessage("Product already exists");
        }

        public async Task<bool> ProductNotExisting(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return await _productRepository.ProductUnique(command.Name);
        }
    }
}
