namespace APIFilmeStudy.Profile;

using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using AutoMapper;
public class EnderecoProfile : Profile
{
	public EnderecoProfile()
	{
		CreateMap<Endereco, SendEnderecoDto>().ReverseMap();
		CreateMap<Endereco, ReadEnderecoDto>().ReverseMap();
	}
}

