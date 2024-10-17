using APIFilmeStudy.Model;
using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Send;
public class SendSessaoDto
{
    [Required]
    public int CinemaId { get; set; }
    [Required]
    public int FilmeId { get; set; }
}

