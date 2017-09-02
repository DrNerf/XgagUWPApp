using ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace XgagUWPApp
{
    /// <summary>
    /// Home Page View Model.
    /// </summary>
    /// <seealso cref="XgagUWPApp.ViewModelBase" />
    public class HomePageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return RuntimeInfo.SessionInfo.Username;
            }
        }

        /// <summary>
        /// Gets the avatar address.
        /// </summary>
        public string AvatarAddress
        {
            get
            {
                return RuntimeInfo.SessionInfo.Avatar;
            }
        }

        /// <summary>
        /// Gets or sets the menu actions.
        /// </summary>
        public IEnumerable<MenuItem> MenuActions
        {
            get
            {
                yield return new MenuItem() { Icon = Symbol.Home, Name = "Home", PageType = typeof(PostsPage) };
                yield return new MenuItem() { Icon = Symbol.Comment, Name = "Quotes" };
                yield return new MenuItem() { Icon = Symbol.Like, Name = "Good Guy List" };
                yield return new MenuItem() { Icon = Symbol.Dislike, Name = "Shit List" };
            }
        }

        public IEnumerable<MenuItem> MenuOptionsActions
        {
            get
            {
                yield return new MenuItem() { Image = AvatarAddress, Name = Username };
            }
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Load()
        {
            throw new System.NotImplementedException();
        }
    }
}
