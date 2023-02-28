using SimpleBookingSystem.DataAccess.EntityFramework;
using SimpleBookingSystem.DataAccess.Repositories.RepositoryInterfaces;
using SimpleBookingSystem.Domain.Models;

namespace SimpleBookingSystem.DataAccess.Repositories
{
	public class ResourceRepository : IRepository<Resource> {
		private readonly SimpleBookingSystemDbContext _db;

		public ResourceRepository(SimpleBookingSystemDbContext db) {
			_db = db;
		}

		public List<Resource> GetAll() {
			return _db.Resources.ToList();
		}

		public Resource GetById(int id) {
			var resource = _db.Resources.SingleOrDefault(x => x.Id == id);
			if (resource == null) {
				throw new Exception("No resource found.");
			}
			return resource;
		}

		public void Create(Resource entity) {
			_db.Resources.Add(entity);
			_db.SaveChanges();
		}

		public void Delete(Resource entity) {
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			_db.Resources.Remove(entity);
			_db.SaveChanges();
		}

		public void Update(Resource entity) {
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			_db.Resources.Update(entity);
			_db.SaveChanges();
		}

		public void UpdateQuantity(int resourceId, int newQuantity) {
			var resource = GetById(resourceId);
			resource.Quantity = newQuantity;
			_db.SaveChanges();
		}

	}
}
