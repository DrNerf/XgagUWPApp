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
        Task<IEnumerable<T>> Get(int skip = 0, int take = 1);


        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        Task<T> GetById(int id);
    }
}
