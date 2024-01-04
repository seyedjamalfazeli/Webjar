using FluentValidation;
using Webjar.Application.Contracts.Persistence;

namespace Webjar.Application.DTOs.Product.Validators
{
	public class IProductDtoValidator : AbstractValidator<IProductDto>
	{
		private readonly IProductRepository _productRepository;

		public IProductDtoValidator(IProductRepository productRepository)
		{
			this._productRepository = productRepository;

			RuleFor(p => p.Title)
				.Must(p=>!string.IsNullOrWhiteSpace(p))
				.WithMessage("The {PropertyName} should not be empty or null.");
		}
	}
}
