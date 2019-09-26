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
using FoodFunday;
using FoodFunday.Models;

namespace FoodFunday.Controllers
{
    public class ProductsController : ApiController
    {
        private FoodFundayEntities db = new FoodFundayEntities();

        // GET: api/Products
        public async Task<IEnumerable<Product>> GetSpecialProducts()
        {
            return await db.Products.Where(x => x.isSpecial == true).ToListAsync();
        }

        public async Task<IEnumerable<MenuTitleViewModel>> GetMenuCategory()
        {
            return await db.Categories.Select( x => new MenuTitleViewModel { Name = x.Name, icon = x.icon }).ToListAsync();
        }

        public List<ProductsViewModel> GetMenuForCategory(string categoryName)
        {
            var cate = db.Categories.FirstOrDefault(x => x.Name.Contains(categoryName));
            if(cate == null)
                return null;

            return db.Products.Where(x => x.categoryId == cate.Id).Select(y => new ProductsViewModel {
                id = y.id,
                Images = y.Images.FirstOrDefault() == null ? "" : y.Images.FirstOrDefault().imageUrl,
                price = y.price,
                Summary = y.Summary,
                Title = y.Title
            }).ToList();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.id == id) > 0;
        }
    }
}