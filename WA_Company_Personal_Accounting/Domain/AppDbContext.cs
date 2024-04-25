using Microsoft.EntityFrameworkCore;
using WA_Company_Personal_Accounting.Domain.Entities;

namespace WA_Company_Personal_Accounting.Domain
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Company>().HasData(new Company
			{
				 Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
				 Name = "OOO Default",
				 INN = "0000000000",
				 JuridicalAddress = "Рязань, Рязанская область. Советский район, улица Горького 34, квартира 16 Россия 390027.",
				 ActualAddress = "Рязань, Рязанская область. Советский район, улица Горького 34, квартира 16 Россия 390027."
			});
		}
	}
}
