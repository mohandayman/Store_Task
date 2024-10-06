using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implemetations
{

    public class EntityRepo<IEntity> : IEntityRepo<IEntity> where IEntity : class
    {
        private readonly StoreDbContext dbContext;
        private readonly DbSet<IEntity> _dbSet;

        public EntityRepo(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbSet = dbContext.Set<IEntity>();
        }
        public bool Add(IEntity entity)
        {
            dbContext.Set<IEntity>().Add(entity);
            dbContext.SaveChanges();
            return true;

        }

        public bool Delete(int Id)
        {
            var element = dbContext.Set<IEntity>().Find(Id);
            if (element != null)
            {
                dbContext.Set<IEntity>().Remove(element);
                return true;
            }
            return false;

        }

        public async Task<ICollection<IEntity>> GetAllNoTracking()
        {
            return await dbContext.Set<IEntity>().AsNoTracking().ToListAsync();

        }

        public async Task<IEntity> GetById(int Id)
        {
            return await dbContext.Set<IEntity>().FindAsync(Id);

        }

        public async Task<Result> UpdateAsync(int id, IEntity entity)
        {
            // Check for entity existence
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                return Result.Failure("Entity not found.");
            }

          
            dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

            try
            {
                await dbContext.SaveChangesAsync(); 
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Failure("The entity has been modified by another user.");
            }
            catch (Exception ex)
            {
                // Log exception
                return Result.Failure($"An error occurred while updating the entity: {ex.Message}");
            }
        }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result Success() => new Result { IsSuccess = true };
        public static Result Failure(string message) => new Result { IsSuccess = false, Message = message };
    }

}
