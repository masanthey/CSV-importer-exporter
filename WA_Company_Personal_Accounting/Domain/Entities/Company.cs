using System.ComponentModel.DataAnnotations;

namespace WA_Company_Personal_Accounting.Domain.Entities
{
	public class Company
	{
		[Required]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Это обязательное поле")]
		[Display(Name = "Имя компании")]
		public string Name { get; set; }

		[StringLength(10, ErrorMessage = "неверное количество символов")]
		[Display(Name = "ИНН компании")]
		public string INN { get; set; }

		[Display(Name = "Юр. Адрес компании")]
		public string JuridicalAddress { get; set; }
                  
        [Display(Name = "Факт. Адрес компании")]
		public string ActualAddress { get; set; }

	}
}
