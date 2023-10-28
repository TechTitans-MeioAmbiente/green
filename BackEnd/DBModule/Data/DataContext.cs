using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Models;

namespace TechTitansAPI.Data
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<PictureModel> Pictures { get; set; }
		public DbSet<CompanyModel> Companies { get; set; }
		public DbSet<AppUserModel> AppUsers { get; set; } 
		public DbSet<TreeModel> Trees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TreeModel>()
				.HasOne(a => a.AppUser)
				.WithMany(t => t.Trees)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PictureModel>() 
				.HasOne(p => p.Tree) 
				.WithMany(t => t.Pictures)
				.HasForeignKey(p => p.TreeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
	}
}
