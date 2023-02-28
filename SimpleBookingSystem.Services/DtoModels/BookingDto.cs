
namespace SimpleBookingSystem.Services.DtoModels {
	public class BookingDto {
		public int Id { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public int BookedQuantity { get; set; }
		public int ResourceId { get; set; }
		public BookingDto(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId) {
			DateFrom = dateFrom;
			DateTo = dateTo;
			BookedQuantity = bookedQuantity;
			ResourceId = resourceId;
		}
	}
}
