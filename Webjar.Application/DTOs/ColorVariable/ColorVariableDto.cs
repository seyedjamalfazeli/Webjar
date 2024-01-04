
using Webjar.Application.DTOs.Common;

namespace Webjar.Application.DTOs.ColorVariable
{
	public class ColorVariableDto: BaseDto, IColorVariableDto
	{
		public string Title { get; set; } = null!;
		public string? HexCode { get; set; }
	}
}
