using Loja.Api.Data;
using Loja.Api.DTOs;
using Loja.Api.Models;
using Loja.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(
        string? nome,
        string? orderBy,
        string? orderDirection,
        int page = 1,
        int pageSize = 10
    )
    {
        if (!string.IsNullOrWhiteSpace(orderBy) &&
            orderBy.ToLower() != "nome" &&
            orderBy.ToLower() != "preco"
        )
        {
            return BadRequest(
                "O parâmetro orderBy deve ser 'nome' ou 'preco'."
            );
        }

        if (!string.IsNullOrWhiteSpace(orderDirection) &&
            orderDirection.ToLower() != "asc" &&
            orderDirection.ToLower() != "desc")
        {
            return BadRequest(
                "O parâmetro orderDirection deve ser 'asc' ou 'desc'."
            );
        }

        var produtos =
            await _produtoService.ObterTodos(
                nome,
                orderBy,
                orderDirection,
                page,
                pageSize
            );

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoService.ObterPorId(id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoCreateDto dto)
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco
        };

        var produtoCriado =
            await _produtoService.Criar(produto);

        return Ok(produtoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        int id,
        ProdutoUpdateDto dto)
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco
        };

        var produtoAtualizado =
            await _produtoService.Atualizar(id, produto);

        if (produtoAtualizado == null)
        {
            return NotFound();
        }

        return Ok(produtoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var excluido =
            await _produtoService.Excluir(id);

        if (!excluido)
        {
            return NotFound();
        }

        return NoContent();
    }
}