using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Send;
public class SendEnderecoDto
{
    [Required]
    public string? Logradouro { get; set; }
    public int Numero { get; set; }
}

