using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace XgagUWPApp
{
    /// <summary>
    /// Incremental Observable Collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.ObjectModel.ObservableCollection{T}" />
    /// <seealso cref="Windows.UI.Xaml.Data.ISupportIncrementalLoading" />
    public class IncrementalObservableCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private bool m_Busy;
        private Func<bool> m_HasMoreItems;
        private Func<uint, Task<IEnumerable<T>>> m_LoadMoreItemsFunc;
        private Func<uint, Task<LoadMoreItemsResult>> m_LoadMoreItemsTask;

        /// <summary>
        /// Initializes incremental loading from the view.
        /// </summary>
        /// <param name="count">The number of items to load.</param>
        /// <returns>
        /// The wrapped results of the load operation.
        /// </returns>
        /// <exception cref="InvalidOperationException">Only one operation in flight at a time.</exception>
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (m_Busy)
            {
                throw new InvalidOperationException("Only one operation in flight at a time.");
            }

            m_Busy = true;
            return AsyncInfo.Run((c) => m_LoadMoreItemsTask(count));
        }

        /// <summary>
        /// Gets a sentinel value that supports incremental loading implementations.
        /// </summary>
        public bool HasMoreItems
        {
            get
            {
                return m_HasMoreItems();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IncrementalObservableCollection{T}"/> class.
        /// </summary>
        /// <param name="hasMoreItems">The has more items.</param>
        /// <param name="loadMoreItems">The load more items.</param>
        public IncrementalObservableCollection(
            Func<bool> hasMoreItems, 
            Func<uint, Task<IEnumerable<T>>> loadMoreItems)
        {
            m_HasMoreItems = hasMoreItems;
            m_LoadMoreItemsFunc = loadMoreItems;
            m_LoadMoreItemsTask = LoadItemsAsync;
        }

        private async Task<LoadMoreItemsResult> LoadItemsAsync(uint count)
        {
            try
            {
                var newItems = await m_LoadMoreItemsFunc(count);
                DispatcherHelper.Invoke(() =>
                {
                    foreach (var item in newItems)
                    {
                        Add(item);
                    }
                });

                return new LoadMoreItemsResult { Count = (uint)newItems.Count() };
            }
            finally
            {
                m_Busy = false;
            }
        }
    }
}
