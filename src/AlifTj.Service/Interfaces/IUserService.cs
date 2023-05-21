using AlifTj.Service.Dtos;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<UserViewModel>> GetAllAsync();
    public Task<bool> CreateAsync(UserCreateDto dto);
    public Task<bool> DeleteAsync(long id);
}
