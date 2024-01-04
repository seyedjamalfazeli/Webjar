
namespace Webjar.Application.Responses
{
	public class BaseDataCommandResponse<T> : BaseCommandResponse
	{
		public T? Data { get; set; }
	}
}
