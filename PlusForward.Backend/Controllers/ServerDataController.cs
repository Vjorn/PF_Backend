using Microsoft.AspNetCore.Mvc;
using PlusForward.Backend.Data.Dto;
using PlusForward.Backend.Data.Models;
using PlusForward.Backend.Services;

namespace PlusForward.Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ServerDataController : ControllerBase
{
    private readonly ServerDataService _serverDataService;
    
    public ServerDataController(ServerDataService serverDataService)
    {
        _serverDataService = serverDataService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewServerEntry(ServerDataDto serverDataDto, CancellationToken cancellationToken)
    {
        bool result = await _serverDataService.TryAddNewServerEntry(serverDataDto, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServerData(CancellationToken cancellationToken)
    {
        List<ServerData> serverData = await _serverDataService.GetAllServerData(cancellationToken);
        return Ok(serverData);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetServerData(string serverId, CancellationToken cancellationToken)
    {
        ServerData serverData = await _serverDataService.GetServerData(serverId, cancellationToken);
        return Ok(serverData);
    }
}