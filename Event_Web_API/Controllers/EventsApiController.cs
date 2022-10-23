using Event_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsApiController : ControllerBase
    {


        private readonly Kariyer_ProjeContext _dataContext;

        public EventsApiController(Kariyer_ProjeContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Event> Get()
        {
            //var categoryNames = (from c in _dataContext.Categories
            //             join e in _dataContext.Events
            //                 on c.CategoryId equals e.CategoryId
            //             select new { CategoryName = c.CategoriyName }).ToList();

            //var cityNames = (from c in _dataContext.Cities
            //                     join e in _dataContext.Events
            //                         on c.CityId equals e.CityId
            //                     select new { CityName = c.CityName }).ToList();

            var events = _dataContext.Events;

            return Ok(events.Where(a=>a.TicketFee>0).ToList());
        }
    }
}
