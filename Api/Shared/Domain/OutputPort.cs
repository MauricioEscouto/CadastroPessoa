using Api.Shared.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Shared.Domain
{
    public class OutputPort : ControllerBase, IOutputPort
    {
        public IActionResult InvalidRequest(object obj)
        {
            return BadRequest(obj);
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
