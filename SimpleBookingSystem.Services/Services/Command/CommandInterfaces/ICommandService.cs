
namespace SimpleBookingSystem.Services.Services.Command.CommandInterfaces {
	public interface ICommandService<in TRequest, out TResponse>
	where TRequest : class
	where TResponse : class {
		void Validate(TRequest request);
		TResponse DoWork(TRequest request);
	}

}
