using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlifTj.Api.Controllers;


[ApiController]
[Route("[controller]")]

public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeService _service;

    public ProductTypeController(IProductTypeService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductTypeCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);

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
            var users = await _service.GetAllAsync();
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
            var delete = await _service.DeleteAsync(id);
            return Ok(delete);
        }
        catch
        {
            throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "У вас нет доступа");
        }
    }

}
