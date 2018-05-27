using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recipes.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Instructions { get; set; }
        public int? Serves { get; set; }


    }
}