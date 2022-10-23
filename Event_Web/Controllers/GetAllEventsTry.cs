using Event_BLL.Abstract;
using Event_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Web.Controllers
{
    public class GetAllEventsTry : Controller
    {
        private readonly IEventService _eventService;

        public GetAllEventsTry(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IActionResult> ShowEmployees()
        {
            List<Event> listAllEmployees = await _eventService.GetAllEvents();
            return View(listAllEmployees);
        }
      
    }
}
