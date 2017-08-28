using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Restful proxy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRestfulProxy<T>
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items.</returns>
        Task<IEnumerable<T>> Get();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        Task<T> Get(int id);
    }
}
