using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Event_DAL.Models;
using Event_DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_DAL.Repositories.Concrete
{
    public class GenericRepository<TModel> :ControllerBase, IGenericRepository<TModel> where TModel : class
    {

        private readonly Kariyer_ProjeContext _dbcontext;
        public GenericRepository(Kariyer_ProjeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TModel> GetGeneric(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel entity = await _dbcontext.Set<TModel>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch
            {
                throw;
            }
        }
        public IQueryable<TModel> GetAllEventsGeneric()
        {
            var kariyer_ProjeContext = _dbcontext.Events.Include(u => u.Category).Include(u => u.City);

            try
            {
                return  _dbcontext.Set<TModel>().AsNoTracking();
            }
            catch
            {
                throw;
            }
        }
        //public async Task<TModel> GetAllEventsGeneric()
        //{
            
        //}
        public async Task<TModel> CreateEventGeneric(TModel addEvent)
        {
            _dbcontext.Set<TModel>().Add(addEvent);
            await _dbcontext.SaveChangesAsync();
            return addEvent;
        }

        public async Task<TModel> EditEventGeneric(TModel editEvent)
        {
            _dbcontext.Set<TModel>().Update(editEvent);
            await _dbcontext.SaveChangesAsync();
            return editEvent;
        }

        public async Task<bool> DeleteEventGeneric(TModel deleteEvent)
        {
            try
            {
                _dbcontext.Set<TModel>().Remove(deleteEvent);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new ArgumentException("Could not delete.");
            }
        }

       
    }
}
