using AlifTj.DataAccess.Interfaces;
using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _work;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._work = unitOfWork;
        }

        public async Task<bool> CreateAsync(UserCreateDto dto)
        {
            var entity = await _work.Users.FirstOrDefaultAsync(x => x.PhoneNumber == dto.PhoneNumber);
            if (entity != null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "номер телефона уже существует");

            var user = (User)dto;
            _work.Users.Add(user);

            var result = await _work.SaveChangesAsync();
            return result > 0;
        }
        public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<UserViewModel>> GetAllAsync() => throw new NotImplementedException();
        public Task<UserViewModel> GetAsyncById(long id) => throw new NotImplementedException();
        public Task<bool> UpdateAsync(long id, UserCreateDto dto) => throw new NotImplementedException();
    }
}
