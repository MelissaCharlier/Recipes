namespace Recipes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Recipes.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Recipes.Models.RecipesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Recipes.Models.RecipesContext context)
        {
            context.Products.AddOrUpdate(x => x.ProductId, new Product() { ProductId = 1, Name = "Truc" });
            context.Recipes.AddOrUpdate(x => x.RecipeId, new Recipe() { RecipeId = 1, Title = "Waffles" });
        }
    }
}
