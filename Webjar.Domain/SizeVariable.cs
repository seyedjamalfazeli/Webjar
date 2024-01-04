using System.ComponentModel.DataAnnotations;
using Webjar.Domain.Common;

namespace Webjar.Domain
{
	public class SizeVariable : BaseDomainEntity
	{
		[Key]
		public int SizeVariableId { get; set; }

		//[MaxLength(200)]
		public string Title { get; set; } = null!;

		#region Relations
		public List<ProductVariable> ProductVariables { get; set; } = null!;
		#endregion
	}
}
