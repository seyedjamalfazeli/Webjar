using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class ProductVariableAccessory : BaseDomainEntity
	{
		[Key]
		public int ProductVariableAccessoryId { get; set; }
		public int ProductVariableId { get; set; }
		public int AccessoryId { get; set; }

		#region Relations
		public ProductVariable ProductVariable { get; set; } = null!;
		public Accessory Accessory { get; set; } = null!;
		#endregion

	}
}
