using System.Linq;
using SimpleBookingSystem.DataAccess.EntityFramework;
using SimpleBookingSystem.DataAccess.Repositories.RepositoryInterfaces;
using SimpleBookingSystem.Domain.Models;

namespace SimpleBookingSystem.DataAccess.Repositories
{
	public class BookingRepository : IRepository<Booking> {
		private readonly SimpleBookingSystemDbContext _db;
		private readonly ResourceRepository _resourceRepository;

		public BookingRepository(SimpleBookingSystemDbContext db, ResourceRepository resourceRepository) {
			_db = db;
			_resourceRepository = resourceRepository;
		}

		public List<Booking> GetAll() {
			return _db.Bookings.ToList();
		}

		public Booking GetById(int id) {
			var booking = _db.Bookings.SingleOrDefault(x => x.Id == id);
			if (booking == null) {
				throw new Exception("No booking found.");
			}
			return booking;
		}

		public void Create(Booking entity) {
			_db.Bookings.Add(entity);
			_db.SaveChanges();
		}

		public void Delete(Booking entity) {
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			_db.Bookings.Remove(entity);
			_db.SaveChanges();

			_resourceRepository.UpdateQuantity(entity.ResourceId, _resourceRepository.GetById(entity.ResourceId).Quantity + entity.BookedQuantity);
		}

		public void Update(Booking entity) {
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			_db.Bookings.Update(entity);
			_db.SaveChanges();
		}

		public void RemoveExpiredBookings() {
			var expiredBookings = _db.Bookings.Where(b => b.DateTo < DateTime.Now).ToList();
			foreach (var booking in expiredBookings) {
				_db.Bookings.Remove(booking);
				_db.SaveChanges();

				_resourceRepository.UpdateQuantity(booking.ResourceId, _resourceRepository.GetById(booking.ResourceId).Quantity + booking.BookedQuantity);
			}
		}
	}
}
