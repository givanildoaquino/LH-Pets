using LHPets.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    public static readonly List<Cliente> Clientes = new();
    private static int _proximoId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        return Ok(Clientes);
    }

    [HttpPost]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        if (Clientes.Any(c => c.Cpf == cliente.Cpf))
            return Conflict("Já existe um cliente cadastrado com esse CPF.");

        cliente.Id = _proximoId++;
        Clientes.Add(cliente);

        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }
}
