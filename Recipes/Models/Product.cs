using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recipes.Models
{
    public class Product
    {
        public Product()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}