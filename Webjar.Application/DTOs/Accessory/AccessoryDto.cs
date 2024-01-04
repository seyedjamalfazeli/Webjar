
using Webjar.Application.DTOs.Common;

namespace Webjar.Application.DTOs.Accessory
{
	public class AccessoryDto:BaseDto,IAccessoryDto
	{
		public string Title { get; set; } = null!;
		public decimal Amount { get; set; }
	}
}
