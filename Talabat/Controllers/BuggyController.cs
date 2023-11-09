using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Errors;
using Talabat.Repository.Data;

namespace Talabat.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _dbContext;

        public BuggyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var product = _dbContext.Products.Find(100);
            if (product == null) 
                return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var productToReturn = product.ToString();

            return Ok(productToReturn);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]

        public ActionResult GerBadRequest(int id) //Validation Error
        {
            return Ok();
        }


        [HttpGet("unauthorized")]
        public ActionResult GerUnauthorizedError()
        {
            return Unauthorized(new ApiResponse(401));
        }
    }
}
