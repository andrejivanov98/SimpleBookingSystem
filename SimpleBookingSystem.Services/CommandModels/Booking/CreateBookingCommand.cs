namespace SimpleBookingSystem.Services.CommandModels.Booking
{
    public class CreateBookingCommand
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
		public CreateBookingCommand(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId) {
			DateFrom = dateFrom;
			DateTo = dateTo;
			BookedQuantity = bookedQuantity;
			ResourceId = resourceId;
		}
	}
}
