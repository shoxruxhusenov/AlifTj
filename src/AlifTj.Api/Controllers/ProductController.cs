using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlifTj.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
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

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
        catch
        {
            throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "У вас нет доступа");

        }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {

        try
        {
            var get = await _service.GetAllAsync();
            return Ok(get);
        }
        catch
        {
            throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "Что-то пошло не так, проверьте информацию");

        }
    }
}
