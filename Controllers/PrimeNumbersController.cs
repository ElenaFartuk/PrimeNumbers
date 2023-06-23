using Microsoft.AspNetCore.Mvc;

namespace PrimeNumbersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeNumbersController : ControllerBase
    {
        [HttpGet("{n}")]
        public ActionResult<IEnumerable<int>> GetPrimeNumbers(int n)
        {
            if (1 > n || n > 100)
                return BadRequest("Invalid input for n. Please provide an integer between 1 and 100.");

            List<int> primeNumbers = new List<int>();
            int count = 0;
            int number = 2;

            while (count < n)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                    count++;
                }
                number++;
            }
            primeNumbers.Sort();
            primeNumbers.Reverse();

            return Ok(primeNumbers);

        }
        private static bool IsPrime(int number)
        {
            if (number <=1) // Prime numbers could be only numbers greater than 1
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
