namespace RaptoRCon.Games
{
    public interface IGameConnectionInfo
    {
        string HostName { get; }

        int Port { get; }

        string Password { get; }
    }
}
