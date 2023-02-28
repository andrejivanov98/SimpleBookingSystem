using System.ComponentModel.DataAnnotations;


namespace SimpleBookingSystem.Services.CommandModels.Booking
{
    public class UpdateBookingCommand
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BookedQuantity must be greater than 0.")]
        public int BookedQuantity { get; set; }
    }
}
