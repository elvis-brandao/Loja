using Loja.Api.Data;
using Loja.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Loja.Api.Responses;

namespace Loja.Api.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProdutoService> _logger;

    public ProdutoService(
    AppDbContext context,
    ILogger<ProdutoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedResponse<Produto>> ObterTodos(
        string? nome,
        string? orderBy,
        string? orderDirection,
        int page,
        int pageSize
    )
    {
        var query = _context.Produtos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome))
        {
            query = query.Where(
                p => p.Nome.Contains(nome)
            );
        }

        var descending = orderDirection?.ToLower() == "desc";

        query = orderBy?.ToLower() switch
        {
            "nome" =>
                descending
                    ? query.OrderByDescending(p => p.Nome)
                    : query.OrderBy(p => p.Nome),

            "preco" =>
                descending
                    ? query.OrderByDescending(p => p.Preco)
                    : query.OrderBy(p => p.Preco),

            _ =>
                descending
                    ? query.OrderByDescending(p => p.Id)
                    : query.OrderBy(p => p.Id)
        };

        var totalItems =
            await query.CountAsync();

        var produtos =
            await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        return new PagedResponse<Produto>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages =
                (int)Math.Ceiling(
                    totalItems / (double)pageSize),

            Data = produtos
        };
    }

    public async Task<Produto?> ObterPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<Produto> Criar(Produto produto)
    {
        _logger.LogInformation(
            "Iniciando cadastro do produto {Nome}",
            produto.Nome);

        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Produto cadastrado com sucesso. Id {Id}",
            produto.Id);

        return produto;
    }

    public async Task<Produto?> Atualizar(int id, Produto produtoAtualizado)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;

        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task<bool> Excluir(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return false;
        }

        _context.Produtos.Remove(produto);

        await _context.SaveChangesAsync();

        return true;
    }
}