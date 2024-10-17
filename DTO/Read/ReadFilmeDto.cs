using APIFilmeStudy.Model;
using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Read;
public class ReadFilmeDto
{
    
    public string? Titulo { get; set; }
    public string Genero { get; set; }
   
    public int Duracao { get; set; }
    public ICollection<ReadSessaoDto>? Sessoes { get; set; }

}

