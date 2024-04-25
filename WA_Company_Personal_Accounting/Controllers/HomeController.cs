using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WA_Company_Personal_Accounting.Models;
using WA_Company_Personal_Accounting.Domain;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WA_Company_Personal_Accounting.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using LINQtoCSV;
using System.IO;
using WA_Company_Personal_Accounting.Domain.Repositories.Interfaces;

namespace WA_Company_Personal_Accounting.Controllers
{
    public class HomeController : Controller
    {
        readonly protected DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public HomeController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            DBSetViewModel dbSetViewModel = new();
            dbSetViewModel.Companies = dataManager.company.GetCompany();
            dbSetViewModel.Employees = dataManager.employee.GetEmployee();

            return View(dbSetViewModel);
        }
        [HttpPost]
        public FileResult ExportCompanyToCSV()
        {
            IQueryable<Company> company = dataManager.company.GetCompany();

            StringBuilder sb = new();
            sb.Append("Name" + ';' + "INN" + ';' + "JuridicalAddress" + ';' + "ActualAddress" + ';' + "\r\n");

            foreach (var item in company)
            {
                IList<string> arrCompany = [];
               // arrCompany.Add(item.Id.ToString());
                arrCompany.Add(item.Name);
                arrCompany.Add(item.INN);
                arrCompany.Add(item.JuridicalAddress);
                arrCompany.Add(item.ActualAddress);

                foreach (var data in arrCompany)
                {
                    sb.Append(data + ';');
                }

                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(sb.ToString())).ToArray(), "text/csv", "Company.csv");
            //File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "Company.csv"); 

        }
        [HttpPost]
        public FileResult ExportEmployeeToCSV()
        {
            IQueryable<Employee> company = dataManager.employee.GetEmployee();

            StringBuilder sb = new();
            sb.Append("Name" + ';' + "Surname" + ';' + "Patronymic" + ';' + "DateOfBirth" + ';' + "PasportSeries" + ';' + "PasportNumber" + ';' + "\r\n");

            foreach (var item in company)
            {
                IList<string> arrCompany = [];
              //  arrCompany.Add(item.Id.ToString());
                arrCompany.Add(item.Name);
                arrCompany.Add(item.Surname);
                arrCompany.Add(item.Patronymic);
                arrCompany.Add(item.DateOfBirth.ToString());
                arrCompany.Add(item.PasportSeries);
                arrCompany.Add(item.PasportNumber);

                foreach (var data in arrCompany)
                {
                    sb.Append(data + ';');
                }

                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(sb.ToString())).ToArray(), "text/csv", "Employee.csv");
            //File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "Company.csv"); 
        }

        [HttpPost]
        public async Task<IActionResult> ImportCompanyCSV(IFormFile attachmentcsv)
        {
            if (attachmentcsv == null) return BadRequest();

            CsvFileDescription csvFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true
            };

            CsvContext csvContext = new CsvContext();
            using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "CSVfile/", attachmentcsv.FileName), FileMode.Create))
            {
                await attachmentcsv.CopyToAsync(stream);
            }
            IEnumerable<Company> list = csvContext.Read<Company>(Path.Combine(hostingEnvironment.WebRootPath, "CSVfile/", attachmentcsv.FileName), csvFileDescription);
            foreach (Company ent in list)
            {
                await dataManager.company.SaveCompanyAsync(ent);
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));

        }

        [HttpPost]
        public async Task<IActionResult> ImportEmployeeCSV(IFormFile attachmentcsv)
        {
            if (attachmentcsv == null) return BadRequest();

            CsvFileDescription csvFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true
            };

            CsvContext csvContext = new CsvContext();
            using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "CSVfile/", attachmentcsv.FileName), FileMode.Create))
            {
                await attachmentcsv.CopyToAsync(stream);
            }
            IEnumerable<Employee> list = csvContext.Read<Employee>(Path.Combine(hostingEnvironment.WebRootPath, "CSVfile/", attachmentcsv.FileName), csvFileDescription);
            foreach (Employee ent in list)
            {
                await dataManager.employee.SaveEmployeeAsync(ent);
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));

        }
    }



}

