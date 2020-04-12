using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAppUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public ActionResult<string> SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
                return decimalValue;

            return 0;
        }

        private bool IsNumeric(string number)
        {
            double numericNumber;

            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numericNumber);

            return isNumber;
        }
    }
}
