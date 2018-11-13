using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetCoreWeb_001.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(AppDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            db.Customers.Add(Customer);
            await db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added!";
            return RedirectToPage("/Index");
        }
    }
}