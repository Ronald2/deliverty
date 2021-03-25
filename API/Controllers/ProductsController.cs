using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        public string GetProducts()
        {
            return "This will return a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Single Item";
        }
    }
}