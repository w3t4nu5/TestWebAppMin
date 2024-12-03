using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestWebAppMin.DataAccess.DTO;
using TestWebAppMin.Services;
using TestWebAppMin.Services.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebAppMin.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController(ICustomerProvider _customerProvider) : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }


        [HttpGet("birthdayPeople")]
        public async Task<IActionResult> GetBirthdayPeople([FromQuery] BirthdayDto birthday)
        {
            IReadOnlyList<CustomerDto> birthdayPeople = await _customerProvider.GetCustomersByBirthday(birthday);

            return Ok(birthdayPeople);
        }

        [HttpGet("lastCustomers")]
        public async Task<IActionResult> GeLastCustomers([FromQuery][Range(1, int.MaxValue)] int daysCount)
        {
            IReadOnlyList<CustomerLastPurchaseDto> lastCustomers = await _customerProvider.GetCustomerLastPurchases(daysCount);

            return Ok(lastCustomers);
        }

        [HttpGet("preferredCategories")]
        public async Task<IActionResult> GeLastCustomers([FromQuery] Guid customerId)
        {
            IReadOnlyList<PurchasesPerCategoryDto> categories = await _customerProvider.GetCategoriesPurchasesCount(customerId);

            return Ok(categories);
        }
    }
}
