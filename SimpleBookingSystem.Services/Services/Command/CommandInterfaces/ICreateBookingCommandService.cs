using SimpleBookingSystem.Services.CommandModels.Booking;
using SimpleBookingSystem.Services.DtoModels;

namespace SimpleBookingSystem.Services.Services.Command.CommandInterfaces {
	public interface ICreateBookingCommandService : ICommandService<CreateBookingCommand, BookingDto> {
	}
}
