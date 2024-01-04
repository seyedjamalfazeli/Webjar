using Webjar.Application.DTOs.Common;

namespace Webjar.Application.DTOs.SizeVariable
{
	public class SizeVariableDto : BaseDto, ISizeVariableDto
	{
		public string Title { get; set; } = null!;
	}
}
