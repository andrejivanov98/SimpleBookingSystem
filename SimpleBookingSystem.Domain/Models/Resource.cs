using System.ComponentModel.DataAnnotations;

namespace SimpleBookingSystem.Domain.Models {
	public class Resource {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Quantity { get; set; }
		public Resource(int id, string name, int quantity) {
			Id = id;	
			Name = name;
			Quantity = quantity;
		}
	}
}
