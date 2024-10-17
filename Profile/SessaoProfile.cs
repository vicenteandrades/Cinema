namespace APIFilmeStudy.Profile;

using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
public class SessaoProfile : Profile
{
	public SessaoProfile()
	{
		CreateMap<ReadSessaoDto, Sessao>().ReverseMap();
		CreateMap<SendSessaoDto, Sessao>().ReverseMap();
	}
}
