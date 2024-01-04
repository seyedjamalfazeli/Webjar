using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Webjar.Application.Contracts.Persistence;
using Webjar.Application.DTOs.ColorVariable;
using Webjar.Application.DTOs.Product;
using Webjar.Application.DTOs.ProductVariable;
using Webjar.Application.DTOs.SizeVariable;
using Webjar.Application.Utitlies;
using Webjar.Domain;

namespace Webjar.Persistence.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ProductDbContext _dbContext;
		private readonly IConfiguration _configuration;

		public ProductRepository(ProductDbContext context, IConfiguration configuration) : base(context)
		{
			_dbContext = context;
			_configuration = configuration;
		}

		public Task<List<ProductDto>> GetProductWithDetails()
		{
			IQueryable<Product> products = _dbContext.Products
				.Include(p => p.ProductVariables)
				.ThenInclude(pv => pv.ColorVariable)
				.Include(p => p.ProductVariables)
				.ThenInclude(pv => pv.SizeVariable)
				.Include(p => p.ProductVariables)
				.ThenInclude(pv => pv.ProductVariableAccessories)
				.ThenInclude(pva => pva.Accessory);

			List<ProductDto> selectedProducts = new List<ProductDto>();
			foreach (var product in products)
			{
				ProductDto productDto = new ProductDto();
				productDto.Id = product.ProductId;
				productDto.Title = product.Title;
				productDto.ImageUrl = FolderSavedAddress.Product + product.ProductId;

				List<ProductVariableDto> selectedProductVariables = new();
				foreach (var variable in product.ProductVariables)
				{
					productDto.FinalPrice += variable.Amount - variable.DiscountAmount;

					if (variable.DiscountExpireAt.HasValue)
						if (variable.DiscountExpireAt.Value < DateTime.Now)
							productDto.FinalPrice += variable.DiscountAmount;

					if (variable.ProductVariableAccessories != null)
						foreach (var pva in variable.ProductVariableAccessories)
							productDto.FinalPrice += pva.Accessory.Amount;

					selectedProductVariables.Add(new ProductVariableDto
					{
						Id = variable.ProductVariableId,
						Amount = variable.Amount,
						DollarAmount = Convert.ToDecimal(variable.DollarValue) * Convert.ToDecimal(_configuration["DollorAmount"]),
						DiscountAmount = variable.DiscountAmount,
						DiscountExpireAt = variable.DiscountExpireAt,
						ColorVariableDto = new ColorVariableDto
						{
							Id = variable.ColorVariableId,
							Title = variable.ColorVariable.Title,
							HexCode = variable.ColorVariable.HexCode,
						},
						SizeVariableDto = new SizeVariableDto
						{
							Id = variable.SizeVariableId,
							Title = variable.SizeVariable.Title,
						},
						Accessories = variable.ProductVariableAccessories.Select(a => new Application.DTOs.Accessory.AccessoryDto
						{
							Id = a.AccessoryId,
							Amount = a.Accessory.Amount,
							Title = a.Accessory.Title,
						}).ToList()
					});

					productDto.Variables = selectedProductVariables;
				}

				selectedProducts.Add(productDto);

			}

			return Task.FromResult(selectedProducts.OrderByDescending(o=>o.FinalPrice).ToList());
		}
	}
}
