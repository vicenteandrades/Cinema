namespace APIFilmeStudy.Profile;

using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
public class CinemaProfile : Profile
{
	public CinemaProfile()
	{
		CreateMap<Cinema, SendCinemaDto>().ReverseMap();
		CreateMap<Cinema, ReadCinemaDto>().ReverseMap();
	}
}
