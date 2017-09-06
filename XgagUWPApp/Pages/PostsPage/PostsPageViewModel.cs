using ServiceLayer;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XgagUWPApp
{
    /// <summary>
    /// Posts page view model.
    /// </summary>
    /// <seealso cref="XgagUWPApp.ViewModelBase" />
    public class PostsPageViewModel : ViewModelBase
    {
        private IPostsProxy m_PostsProxy;

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        public IncrementalObservableCollection<IPostModel> Posts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostsPageViewModel"/> class.
        /// </summary>
        public PostsPageViewModel()
        {
            m_PostsProxy = ProxyFactory.Instance.CreatePostsProxy();
            Posts = new IncrementalObservableCollection<IPostModel>(
                () => true,
                LoadMorePostsAsync);
        }

        private async Task<IEnumerable<IPostModel>> LoadMorePostsAsync(uint count)
        {
            return await m_PostsProxy.Get(Posts.Count, (int)count);
        }
    }
}
