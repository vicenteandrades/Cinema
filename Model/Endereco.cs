using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.Model;
public class Endereco
{
    [Key]
    public int EnderecoId { get; set; }
    [Required]
    public string? Logradouro { get; set; }
    public int Numero { get; set; }
}

