using System.Text.RegularExpressions;
using PlusForward.Backend.Data.Dto;
using PlusForward.Backend.Services;

namespace PlusForward.Backend.Extensions;

public static class ServerDataDtoExtension
{
    public static bool ServerDataDtoCheck(this ServerDataDto serverDataDto, ILogger<ServerDataService> logger)
    {
        const string ipAddressRegexPattern = @"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\."
                                                 + @"(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\."
                                                 + @"(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\."
                                                 + "(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$";

        Regex ipAddressRegex = new Regex(ipAddressRegexPattern, RegexOptions.Compiled);
        
        if (!ipAddressRegex.IsMatch(serverDataDto.IpAddress))
        {
            logger.Log(LogLevel.Error, "Input new server entry IP Address ({IpAddress}) is not valid", serverDataDto.IpAddress);
            return false;
        }

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