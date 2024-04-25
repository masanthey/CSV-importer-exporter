using WA_Company_Personal_Accounting.Domain.Entities;

namespace WA_Company_Personal_Accounting.Domain.Repositories.Interfaces
{
	public interface ICompany
	{
		IQueryable<Company> GetCompany();
		Company GetCompanyById(Guid id);
        Task<Company> GetCompanyByIdAsync(Guid id);
        void SaveCompany(Company entity);
		Task SaveCompanyAsync(Company entity);
        void DeleteCompany(Guid id);
        Task DeleteCompanyAsync(Guid id);

    }
}
