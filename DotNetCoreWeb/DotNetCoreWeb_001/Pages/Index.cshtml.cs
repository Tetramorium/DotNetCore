using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWeb_001.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        [TempData]
        public string Message { get; set; }

        public IList<Customer> Customers { get; private set; }

        public IndexModel(AppDbContext _db)
        {
            this.db = _db;
        }

        public async Task OnGetAsync()
        {
            Customers = await db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await db.Customers.FindAsync(id);

            if (customer != null)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
