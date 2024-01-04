using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class ProductVariable : BaseDomainEntity
	{
		[Key]
		public int ProductVariableId { get; set; }
		public int ProductId { get; set; }
		public decimal Amount { get; set; }
		public float DollarValue { get; set; }
		public int Stock { get; set; }
		public int ColorVariableId { get; set; }
		public int SizeVariableId { get; set; }
		public decimal DiscountAmount { get; set; }
		public DateTime? DiscountExpireAt { get; set; }

		#region Relations
		public List<ProductVariableAccessory> ProductVariableAccessories { get; set; } = null!;
		public Product Product { get; set; } = null!;
		public ColorVariable ColorVariable { get; set; } = null!;
		public SizeVariable SizeVariable { get; set; } = null!;
		#endregion
	}
}
