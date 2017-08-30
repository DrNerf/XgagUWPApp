using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Authorization Proxy.
    /// </summary>
    /// <seealso cref="ServiceLayer.ProxyBase" />
    /// <seealso cref="ServiceLayer.IAuthorizationProxy" />
    internal class AuthorizationProxy : ProxyBase, IAuthorizationProxy
    {
        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Login the user.
        /// </returns>
        public Task Login(string username, string password)
        {
            return SafeExecute(async () => 
            {
                using (var client = CreateHttpClient())
                {
                    var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("UserName", username),
                        new KeyValuePair<string, string>("Password", password),
                        new KeyValuePair<string, string>("RememberMe", false.ToString()),
                    });

                    var response = await client.PostAsync($"{BaseApiAddress}auth/login", content);
                    var result = await response.Content.ReadAsStringAsync();
                    var session = JsonConvert.DeserializeObject<SessionModel>(result);
                    RuntimeInfo.SessionInfo = session;
                }
            });
        }
    }
}
