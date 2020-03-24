using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cartelera.Models;
using Cartelera.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cartelera.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: api/values


        [HttpGet("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
        public IActionResult GetProducts()
        {
            return Ok(_db.Products.ToList());
        }



        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel formdata)
        {
            var newproduct = new ProductModel
            {
                Nombre = formdata.Nombre,
                ImageUrl = formdata.ImageUrl,
                Descripcion = formdata.Descripcion,
                FuerdeStock = formdata.FuerdeStock,
                Precio = formdata.Precio
            };

            await _db.Products.AddAsync(newproduct);

            await _db.SaveChangesAsync();

            return Ok(new JsonResult("The Product was Added Successfully"));

        }


        [HttpPut("[action]/{id}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel formdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var findProduct = _db.Products.FirstOrDefault(p => p.Id == id);

            if (findProduct == null)
            {
                return NotFound();
            }

            // If the product was found
            findProduct.Nombre = formdata.Nombre;
            findProduct.Descripcion = formdata.Descripcion;
            findProduct.ImageUrl = formdata.ImageUrl;
            findProduct.FuerdeStock = formdata.FuerdeStock;
            findProduct.Precio = formdata.Precio;

            _db.Entry(findProduct).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(new JsonResult("The Product with id " + id + " is updated"));

        }


        [HttpDelete("[action]/{id}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // find the product

            var findProduct = await _db.Products.FindAsync(id);

            if (findProduct == null)
            {
                return NotFound();
            }

            _db.Products.Remove(findProduct);

            await _db.SaveChangesAsync();

            // Finally return the result to client
            return Ok(new JsonResult("The Product with id " + id + " is Deleted."));

        }




    }
}