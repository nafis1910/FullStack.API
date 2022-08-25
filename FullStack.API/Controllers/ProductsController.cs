using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext; //assinged as local variable

        public ProductsController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
           var products = await _fullStackDbContext.Products.ToListAsync(); //because it is async, await is use for that

            return Ok(products); //ok response for get
        }

        [HttpPost]

        public async Task<IActionResult> AddProducts([FromBody] Product productRequest)
        {
            productRequest.Id = Guid.NewGuid();

            await _fullStackDbContext.Products.AddAsync(productRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(productRequest);
        }
    }
}
