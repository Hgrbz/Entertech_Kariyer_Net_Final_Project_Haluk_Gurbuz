using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Event_BLL.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Event_BLL.Abstract;

namespace Event_Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly Kariyer_ProjeContext _context;
        //Event_WebUser event_WebUser;
        public EventsController(IEventService eventService, Kariyer_ProjeContext context)
        {
            _eventService = eventService;
            _context = context;          
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {

            var listAllEmployees = _eventService.GetAllEventsGeneric();
            return View(listAllEmployees);
            //var kariyer_ProjeContext = _context.Events.Include(u => u.Category).Include(u => u.City);
            //return View(await kariyer_ProjeContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events
                .Include(u => u.Category)
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }
        // GET: Events/Create
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoriyName");
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["Id"]=User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _eventService.CreateEvent(@event);
                //@event.UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);

                //_context.Add(@event);
                //await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoriyName", @event.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", @event.CityId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @event.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @event.CityId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    @event.UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);

                    await _eventService.UpdateEvent(@event);
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @event.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @event.CityId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events
                .Include(u => u.Category)
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEvent(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return _context.Events.Any(e => e.EventId == id);
        }
    }
}
