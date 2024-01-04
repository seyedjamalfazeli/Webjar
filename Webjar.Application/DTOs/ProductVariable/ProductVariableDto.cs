
using Webjar.Application.DTOs.Accessory;
using Webjar.Application.DTOs.ColorVariable;
using Webjar.Application.DTOs.Common;
using Webjar.Application.DTOs.SizeVariable;

namespace Webjar.Application.DTOs.ProductVariable
{
	public class ProductVariableDto : BaseDto
	{
		public decimal Amount { get; set; }
		public decimal DollarAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public DateTime? DiscountExpireAt { get; set; }
		public ColorVariableDto ColorVariableDto { get; set; } = null!;
		public SizeVariableDto SizeVariableDto { get; set; } = null!;
		public List<AccessoryDto>? Accessories { get; set; }
	}
}
