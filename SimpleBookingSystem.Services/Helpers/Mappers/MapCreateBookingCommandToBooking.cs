using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.CommandModels.Booking;

namespace SimpleBookingSystem.Services.Helpers.Mappers {
	public static class MapCreateBookingCommandToBooking {
		public static Booking Map(CreateBookingCommand createBookingCommand) {
			return new Booking(createBookingCommand.DateFrom, createBookingCommand.DateTo, createBookingCommand.BookedQuantity, createBookingCommand.ResourceId);
		}
	}
}
