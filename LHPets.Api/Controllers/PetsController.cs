using LHPets.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private static readonly List<Pet> Pets = new();
    private static int _proximoId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<Pet>> Get()
    {
        return Ok(Pets);
    }

    [HttpPost]
    public ActionResult<Pet> Post([FromBody] Pet pet)
    {
        if (!ClientesController.Clientes.Any(c => c.Id == pet.ClienteId))
            return BadRequest($"Cliente com Id {pet.ClienteId} não existe.");

        pet.Id = _proximoId++;
        Pets.Add(pet);

        return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
    }

    [HttpGet("cliente/{clienteId:int}")]
    public ActionResult<IEnumerable<Pet>> GetPorCliente(int clienteId)
    {
        if (!ClientesController.Clientes.Any(c => c.Id == clienteId))
            return NotFound($"Cliente com Id {clienteId} não encontrado.");

        var pets = Pets.Where(p => p.ClienteId == clienteId).ToList();
        return Ok(pets);
    }
}
