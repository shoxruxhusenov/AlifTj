using AlifTj.Domain.Common;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public void Add(T entity);

        public Task<T?> FindByIdAsync(long id);

        public void Delete(long id);

        public void Update(long id,T entity);

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

    }
}
