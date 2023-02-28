using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem.Services.CommandModels.Booking;
using SimpleBookingSystem.Services.DtoModels;
using SimpleBookingSystem.Services.Helpers.Mappers;
using SimpleBookingSystem.Services.Services.Command.CommandServices.BookingServices;
using SimpleBookingSystem.Services.Services.Query.QueryServices.BookingServices;

namespace SimpleBookingSystemApp.Controllers {
	[ApiController]
	[Route("booking")]
	public class BookingsController : ControllerBase {
		private readonly CreateBookingCommandService _createBookingCommandService;

		public BookingsController(CreateBookingCommandService createBookingCommandService) {
			_createBookingCommandService = createBookingCommandService;
		}

		[HttpPost]
		public ActionResult<BookingDto> CreateBooking(CreateBookingCommand command) {
			try {
				_createBookingCommandService.Validate(command);
				var bookingDto = _createBookingCommandService.DoWork(command);
				return Ok(bookingDto);
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}

}
