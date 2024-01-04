using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class Product : BaseDomainEntity
	{
		[Key]
		public int ProductId { get; set; }

		//[MaxLength(200)]
		public string Title { get; set; } = null!;

		//[MaxLength(200)]
		public string ImageUrl { get; set; } = null!;

		#region Relations
		public List<ProductVariable> ProductVariables { get; set; } = null!;
		#endregion
	}
}
