using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
	private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SendUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
    
        return (result.Succeeded) ? Ok("Criado com sucesso") : BadRequest(ModelState);
    }

}

