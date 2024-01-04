using FluentValidation;
using Webjar.Application.Contracts.Persistence;
using Webjar.Domain;

namespace Webjar.Application.DTOs.Product.Validators
{
	public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
	{
		private readonly IProductRepository _productRepository;
		private readonly IColorVariableRepository _colorVariableRepository;
		private readonly ISizeVariableRepository _sizeVariableRepository;
		private readonly IAccessoryRepository _accessoryRepository;

		public CreateProductDtoValidator(
			IProductRepository productRepository,
			IColorVariableRepository colorVariableRepository,
			ISizeVariableRepository sizeVariableRepository,
			IAccessoryRepository accessoryRepository)
		{
			_productRepository = productRepository;
			_colorVariableRepository = colorVariableRepository;
			_sizeVariableRepository = sizeVariableRepository;
			_accessoryRepository = accessoryRepository;

			Include(new IProductDtoValidator(_productRepository));
			RuleFor(p => p.Variables)
				.NotNull()
				.NotEmpty()
				.WithMessage("{PropertyName} is required.");

			RuleFor(p => p.ImageFile)
			.NotNull()
			.WithMessage("{PropertyName} is required.");

			RuleForEach(p => p.Variables).ChildRules(variable =>
			{
				variable.RuleFor(v => v.ColorVariableId)
				.MustAsync(async (id, token) =>
				{
					return await _colorVariableRepository.Exist(id);
				})
				.WithMessage("{PropertyName} does not exist.");

				variable.RuleFor(v => v.SizeVariableId)
				.MustAsync(async (id, token) =>
				{
					return await _sizeVariableRepository.Exist(id);
				})
				.WithMessage("{PropertyName} does not exist.");

				variable.RuleForEach(v => v.AccessoryIds).ChildRules(accessory =>
				{
					accessory.RuleFor(a => a)
					.MustAsync(async (id, token) =>
					{
						return await _accessoryRepository.Exist(id);
					})
					.WithMessage("Accessory with {PropertyValue} value does not exist.");
				});

				variable.RuleFor(v => v.DiscountAmount)
				.LessThanOrEqualTo(v=>v.Amount)
				.WithMessage("{PropertyName} must be equal or less than Amount.");
			});
		}
	}
}
