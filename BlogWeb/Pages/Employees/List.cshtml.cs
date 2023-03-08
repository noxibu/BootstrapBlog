using BlogWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogWeb.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        public List<Models.Domain.Employee> Employees { get; set; }

        public ListModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Employees = dbContext.Employees.ToList();


        }
    }
}
