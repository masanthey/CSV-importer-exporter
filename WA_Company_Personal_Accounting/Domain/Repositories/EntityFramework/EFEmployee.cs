using Microsoft.EntityFrameworkCore;
using WA_Company_Personal_Accounting.Domain.Entities;
using WA_Company_Personal_Accounting.Domain.Repositories.Interfaces;

namespace WA_Company_Personal_Accounting.Domain.Repositories.EntityFramework
{
	public class EFEmployee : IEmployee
	{
		private readonly AppDbContext context;
		public EFEmployee(AppDbContext context) 
		{ 
			this.context = context;
		}
		public IQueryable<Employee> GetEmployee() 
		{
			return context.Employees;
		}
		public Employee GetEmployeeById(Guid id) 
		{
			return  context.Employees.FirstOrDefault(x => x.Id == id);
		}
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void SaveEmployee(Employee entity) 
		{
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public async Task SaveEmployeeAsync(Employee entity) 
		{
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public void DeleteEmployee(Guid id) 
		{
			context.Employees.Remove(new Employee() { Id = id });
			context.SaveChanges();
		}
        public async Task DeleteEmployeeAsync(Guid id)
        {
            context.Employees.Remove(new Employee() { Id = id }); 
            await context.SaveChangesAsync();
        }
    }
}
