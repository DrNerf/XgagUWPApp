using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Authorization Proxy.
    /// </summary>
    public interface IAuthorizationProxy
    {
        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns>Login the user.</returns>
        Task Login(string username, string password);
    }
}
