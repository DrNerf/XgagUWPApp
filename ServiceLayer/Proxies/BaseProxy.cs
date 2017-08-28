﻿using System;
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
        /// Safes the execute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <returns>The task executing the method.</returns>
        /// <exception cref="ServiceLayer.ProxyException"></exception>
        protected Task<T> SafeExecute<T>(Func<T> method)
        {
            try
            {
                return Task.Factory.StartNew(method);
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
        protected Task SafeExecute(Action method)
        {
            try
            {
                return Task.Factory.StartNew(method);
            }
            catch (Exception ex)
            {
                throw new ProxyException(ex);
            }
        }

        protected HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //if (m_UserSession.SessionToken != default(Guid))
            //{
            //    client.DefaultRequestHeaders.Add("SessionToken", m_UserSession.SessionToken.ToString());
            //}

            return client;
        }
    }
}
