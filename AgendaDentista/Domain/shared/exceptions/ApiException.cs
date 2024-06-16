
namespace Domain.Shared.Exceptions;

public class ApiException : Exception {
	public ApiException(string message) : base(message) { }

	public ApiException(string message, string source) : base(message) {
		Source = source;
	}
}
