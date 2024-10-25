using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Send;
public class SendLoginDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}

