using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipesController : ApiController
    {
        private RecipesContext db = new RecipesContext();

        // GET: api/Recipes
        public IQueryable<RecipeDTO> GetRecipes()
        {
            var recipes = from r in db.Recipes
                          select new RecipeDTO()
                          {
                              Id = r.RecipeId,
                              Title = r.Title
                          };
            return recipes;
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(RecipeDetailDTO))]
        public async Task<IHttpActionResult> GetRecipe(int id)
        {
            var recipe = await db.Recipes.Include(r => r.Products).Select(r =>
                new RecipeDetailDTO()
                {
                    Id = r.RecipeId,
                    Title = r.Title,
                    Instructions = r.Instructions,
                    Ingredients = r.Products
                });
            //Recipe recipe = await db.Recipes.FindAsync(id);
            //if (recipe == null)
            //{
            //    return NotFound();
            //}

            //return Ok(recipe);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(Recipe))]
        public async Task<IHttpActionResult> PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recipe.RecipeId }, recipe);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public async Task<IHttpActionResult> DeleteRecipe(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            await db.SaveChangesAsync();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.RecipeId == id) > 0;
        }
    }
}