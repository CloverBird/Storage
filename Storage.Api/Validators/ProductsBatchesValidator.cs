using FluentValidation;
using Storage.Api.Models;

namespace Storage.Api.Validators
{
    public class ProductsBatchesValidator : AbstractValidator<ProductsBatch>
    {
        public ProductsBatchesValidator() {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                .MaximumLength(30).WithMessage("Name cannot exceed 30 characters");

             RuleFor(p => p.ProductDescription)
                .MinimumLength(5).WithMessage("Description must be at least 5 characters")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
                .When(p => !string.IsNullOrWhiteSpace(p.ProductDescription));

            RuleFor(p => p.ProductPrice)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(p => p.ProducingDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("The produced date can't be in the future");

            RuleFor(p => p.ExpirationDate)
                .GreaterThanOrEqualTo(p => p.ProducingDate)
                .WithMessage("Produced date must be before or equal to expiration date");

            RuleFor(p => p.Discount)
                .InclusiveBetween(0, 100)
                .When(p => p.Discount.HasValue)
                .WithMessage("Discount must be between 0 and 100 percent");

            RuleFor(p => p.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");
        }
    }
}