using BlogWeb.Data;
using BlogWeb.Models.Domain;
using BlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogWeb.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly BlogDbContext dbContext;

        public AddModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            // Convert view model to domain model
            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };

            dbContext.Employees.Add(employeeDomainModel);
            dbContext.SaveChanges();
            ViewData["Employee"] = employeeDomainModel.Name;
        }
    }
}
