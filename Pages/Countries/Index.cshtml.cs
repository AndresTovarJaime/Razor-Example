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
    public class IndexModel : PageModel
    {
        private readonly Razor_Example.Data.Razor_ExampleContext _context;

        public IndexModel(Razor_Example.Data.Razor_ExampleContext context)
        {
            _context = context;
        }

        public IList<Countries> Countries { get;set; }

        public async Task OnGetAsync()
        {
            Countries = await _context.Countries.ToListAsync();
        }
    }
}
