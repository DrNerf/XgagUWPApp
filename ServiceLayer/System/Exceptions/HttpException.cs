using System;
using System.Net;

namespace ServiceLayer
{
    /// <summary>
    /// Http Exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class HttpException : Exception
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the reason phrase.
        /// </summary>
        public string ReasonPhrase { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="reasonPhrase">The reason phrase.</param>
        public HttpException(HttpStatusCode statusCode, string reasonPhrase)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }
    }
}
