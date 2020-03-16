using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_Example.Data;
using Razor_Example.Models;

namespace Razor_Example
{
    public class CreateModel : PageModel
    {
        private readonly Razor_Example.Data.Razor_ExampleContext _context;

        public CreateModel(Razor_Example.Data.Razor_ExampleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Countries Countries { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Countries.Add(Countries);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
