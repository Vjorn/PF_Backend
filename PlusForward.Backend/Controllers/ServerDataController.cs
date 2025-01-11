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
        string result = await _serverDataService.AddNewServerEntry(serverDataDto, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveServerEntry(CancellationToken cancellationToken)
    {
        bool success = await _serverDataService.RemoveServerEntry(cancellationToken);
        return Ok(success);
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