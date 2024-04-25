using WA_Company_Personal_Accounting.Domain.Entities;

namespace WA_Company_Personal_Accounting.Domain.Repositories.Interfaces
{
	public interface IEmployee
	{
		IQueryable<Employee> GetEmployee();
		Employee GetEmployeeById(Guid id);
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        void SaveEmployee(Employee entity);
        Task SaveEmployeeAsync(Employee entity);
        void DeleteEmployee(Guid id);
        Task DeleteEmployeeAsync(Guid id);

    }
}
