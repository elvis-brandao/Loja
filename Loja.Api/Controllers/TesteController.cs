using Loja.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TesteController : ControllerBase
{
    private readonly AppDbContext _context;

    public TesteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var produtos = _context.Produtos.ToList();

            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}