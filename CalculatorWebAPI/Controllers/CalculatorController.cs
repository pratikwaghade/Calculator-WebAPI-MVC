using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add(double num1 , double num2)
        {
            return Ok(num1 + num2);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double num1, double num2)
        {
            return Ok(num1 - num2);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double num1, double num2)
        {
            return Ok(num1 * num2);
        }

        [HttpGet("divide")]
        public IActionResult Divide(double num1, double num2)
        {
            if(num2 == 0)
            {
                return BadRequest("Cannot divide by zero");
            }

            return Ok(num1 / num2);
        }

    }
}
