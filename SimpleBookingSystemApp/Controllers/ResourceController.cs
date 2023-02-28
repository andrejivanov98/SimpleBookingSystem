using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem.Services.DtoModels;
using SimpleBookingSystem.Services.Helpers.Mappers;
using SimpleBookingSystem.Services.Services.Query.QueryInterfaces;
using SimpleBookingSystem.Services.Services.Query.QueryServices.BookingServices;

namespace SimpleBookingSystemApp.Controllers {
	[ApiController]
	[Route("resource")]
	public class ResourceController : ControllerBase {
		private readonly GetResourcesQueryService _getResourcesQueryService;

		public ResourceController(GetResourcesQueryService getResourcesQueryService) {
			_getResourcesQueryService = getResourcesQueryService;
		}

		[HttpGet]
		public IEnumerable<ResourceDto> Get() {
			var resources = _getResourcesQueryService.Handle().ToList();
			
			return MapResourcesToResourceDtos.Map(resources);
		}
	}

}
