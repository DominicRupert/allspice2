using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allspice2.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public Profile Creator { get; set; }

        public string CreatorId { get; set; }





        
    }

    public class RecipeFavorite
    {
     public int FavId { get; set; }
    }
}