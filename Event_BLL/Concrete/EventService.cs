using Event_BLL.Abstract;
using Event_DAL.Models;
using Event_DAL.Repositories.Abstract;
using Event_DAL.Repositories.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Event_BLL.Concrete
{
    public class EventService : GenericRepository<Event>, IEventService//,ControllerBase
    {
        //private readonly IGenericRepository<Event> _repository;
        Kariyer_ProjeContext _context;
        public EventService(/*IGenericRepository<Event> repository*/ Kariyer_ProjeContext context):base(context)
        {
            //_repository = repository;
        }

        public async Task<Event> GetEvent(int eventId)
        {
            return await GetGeneric(z=>z.EventId==eventId);
        }

        public new async Task<List<Event>> GetAllEvents()
        {
            var kariyer_ProjeContext = _context.Events.Where(u => u.UserId==User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(u => u.Category).Include(u => u.City);

            try
            {
                return await GetAllEventsGeneric().Where(u => u.UserId==User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch
            {
                throw;
            }
        }

        public async Task<Event> CreateEvent(Event addEvent)
        {
            return await CreateEventGeneric(addEvent);
        }

        public async Task<Event> UpdateEvent(Event updateEvent)
        {
            try
            {
                Event eventFound = await GetGeneric(c => c.EventId == updateEvent.EventId);

                if (eventFound == null)
                    throw new TaskCanceledException("The event does not exist");


                Event response = await EditEventGeneric(eventFound);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                Event eventFound = await GetGeneric(c => c.EventId == eventId);

                if (eventFound == null)
                    throw new TaskCanceledException("The event does not exist");


                bool response = await DeleteEventGeneric(eventFound);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
