using SimpleBookingSystem.DataAccess.Repositories;
using SimpleBookingSystem.Services.CommandModels.Booking;
using SimpleBookingSystem.Services.DtoModels;
using SimpleBookingSystem.Services.Services.Command.CommandInterfaces;
using SimpleBookingSystem.Services.Helpers;
using SimpleBookingSystem.Services.Helpers.Mappers;

namespace SimpleBookingSystem.Services.Services.Command.CommandServices.BookingServices
	{
	public class CreateBookingCommandService : ICreateBookingCommandService {
		private readonly BookingRepository _bookingRepository;
		private readonly IBookingService _bookingService;

		public CreateBookingCommandService(BookingRepository bookingRepository, IBookingService bookingService) {
			_bookingRepository = bookingRepository;
			_bookingService = bookingService;
		}

		public void Validate(CreateBookingCommand request) {
			if (request.DateFrom > request.DateTo) {
				throw new ArgumentException("DateFrom must be before DateTo.");
			}

			if (request.DateFrom < DateTime.Now) {
				throw new ArgumentException("DateFrom cannot be in the past.");
			}

			if (request.DateTo < DateTime.Now) {
				throw new ArgumentException("DateTo cannot be in the past.");
			}

			if (request.BookedQuantity < 1) {
				throw new ArgumentException("BookedQuantity must be greater than 0.");
			}

			if (!_bookingService.IsQuantityAvailable(request.ResourceId, request.BookedQuantity, request.DateFrom, request.DateTo)) {
				throw new ArgumentException("Requested quantity is not available for the requested period.");
			} else {
				Console.WriteLine("Requested quantity is available for the requested period.");
			}
		}

		public BookingDto DoWork(CreateBookingCommand request) {
			var booking = MapCreateBookingCommandToBooking.Map(request);
			_bookingRepository.Create(booking);

			// Send email to admin
			Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {booking.Id}");

			return MapBookingToBookingDto.Map(booking);
		}
	}
}
