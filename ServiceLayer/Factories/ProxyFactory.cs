namespace ServiceLayer
{
    /// <summary>
    /// Proxy Factory.
    /// </summary>
    public class ProxyFactory
    {
        private static ProxyFactory m_Instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ProxyFactory Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ProxyFactory();
                }

                return m_Instance;
            }
        }

        private ProxyFactory()
        {

        }

        public IAuthorizationProxy CreateAuthorizationProxy()
        {
            return new AuthorizationProxy();
        }
    }
}
