using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIFilmeStudy.Services;
public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private TokenService _tokenService;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = tokenService;
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

    public async Task<string> LoginAsync(SendLoginDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false,false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Usuario não autenticado!");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName.ToLower().Equals(dto.UserName.ToLower()));

        var token = _tokenService.GenerateToken(user);

        return token;
    }

}
