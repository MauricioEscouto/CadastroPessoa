using Microsoft.AspNetCore.Mvc;

namespace Api.Shared.Domain.Abstractions
{
    public interface IOutputPort
    {
        IActionResult InvalidRequest(object obj);
        IActionResult Success(object obj);
        IActionResult NotFound(string message);
        IActionResult StatusCode(int statusCode, object obj);
    }
}
