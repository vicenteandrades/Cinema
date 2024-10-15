namespace APIFilmeStudy.Profile;

using APIFilmeStudy.DTO;
using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.Model;
using AutoMapper;
public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<Filme, ReadFilmeDto>().ReverseMap();
		CreateMap<Filme, SendFilmeDto>().ReverseMap();
	}
}

