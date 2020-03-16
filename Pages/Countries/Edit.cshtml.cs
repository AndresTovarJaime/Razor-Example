using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Example.Data;
using Razor_Example.Models;

namespace Razor_Example
{
    public class EditModel : PageModel
    {
        private readonly Razor_Example.Data.Razor_ExampleContext _context;

        public EditModel(Razor_Example.Data.Razor_ExampleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Countries Countries { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Countries = await _context.Countries.FirstOrDefaultAsync(m => m.ID == id);

            if (Countries == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(Countries.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Any(e => e.ID == id);
        }
    }
}
