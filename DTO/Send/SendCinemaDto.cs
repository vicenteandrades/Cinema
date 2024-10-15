using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Send;
public class SendCinemaDto
{
    [Required]
    public string? Nome { get; set; }
}

