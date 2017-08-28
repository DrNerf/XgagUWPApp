using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal class AuthorizationProxy : ProxyBase, IAuthorizationProxy
    {
        public Task Login(string username, string password)
        {
            return SafeExecute(() => 
            {
                using (var client = CreateHttpClient())
                {
                    
                }
            });
        }
    }
}
