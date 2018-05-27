using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes.Models
{
    public class RecipeDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Ingredients { get; set; }
        public string Instructions { get; set; }

    }
}