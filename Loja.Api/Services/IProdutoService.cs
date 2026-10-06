using Loja.Api.Models;
using Loja.Api.Responses;

namespace Loja.Api.Services;

public interface IProdutoService
{
    Task<PagedResponse<Produto>> ObterTodos(
        string? nome,
        string? orderBy,
        string? orderDirection,
        int page,
        int pageSize
    );

    Task<Produto?> ObterPorId(int id);

    Task<Produto> Criar(Produto produto);

    Task<Produto?> Atualizar(int id, Produto produto);

    Task<bool> Excluir(int id);
}