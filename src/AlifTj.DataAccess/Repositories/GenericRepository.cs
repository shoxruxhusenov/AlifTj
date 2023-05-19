using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces;
using AlifTj.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories
{
    public class GenericRepository<T>: BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDb): base(appDb) { }

        public IQueryable<T> GetAll() => _dbSet;

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) 
            => _dbSet.Where(predicate);

    }

}
