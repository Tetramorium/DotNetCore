using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWeb_001.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;

        private ILogger<CreateModel> Log;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(AppDbContext _db, ILogger<CreateModel> _log)
        {
            this.db = _db;
            this.Log = _log;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            db.Customers.Add(Customer);
            await db.SaveChangesAsync();
            var msg = Message = $"Customer {Customer.Name} added!";
           // Message = msg;

            Log.LogCritical(msg);

            return RedirectToPage("/Index");
        }
    }
}