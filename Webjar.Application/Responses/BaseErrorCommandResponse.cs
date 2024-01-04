using FluentValidation.Results;

namespace Webjar.Application.Responses
{
	public class BaseErrorCommandResponse : BaseCommandResponse
	{
		public List<string> Errors { get; set; } = new List<string>();

		public BaseErrorCommandResponse(ValidationResult validationResult)
		{
			foreach (var err in validationResult.Errors)
				Errors.Add(err.ErrorMessage);
		}
	}
}
