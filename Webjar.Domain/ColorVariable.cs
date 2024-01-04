using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class ColorVariable : BaseDomainEntity
	{
		[Key]
		public int ColorVariableId { get; set; }

		//[MaxLength(200)]
		public string Title { get; set; } = null!;

		//[MaxLength(6)]
		public string? HexCode { get; set; }

		#region Relations
		public List<ProductVariable> ProductVariables { get; set; } = null!;
		#endregion
	}
}
