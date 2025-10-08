using FluentValidation;
using Product.InventoryManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(product => product.Id)
                .MustAsync(ProductMustExist).WithMessage("Product must exist");
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
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
            //RuleFor(product => product)
            //    .MustAsync(ProductNameUnique).WithMessage("Product name must be unique!");
        }

        private async Task<bool> ProductMustExist(int id, CancellationToken token)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) {
                return false;
            }
            return true;
        }

        private async Task<bool> ProductNameUnique(UpdateProductCommand command, CancellationToken token)
        {
            return await _productRepository.ProductUnique(command.Name);
        }
    }
}
