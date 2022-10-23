using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event_DAL.Repositories.Abstract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> GetGeneric(Expression<Func<TModel, bool>> filter);

        Task<List<TModel>> GetAllEventsGeneric();
        Task<TModel> CreateEventGeneric(TModel addEvent);

        Task<TModel> EditEventGeneric(TModel editEvent);
        Task<bool> DeleteEventGeneric(TModel deleteEvent);
       



    }
}
