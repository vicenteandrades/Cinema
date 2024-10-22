namespace APIFilmeStudy.Profile;

using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<SendUserDto, User>().ReverseMap();
	}
}

