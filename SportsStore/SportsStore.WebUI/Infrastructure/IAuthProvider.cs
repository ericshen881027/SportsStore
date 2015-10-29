namespace SportsStore.WebUI.Infrastructure
{
    public interface IAuthProvider
    {
        bool Authenticate(string name, string password);
    }
}