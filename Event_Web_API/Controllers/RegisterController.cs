using Event_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Event_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {


        private readonly Kariyer_ProjeContext _dataContext;

        public RegisterController(Kariyer_ProjeContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public ActionResult<Company> Register([Bind("CompanyName,Domain,Email,Password")] Company company)
        {

            var companies = _dataContext.Companies.ToList();
            string isExist = "not exist";

            for (int i = 0; i < companies.Count; i++)
            {
                if (company.Email==companies[i].Email || company.Domain==companies[i].Domain)
                {
                    isExist="exist";

                }
            }

            if (isExist!="exist")
            {
                _dataContext.Companies.Add(company);
                _dataContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}

