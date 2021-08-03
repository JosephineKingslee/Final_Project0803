using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingKingslee.Models
{
    public class Varities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Menu> Menus { get; set; }

    }
}
