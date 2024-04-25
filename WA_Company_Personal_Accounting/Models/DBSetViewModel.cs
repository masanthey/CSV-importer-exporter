using Microsoft.Build.ObjectModelRemoting;
using System.Linq;
using WA_Company_Personal_Accounting.Domain.Entities;
namespace WA_Company_Personal_Accounting.Models
{
	public class DBSetViewModel
    {
		public IQueryable<Company> Companies { get; set; }
		public IQueryable<Employee> Employees { get; set; }
	}
}
