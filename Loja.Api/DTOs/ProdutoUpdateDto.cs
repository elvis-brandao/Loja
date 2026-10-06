using System.ComponentModel.DataAnnotations;

namespace Loja.Api.DTOs;

public class ProdutoUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Preco { get; set; }
}