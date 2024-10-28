using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using APIFilmeStudy.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/create")]
    public async Task<ActionResult> PostAsync([FromBody] SendUserDto dto)
    {
        if (!ModelState.IsValid)
        { 
            return BadRequest(ModelState);
        }

        await _userService.CreateUserAsync(dto);
        return Ok("Criado com sucesso");
    }

    [HttpPost("/login")]

    public async Task<ActionResult> PostLoginAsync([FromBody] SendLoginDto dto)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        var token = await _userService.LoginAsync(dto);
        return Ok(token);

    }

}

