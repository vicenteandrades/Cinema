using APIFilmeStudy.Model;
using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Read;
public class ReadSessaoDto
{
    public int CinemaId { get; set; }
    public ReadCinemaDto? Cinema { get; set; }
    public int FilmeId { get; set; }
    public ReadFilmeDto? Filme { get; set; }
}

