using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.DtoModels;

namespace SimpleBookingSystem.Services.Helpers.Mappers {
	public static class MapResourceToResourceDto {
		public static ResourceDto Map(Resource resource) {
			return new ResourceDto(resource.Id, resource.Name, resource.Quantity);
		}
	}
}
