using System.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PlusForward.Backend.Data;
using PlusForward.Backend.Data.Dto;
using PlusForward.Backend.Data.Models;
using PlusForward.Backend.Extensions;

namespace PlusForward.Backend.Services;

public class ServerDataService
{
    private readonly IConfiguration _config;
    private readonly PlusForwardDbContext _db;
    private readonly ILogger<ServerDataService> _logger;

    public ServerDataService(IConfiguration config, PlusForwardDbContext db, ILogger<ServerDataService> logger)
    {
        _config = config;
        _db = db;
        _logger = logger;
    }

    public async Task<bool> TryAddNewServerEntry(ServerDataDto serverDataDto, CancellationToken cancellationToken)
    {
        bool success = false;
        bool serverDataDtoCheck = serverDataDto.ServerDataDtoCheck(_logger);
        
        if (!serverDataDtoCheck)
        {
            return success;
        }
        
        MySqlConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        try
        {
            await connection.OpenAsync(cancellationToken);

            MySqlCommand command = new MySqlCommand("AddServerEntry", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("_ServerId", Guid.NewGuid().ToString("N"));
            command.Parameters.AddWithValue("_IpAddress", serverDataDto.IpAddress);
            command.Parameters.AddWithValue("_ServerName", serverDataDto.ServerName);
            command.Parameters.AddWithValue("_MapName", serverDataDto.MapName);
            command.Parameters.AddWithValue("_CurrentPlayers", 0);
            command.Parameters.AddWithValue("_MaxPlayers", serverDataDto.MaxPlayers);

            await command.ExecuteNonQueryAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.Log(LogLevel.Error, exception.Message);
            return success;
        }
        finally
        {
            success = true;
            await connection.CloseAsync();
        }

        return success;
    }

    public async Task<List<ServerData>> GetAllServerData(CancellationToken cancellationToken)
    {
        return await _db.ServersData.ToListAsync(cancellationToken);
    }
    
    public async Task<ServerData> GetServerData(string serverId, CancellationToken cancellationToken)
    {
        return await _db.ServersData.Where(x => x.ServerId == serverId).FirstAsync(cancellationToken);
    }
}