using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIFilmeStudy.Services;
public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }


    public async Task CreateUserAsync(SendUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded) 
        {
            throw new ApplicationException("Erro ao cadastrar usuario");
        }
    }

    public async Task LoginAsync(SendLoginDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false,false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Usuario não autenticado!");
        }
    }

}
