using BLL.Helper;
using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenericRepo
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class, new()
    {
        private readonly BDBContext _db;
        private readonly IQueryable<Tentity> _dbSet;

        public BaseRepository(BDBContext db) 
        {
            _db = db;
            _dbSet = _db.Set<Tentity>();
        }
        public async Task AddAsync(Tentity entity)
        {
            try
            {
                await _db.AddAsync(entity);

            }
            catch (Exception ex)
            {
                ExceptionLogger.Logs(ex.InnerException.Message);
            }

        }

        public bool Delete(Tentity entity)
        {
            try
            {
                 _db.Remove(entity);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionLogger.Logs(ex.InnerException.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> filter = null, Func<IQueryable<Tentity>, IQueryable<Tentity>> include = null)
        {
            IQueryable<Tentity> query = _dbSet;
            if(filter != null)
            {
                 query = query.Where(filter);
            }
            if(include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<Tentity> GetByAsync(Expression<Func<Tentity, bool>> filter = null, Func<IQueryable<Tentity>, IQueryable<Tentity>> include = null)
        {
            IQueryable<Tentity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task Save()
        {
            try
            {
                await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                ExceptionLogger.Logs(ex.InnerException.Message);
            }
        }

        public bool Update(Tentity entity)
        {
            try
            {
                 _db.Update(entity);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionLogger.Logs(ex.InnerException.Message);
                return false;
            }
        }
    }

    public interface IBaseRepository<Tentity> where Tentity : class, new()

    {
        public Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity,bool>> filter=null , Func<IQueryable<Tentity>,IQueryable<Tentity>> include=null);
        public Task<Tentity> GetByAsync(Expression<Func<Tentity,bool>> filter=null,Func<IQueryable<Tentity>,IQueryable<Tentity>> include=null);
        public Task Save();
        public Task AddAsync(Tentity entity);
        public bool Update(Tentity entity);
        public bool Delete(Tentity entity);


    }
}
