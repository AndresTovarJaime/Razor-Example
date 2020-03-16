using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Example.Data;
using Razor_Example.Models;

namespace Razor_Example
{
    public class DetailsModel : PageModel
    {
        private readonly Razor_Example.Data.Razor_ExampleContext _context;

        public DetailsModel(Razor_Example.Data.Razor_ExampleContext context)
        {
            _context = context;
        }

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
    }
}
