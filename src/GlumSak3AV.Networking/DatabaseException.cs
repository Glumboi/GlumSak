namespace GlumSak3AV.Networking;

[Serializable]
public class DatabaseException : Exception
{
    public DatabaseException(string message) : base(message)
    { }
}