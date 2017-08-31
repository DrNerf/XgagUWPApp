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
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Login the user.
        /// </returns>
        Task<ISessionModel> Login(string username, string password);
    }
}
