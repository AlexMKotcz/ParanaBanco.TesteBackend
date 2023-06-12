using Microsoft.AspNetCore.Mvc;
using ParanaBanco.TesteBackend.Application.Contracts.Parameters;
using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;
using ParanaBanco.TesteBackend.Application.Interfaces;

namespace ParanaBanco.TesteBackend.API.Controllers;

[Route("Clients")]
[Produces("application/json")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("AddClient")]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> InsertClient(ClientRequest client)
    {
        return Created("Clients/{id}", await _clientService.Add(client));
    }

    [HttpGet]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClients()
    {
        return Ok(await _clientService.GetClients());
    }

    [HttpGet("ByPhone")]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientsByPhone(int ddd, string number)
    {
        return Ok(await _clientService.GetByFullPhone(ddd, number));
    }

    [HttpPatch("UpdateEmail")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateClientEmail(int clientId, EmailParameter email)
    {
        await _clientService.UpdateEmail(clientId, email);
        return Ok(email.ToString());
    }

    [HttpPatch("UpdatePhones")]
    [ProducesResponseType(typeof(IEnumerable<PhoneRequest>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateClientPhones(int clientId, IEnumerable<PhoneRequest> phones)
    {
        await _clientService.UpdatePhones(clientId, phones);
        return Ok(phones);
    }

    [HttpDelete("DeleteByEmail")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteClientByEmail(EmailParameter email)
    {
        await _clientService.RemoveByEmail(email);
        return Ok(email.ToString());
    }

}
