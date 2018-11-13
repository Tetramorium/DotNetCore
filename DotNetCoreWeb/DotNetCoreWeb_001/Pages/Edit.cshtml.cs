using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWeb_001.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext db;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(AppDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await db.Customers.FindAsync(id);
            if (Customer == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer {Customer.Id} not found!", e);
            }
            return RedirectToPage("./Index");
        }
    }
}