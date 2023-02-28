using SimpleBookingSystem.DataAccess.Repositories;
using SimpleBookingSystem.Services.DtoModels;
using SimpleBookingSystem.Services.Helpers.Mappers;
using SimpleBookingSystem.Services.QueryModels;
using SimpleBookingSystem.Services.Services.Query.QueryInterfaces;

namespace SimpleBookingSystem.Services.Services.Query.QueryServices.BookingServices {
	public class GetBookingQueryService : IGetBookingQueryService{
		private readonly BookingRepository _bookingRepository;

		public GetBookingQueryService(BookingRepository bookingRepository) {
			_bookingRepository = bookingRepository;
		}

		public BookingDto Handle(GetBookingQuery getBookingQuery) {
			var booking = _bookingRepository.GetAll().SingleOrDefault(b => b.Id == getBookingQuery.BookingId);
			if (booking == null) {
				throw new Exception($"Booking with id {booking.Id} not found.");
			}

			return MapBookingToBookingDto.Map(booking);
		}
	}
}
