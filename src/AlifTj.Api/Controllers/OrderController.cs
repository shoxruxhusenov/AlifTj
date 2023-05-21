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

            return Ok($"{result.Item1}\n{result.Item2}");
        }
        catch
        {
            throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "Введенная вами информация добавлена ​​в базу данных \"Но ваш лимит на отправку SMS-сообщений на номер телефона истек");

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
