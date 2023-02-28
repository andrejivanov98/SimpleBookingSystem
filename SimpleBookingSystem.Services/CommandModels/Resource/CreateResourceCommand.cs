using System.ComponentModel.DataAnnotations;

namespace SimpleBookingSystem.Services.CommandModels.Resource {
	public class CreateResourceCommand {
		[Required]
		public string Name { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
		public int Quantity { get; set; }
	}
}
