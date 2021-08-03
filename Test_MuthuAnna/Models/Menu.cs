using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingKingslee.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VaritiesId { get; set; }
        public decimal? Price { get; set; }
        public Varities Varities { get; set; }
    }
}
