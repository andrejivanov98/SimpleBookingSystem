using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.DtoModels;

namespace SimpleBookingSystem.Services.Helpers.Mappers {
	public static class MapResourcesToResourceDtos {
		public static List<ResourceDto> Map(List<Resource> resources) {
			var resourceDtoList = new List<ResourceDto>();

			foreach (var resource in resources) {
				resourceDtoList.Add(MapResourceToResourceDto.Map(resource));
			}

			return resourceDtoList;
		}
	}
}
