using System.Text.RegularExpressions;
using PlusForward.Backend.Data.Dto;
using PlusForward.Backend.Services;

namespace PlusForward.Backend.Extensions;

public static class ServerDataDtoExtension
{
    public static bool ServerDataDtoCheck(this ServerDataDto serverDataDto, ILogger<ServerDataService> logger)
    {
        if (string.IsNullOrEmpty(serverDataDto.ServerName))
        {
            logger.Log(LogLevel.Error, "Input new server entry Server Name is empty");
            return false;
        }
        
        if (string.IsNullOrEmpty(serverDataDto.MapName))
        {
            logger.Log(LogLevel.Error, "Input new server entry Map Name is empty");
            return false;
        }
        
        serverDataDto.MaxPlayers = int.Clamp(serverDataDto.MaxPlayers, 0, 32);
        return true;
    }
}