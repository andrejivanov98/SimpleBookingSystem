using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookingSystem.Services.Helpers.Mappers {
	public static class MapResourceDtoToResource {
		public static Resource Map(ResourceDto resourceDto) {
			return new Resource(resourceDto.Id, resourceDto.Name, resourceDto.Quantity);
		}
	}
}
