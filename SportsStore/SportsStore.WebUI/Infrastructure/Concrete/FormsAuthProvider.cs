using System.Web.Security;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string name, string password)
        {
            var result = FormsAuthentication.Authenticate(name, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(name, false);
            }

            return result;
        }
    }
}