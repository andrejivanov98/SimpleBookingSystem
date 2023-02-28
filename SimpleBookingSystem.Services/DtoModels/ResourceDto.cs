
namespace SimpleBookingSystem.Services.DtoModels {
	public class ResourceDto {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public ResourceDto(int id, string name, int quantity) { 
			Id = id;
			Name = name;
			Quantity = quantity;
		}
	}
}
