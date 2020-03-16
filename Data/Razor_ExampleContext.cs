using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor_Example.Models;

namespace Razor_Example.Data
{
    public class Razor_ExampleContext : DbContext
    {
        public Razor_ExampleContext (DbContextOptions<Razor_ExampleContext> options)
            : base(options)
        {
        }

        public DbSet<Razor_Example.Models.Countries> Countries { get; set; }
    }
}
