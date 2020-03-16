using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Example.Models
{
    public class Countries
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime IndependenceDay { get; set; }
        public int Population { get; set; }


    }
}
