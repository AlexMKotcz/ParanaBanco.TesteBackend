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

    /// <summary>
    /// Creates a Client in the database.
    /// </summary>
    /// <remarks>
    /// Example:
    /// 
    ///     POST /Clients/AddClient
    ///     {
    ///       "fullName": "Alex Mariano Kotcz",
    ///       "email": {
    ///         "email": "alexmariano129@gmail.com"
    ///       },
    ///       "phones": [
    ///         {
    ///           "ddd": 41,
    ///           "number": "988257783",
    ///           "type": "Mobile"
    ///         }
    ///       ]
    ///     }
    /// 
    /// </remarks>
    /// <param name="client"></param>
    /// <returns>The added client</returns>
    /// <response code="201">Returns the added client</response>
    /// <response code="400">If the client isn't created, returns the validation message</response>
    [HttpPost("AddClient")]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InsertClient(ClientRequest client)
    {
        return Created("Clients/{id}", await _clientService.Add(client));
    }

    /// <summary>
    /// Gets all clients in database, including their phones.
    /// </summary>
    /// <remarks>
    /// Example:
    /// 
    ///     Get /Clients
    /// 
    /// </remarks>
    /// <returns>All clients in database, including their phones</returns>
    /// <response code="200">Returns all clients in database, including their phones</response>
    [HttpGet]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClients()
    {
        return Ok(await _clientService.GetClients());
    }

    /// <summary>
    /// Gets all clients which at least one phone contains the parameters.
    /// </summary>
    /// <remarks>
    /// Example:
    /// 
    ///     Get /Clients/ByPhone?ddd=41&amp;number=88257783
    /// 
    /// </remarks>
    /// <param name="ddd">The client's phone DDD</param>
    /// <param name="number">The client's phone string</param>
    /// <returns>All clients which at least one phone contains the parameters</returns>
    /// <response code="200">Returns all clients which at least one phone contains the parameters</response>
    [HttpGet("ByPhone")]
    [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientsByPhone(int ddd, string number)
    {
        return Ok(await _clientService.GetByFullPhone(ddd, number));
    }

    /// <summary>
    /// Updates a given client email.
    /// </summary>
    /// <remarks>
    /// Example:
    /// 
    ///     Patch /Clients/UpdateEmail?clientId=4
    ///     {
    ///       "email": "alexmariano129@gmail.com"
    ///     }
    /// 
    /// </remarks>
    /// <param name="clientId">The client's id</param>
    /// <param name="email">The client's email</param>
    /// <returns>The new email of the client</returns>
    /// <response code="200">The client's email has been updated.</response>
    /// <response code="400">The request email is invalid.</response>
    /// <response code="404">The given clientId does not exists.</response>
    [HttpPatch("UpdateEmail")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateClientEmail(int clientId, EmailParameter email)
    {
        await _clientService.UpdateEmail(clientId, email);
        return Ok(email.ToString());
    }

    /// <summary>
    /// Updates a given client phone List.
    /// Client phones which are not in the request will be deleted.
    /// </summary>
    /// <remarks>
    /// Client phones which are not in the request will be deleted.
    /// Example:
    /// 
    ///     Patch /Clients/UpdatePhones?clientId=4
    ///     [
    ///         {
    ///             "ddd": 41,
    ///             "number": "988257783",
    ///             "type": "Mobile"
    ///         },
    ///         {
    ///             "ddd": 41,
    ///             "number": "30571395",
    ///             "type": "Landline"
    ///         },
    ///     ]
    /// 
    /// </remarks>
    /// <param name="clientId">The client's id</param>
    /// <param name="phones">The client's all-phones list</param>
    /// <returns>The new phone list of the client</returns>
    /// <response code="200">The client's phone list has been updated.</response>
    /// <response code="400">The request phone list is invalid.</response>
    /// <response code="404">The given clientId does not exists.</response>
    [HttpPatch("UpdatePhones")]
    [ProducesResponseType(typeof(IEnumerable<PhoneRequest>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateClientPhones(int clientId, IEnumerable<PhoneRequest> phones)
    {
        await _clientService.UpdatePhones(clientId, phones);
        return Ok(phones);
    }

    /// <summary>
    /// Deletes a client given his email.
    /// </summary>
    /// <remarks>
    /// Example:
    /// 
    ///     Delete /Clients/DeleteByEmail
    ///     {
    ///       "email": "user@example.com"
    ///     }
    /// 
    /// </remarks>
    /// <param name="email">The email of the client that will be deleted</param>
    /// <returns></returns>
    /// <response code="200">The client with the request email has been deleted.</response>
    /// <response code="400">The request email is invalid.</response>
    /// <response code="404">There is not a client with the given email.</response>
    [HttpDelete("DeleteByEmail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClientByEmail(EmailParameter email)
    {
        await _clientService.RemoveByEmail(email);
        return Ok();
    }

}
