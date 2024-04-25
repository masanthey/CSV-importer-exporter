using Microsoft.EntityFrameworkCore;
using WA_Company_Personal_Accounting.Domain.Entities;
using WA_Company_Personal_Accounting.Domain.Repositories.Interfaces;

namespace WA_Company_Personal_Accounting.Domain.Repositories.EntityFramework
{
	public class EFCompany : ICompany
	{
		private readonly AppDbContext context;
		public EFCompany(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<Company> GetCompany()
		{
			return context.Companies;
		}
		public Company GetCompanyById(Guid id)
		{
			return context.Companies.FirstOrDefault(x => x.Id == id);
		}
        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            return await context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void SaveCompany(Company entity)
		{
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}

        public async Task SaveCompanyAsync(Company entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public void DeleteCompany(Guid id)
		{
			context.Companies.Remove(new Company() { Id = id });
			context.SaveChanges();
		}

        public async Task DeleteCompanyAsync(Guid id)
        {
            context.Companies.Remove(new Company() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
