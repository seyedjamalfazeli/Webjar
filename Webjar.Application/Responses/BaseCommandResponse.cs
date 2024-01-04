
namespace Webjar.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;        
    }
}
