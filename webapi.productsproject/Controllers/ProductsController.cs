using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.productsproject.Domains;
using webapi.productsproject.Interfaces;

namespace webapi.productsproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private IProducts _product;

        public ProductsController(IProducts product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
        }

        [HttpDelete("DeleteProduct/{ID}")]
        public IActionResult Delete(Guid ID)
        {
            try
            {
                Products searchedProduct = _product.GetByID(ID);

                if (searchedProduct != null)
                {
                    _product.Delete(ID);

                    return Ok("The product has been deleted!");
                }
                else
                {
                    return NotFound("No products with this ID were found!");
                }
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_product.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByID/{ID}")]
        public IActionResult GetByID(Guid ID)
        {
            try
            {
                return Ok(_product.GetByID(ID));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post( Products product)
        {
            try
            {
                _product.Post(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Put{ID}")]
        public IActionResult Put(Guid ID, Products product)
        {
            try
            {
                _product.Put(ID, product);

                return Ok("The product has been changed!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

