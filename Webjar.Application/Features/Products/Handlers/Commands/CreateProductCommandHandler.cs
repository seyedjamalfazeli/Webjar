using AutoMapper;
using MediatR;
using Webjar.Application.Contracts.Persistence;
using Webjar.Application.DTOs.Product.Validators;
using Webjar.Application.Exceptions;
using Webjar.Application.Features.Products.Requests.Commands;
using Webjar.Application.Responses;
using Webjar.Application.Utitlies;
using Webjar.Domain;

namespace Webjar.Application.Features.Products.Handlers.Commands
{
	public class CreateProductCommandHandler
		: IRequestHandler<CreateProductCommand, BaseCommandResponse>
	{
		private readonly IProductRepository _productRepository;
		private readonly IColorVariableRepository _colorVariableRepository;
		private readonly ISizeVariableRepository _sizeVariableRepository;
		private readonly IAccessoryRepository _accessoryRepository;
		private readonly IMapper _mapper;

		public CreateProductCommandHandler(IProductRepository productRepository,
			IColorVariableRepository colorVariableRepository,
			ISizeVariableRepository sizeVariableRepository,
			IAccessoryRepository accessoryRepository,
			IMapper mapper)
		{
			this._productRepository = productRepository;
			this._colorVariableRepository = colorVariableRepository;
			this._sizeVariableRepository = sizeVariableRepository;
			this._accessoryRepository = accessoryRepository;
			this._mapper = mapper;
		}
		public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateProductDtoValidator(
				_productRepository,
				_colorVariableRepository,
				_sizeVariableRepository,
				_accessoryRepository
				);
			var validationResult = await validator.ValidateAsync(request.ProductDto);

			if (!validationResult.IsValid)
				return new BaseErrorCommandResponse(validationResult)
				{
					Message = "Some errors have occurred",
				};

			var product = _mapper.Map<Product>(request.ProductDto);
			product.ProductVariables = new();

			foreach (var variable in request.ProductDto.Variables)
			{
				List<ProductVariableAccessory> productVariableAccessories = new();
				if (variable.AccessoryIds != null)
					foreach (var accessoryId in variable.AccessoryIds)
						productVariableAccessories.Add(new ProductVariableAccessory
						{
							AccessoryId = accessoryId,
						});

				if (!product.ProductVariables.Any(pv => pv.ColorVariableId == variable.ColorVariableId &&
													 pv.SizeVariableId == variable.SizeVariableId))
					product.ProductVariables.Add(new ProductVariable
					{
						Amount = variable.Amount,
						ColorVariableId = variable.ColorVariableId,
						SizeVariableId = variable.SizeVariableId,
						DollarValue = variable.DollarValue,
						Stock = variable.Stock,
						ProductVariableAccessories = productVariableAccessories,
						DiscountAmount = variable.DiscountAmount,
						DiscountExpireAt = variable.DiscountExpireAt,
					});
			}

			product.ImageUrl = FileMaker.SaveSingleFile(request.ProductDto.ImageFile, FolderSavedAddress.Product);

			product = await _productRepository.Add(product);
			return new BaseDataCommandResponse<int>
			{
				Data = product.ProductId,
				Success = true,
				Message = "Product added successfully",
			};
		}
	}
}
