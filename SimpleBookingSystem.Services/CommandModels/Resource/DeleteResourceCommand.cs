using System.ComponentModel.DataAnnotations;

namespace SimpleBookingSystem.Services.CommandModels.Resource {
	public class DeleteResourceCommand {
		[Required]
		public int Id { get; set; }
	}
}
