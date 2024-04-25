using WA_Company_Personal_Accounting.Domain.Repositories.Interfaces;

namespace WA_Company_Personal_Accounting.Domain
{
	public class DataManager
	{
		public ICompany company {  get; set; }
		public IEmployee employee { get; set; }
		public DataManager(IEmployee employee, ICompany company) 
		{
			this.employee = employee;
			this.company = company;
		}
	}
}
