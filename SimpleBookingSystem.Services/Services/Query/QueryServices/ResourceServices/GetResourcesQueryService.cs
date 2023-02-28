using SimpleBookingSystem.DataAccess.Repositories;
using SimpleBookingSystem.Domain.Models;
using SimpleBookingSystem.Services.DtoModels;
using SimpleBookingSystem.Services.Helpers.Mappers;
using SimpleBookingSystem.Services.Services.Query.QueryInterfaces;

namespace SimpleBookingSystem.Services.Services.Query.QueryServices.BookingServices {
	public class GetResourcesQueryService : IGetResourcesQueryService {
		private readonly ResourceRepository _resourceRepository;

		public GetResourcesQueryService(ResourceRepository resourceRepository) {
			_resourceRepository = resourceRepository;
		}

		public IEnumerable<Resource> Handle() {
			var resourceList = _resourceRepository.GetAll().ToList();
			return resourceList;
		}
	}
}
