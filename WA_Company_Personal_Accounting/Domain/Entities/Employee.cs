using System.ComponentModel.DataAnnotations;

namespace WA_Company_Personal_Accounting.Domain.Entities
{
	public class Employee
	{
		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Имя")]
		public string Name { get; set; }

		[Display(Name = "Фамилия")]
		public string Surname {  get; set; }

		[Display(Name = "Отчество")]
		public string Patronymic { get; set; }

		[Display(Name = "Дата Рождения")]
		public DateTime DateOfBirth { get; set; }

		[Display(Name = "Серия Паспорта")]
		[StringLength(4)]
		public string PasportSeries { get; set; }

		[Display(Name = "Номер Паспорта")]
		[StringLength(6)]
		public string PasportNumber { get; set; }


	}
}
