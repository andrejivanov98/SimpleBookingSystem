using System.ComponentModel.DataAnnotations;

namespace SimpleBookingSystem.Domain.Models {
	public class Booking {
		[Key]
		public int Id { get; set; }
		[Required]
		public DateTime DateFrom { get; set; }
		[Required]
		public DateTime DateTo { get; set; }
		[Required]
		public int BookedQuantity { get; set; }
		[Required]
		public int ResourceId { get; set; }
		public Resource Resource { get; set; }
		public Booking(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId) {
			DateFrom = dateFrom;
			DateTo = dateTo;
			BookedQuantity = bookedQuantity;
			ResourceId = resourceId;
		}
	}
}
