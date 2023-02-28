using SimpleBookingSystem.DataAccess.Repositories;

namespace SimpleBookingSystem.Services.Helpers {
	public class BookingService : IBookingService {
		private readonly BookingRepository _bookingRepository;
		private readonly ResourceRepository _resourceRepository;

		public BookingService(BookingRepository bookingRepository, ResourceRepository resourceRepository) {
			_bookingRepository = bookingRepository;
			_resourceRepository = resourceRepository;
		}

		public bool IsQuantityAvailable(int resourceId, int requestedQuantity, DateTime dateFrom, DateTime dateTo) {
			var existingBookings = _bookingRepository.GetAll()
				.Where(b => b.ResourceId == resourceId &&
							b.DateTo >= dateFrom &&
							dateTo >= b.DateFrom)
				.ToList();

			var totalBookedQuantity = existingBookings.Sum(b => b.BookedQuantity);
			var remainingQuantity = _resourceRepository.GetById(resourceId).Quantity - totalBookedQuantity;

			if (remainingQuantity >= requestedQuantity) {
				var bookedQuantity = totalBookedQuantity + requestedQuantity;
				_resourceRepository.UpdateQuantity(resourceId, _resourceRepository.GetById(resourceId).Quantity - bookedQuantity);
				return true;
			} else {
				return false;
			}
		}

	}
}
