using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Base Proxy.
    /// </summary>
    internal class ProxyBase
    {
        /// <summary>
        /// Gets the base API address.
        /// </summary>
        protected string BaseApiAddress
        {
            get
            {
                return $"{RuntimeInfo.BaseWebsiteAddress}/api/";
            }
        }

        /// <summary>
        /// Safes the execute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <returns>The task executing the method.</returns>
        /// <exception cref="ServiceLayer.ProxyException"></exception>
        protected Task<T> SafeExecute<T>(Func<Task<T>> method)
        {
            try
            {
                return method?.Invoke();
            }
            catch (Exception ex)
            {
                throw new ProxyException(ex);
            }
        }

        /// <summary>
        /// Safes the execute.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The task of the method.</returns>
        /// <exception cref="ServiceLayer.ProxyException"></exception>
        protected Task SafeExecute(Func<Task> method)
        {
            try
            {
                return method?.Invoke();
            }
            catch (Exception ex)
            {
                throw new ProxyException(ex);
            }
        }

        /// <summary>
        /// Creates the HTTP client.
        /// </summary>
        /// <returns>The HTTP client.</returns>
        protected HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (RuntimeInfo.SessionInfo != null)
            {
                client.DefaultRequestHeaders.Add("SessionToken", RuntimeInfo.SessionInfo.SessionToken.ToString());
            }

            return client;
        }
    }
}
