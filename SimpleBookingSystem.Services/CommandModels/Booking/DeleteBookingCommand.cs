using System.ComponentModel.DataAnnotations;

namespace SimpleBookingSystem.Services.CommandModels.Booking
{
    public class DeleteBookingCommand
    {
        [Required]
        public int Id { get; set; }
    }
}
