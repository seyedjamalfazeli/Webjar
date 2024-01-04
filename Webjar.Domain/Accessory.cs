using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class Accessory : BaseDomainEntity
	{
		[Key]
		public int AccessoryId { get; set; }

		//[MaxLength(200)]
		public string Title { get; set; } = null!;
		public decimal Amount { get; set; }

		#region Relations
		public List<ProductVariableAccessory> ProductVariableAccessories { get; set; } = null!;
		#endregion
	}
}
