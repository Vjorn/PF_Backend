namespace PlusForward.Backend.Data.Models;

public class ServerData
{
    public int Id { get; set; }
    public string? ServerId { get; set; }
    public string? IpAddress { get; set; }
    public string? ServerName { get; set; }
    public string? MapName { get; set; }
    public int CurrentPlayers { get; set; }
    public int MaxPlayers { get; set; }
}