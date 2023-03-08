using BlogWeb.Data;
using BlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogWeb.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }
        public EditModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                //Convert domain model to view model
                EditEmployeeViewModel = new EditEmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                    Salary = employee.Salary,
                    Department = employee.Department
                };
            }
        }

        public void OnPostUpdate()
        {
            if(EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
                if(existingEmployee != null)
                {
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Department = EditEmployeeViewModel.Department;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Employe updated successfully!";
                   
                }
            }

           


        }

        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
            if(existingEmployee != null)
            {
                dbContext.Employees.Remove(existingEmployee);
                dbContext.SaveChanges();

                return RedirectToPage("/Employees/List");
            }
            return Page();

        }
    }
}
