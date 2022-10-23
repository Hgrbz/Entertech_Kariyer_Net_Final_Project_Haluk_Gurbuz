using Event_DAL.Models;
using Event_DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_BLL.Abstract
{
    public interface IEventService:IGenericRepository<Event>
    {
        Task<Event> GetEvent(int eventId);
        Task<List<Event>> GetAllEvents();
        Task<Event> CreateEvent(Event addEvent);
        Task<Event> UpdateEvent(Event updateEvent);
        Task<bool> DeleteEvent(int eventId);
    }
}
