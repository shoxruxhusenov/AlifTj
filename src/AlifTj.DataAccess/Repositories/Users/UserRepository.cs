using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces.Users;
using AlifTj.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories.Users
{
    public class UserRepository: GenericRepository<User>,IUserRepository
    {
        public UserRepository(AppDbContext context): base(context) { }
    }
}
