using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlifTj.Api.Controllers;
[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto dto)
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
}
