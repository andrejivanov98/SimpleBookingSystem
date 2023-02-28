using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem.Domain.Models;

namespace SimpleBookingSystem.DataAccess.EntityFramework {
	public class SimpleBookingSystemDbContext : DbContext {

		public SimpleBookingSystemDbContext(DbContextOptions<SimpleBookingSystemDbContext> options) : base(options) { }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Resource>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Quantity).IsRequired();
			});

			modelBuilder.Entity<Booking>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.DateFrom).IsRequired();
				entity.Property(e => e.DateTo).IsRequired();
				entity.Property(e => e.BookedQuantity).IsRequired();
				entity.HasOne(e => e.Resource)
					  .WithMany()
					  .HasForeignKey(e => e.ResourceId)
					  .OnDelete(DeleteBehavior.Restrict);
			});
		}


	}
}
