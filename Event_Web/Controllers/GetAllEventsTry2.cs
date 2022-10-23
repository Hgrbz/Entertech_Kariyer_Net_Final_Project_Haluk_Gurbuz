using Event_BLL.Abstract;
using Event_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Event_Web.Controllers
{
    public class GetAllEventsTry2 : Controller
    {
        private readonly IEventService _eventService;
        private readonly Kariyer_ProjeContext _context;
        public GetAllEventsTry2(IEventService eventService,Kariyer_ProjeContext context)
        {
            _eventService = eventService;
            _context= context;
        }
        [Authorize(Roles = "User")]
        //public async Task<IActionResult> ShowEmployees()
        //{
        //    List<Event> listAllEmployees = await _eventService.GetAllEvents();
        //    return View(listAllEmployees);
        //}
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoriyName");
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["Id"]=User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();

            
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(Event @event)
        {
           
            
                @event.UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _eventService.CreateEvent(@event);
                //@event.UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);

                //_context.Add(@event);
                //await _context.SaveChangesAsync();
                return RedirectToAction("ShowEmployees");
            
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoriyName", @event.CategoryId);
            //ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", @event.CityId);
            //return View(@event);
        }

    }
}
