using Microsoft.AspNetCore.Mvc;

namespace Web.Shared.Domain
{
    public class OutputPort : ControllerBase
    {
        public IActionResult InvalidRequest()
        {
            return BadRequest();
        }

        public IActionResult NotFound(string message)
        {
            return base.NotFound(message);
        }

        public IActionResult Success(object obj)
        {
            return Ok(obj);
        }

        public IActionResult StatusCode(int statusCode, object obj)
        {
            return base.StatusCode(statusCode, obj);
        }
    }
}
