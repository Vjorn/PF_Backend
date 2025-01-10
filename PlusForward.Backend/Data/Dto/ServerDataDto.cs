namespace PlusForward.Backend.Data.Dto;

public class ServerDataDto
{
    public string IpAddress { get; set; } = "127.0.0.1";
    public string ServerName { get; set; } = "SERVER NAME";
    public string MapName { get; set; } = "MAP NAME";
    public int MaxPlayers { get; set; }
}