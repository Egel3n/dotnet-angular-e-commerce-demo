using ETicaretAPI.Application.Repositories.Product;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ETicaretAPI.Application.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageInfo pageInfo)
        {
           var products = _productReadRepository.GetAll(false)
                .Select(p => 
                new { p.Name,
                    p.Price,
                    p.Stock,
                    p.Created,
                    p.Updated,
                    p.Ids
                    })
                .Skip(pageInfo.Size*pageInfo.Page).Take(pageInfo.Size).ToList();

            var totalCount = _productReadRepository.GetAll(false).Count();



            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _productReadRepository.FindByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Product_Create model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Bozuk");
            }


            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,
            });

            await _productWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Product_Update model)
        {

            var product = await _productReadRepository.FindByIdAsync((model.Id).ToString("N"));
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();


            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.Remove(id);
            await _productWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.OK);

        }

    }
}
