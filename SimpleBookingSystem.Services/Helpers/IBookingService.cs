
namespace SimpleBookingSystem.Services.Helpers {
	public interface IBookingService {
		bool IsQuantityAvailable(int resourceId, int requestedQuantity, DateTime dateFrom, DateTime dateTo);
	}
}
