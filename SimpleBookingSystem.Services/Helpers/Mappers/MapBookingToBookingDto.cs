using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.DtoModels;

namespace SimpleBookingSystem.Services.Helpers.Mappers {
	public static class MapBookingToBookingDto {
		public static BookingDto Map(Booking booking) {
			return new BookingDto(booking.DateFrom, booking.DateTo, booking.BookedQuantity, booking.ResourceId);
		}
	}
}
