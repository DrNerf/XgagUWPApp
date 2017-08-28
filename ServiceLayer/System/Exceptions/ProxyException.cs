using System;

namespace ServiceLayer
{
    /// <summary>
    /// Proxy Exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ProxyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class.
        /// </summary>
        public ProxyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        public ProxyException(Exception ex)
            : base(ex.Message, ex)
        {
        }
    }
}
