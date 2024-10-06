using DAL.Repositories.Implemetations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IEntityRepo<IEntity>
    {
        public Task<ICollection<IEntity>> GetAllNoTracking();
        public Task<IEntity> GetById(int Id);
        public bool Add(IEntity entity);
        public Task<Result> UpdateAsync(int id, IEntity entity);
        public bool Delete(int Id);

    }
}
