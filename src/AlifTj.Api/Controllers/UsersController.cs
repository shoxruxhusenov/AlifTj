using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlifTj.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
    {
        try
        {
            var result = await _userService.CreateAsync(dto);

            return Ok(result);
        }
        catch (StatusCodeException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (StatusCodeException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        try
        {
            var delete = await _userService.DeleteAsync(id);
            return Ok(delete);
        }
        catch 
        { 
            throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "У вас нет доступа");
        }
    }
}
