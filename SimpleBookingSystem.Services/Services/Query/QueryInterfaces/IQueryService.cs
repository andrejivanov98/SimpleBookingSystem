
namespace SimpleBookingSystem.Services.Services.Query.QueryInterfaces {
	public interface IQueryService<out TResponse, in TRequest>
	where TResponse : class
	where TRequest : class {
		TResponse Handle(TRequest request);
	}

	public interface IQueryService<out TResponse>
	where TResponse : class {
		IEnumerable<TResponse> Handle();
	}

}
