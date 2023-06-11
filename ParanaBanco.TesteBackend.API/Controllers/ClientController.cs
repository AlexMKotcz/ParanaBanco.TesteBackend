using Microsoft.AspNetCore.Mvc;

using ParanaBanco.TesteBackend.Application.Interfaces.IService;

namespace ParanaBanco.TesteBackend.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
}
