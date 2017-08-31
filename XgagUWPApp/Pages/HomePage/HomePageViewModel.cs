using ServiceLayer;

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
        /// Loads this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Load()
        {
            throw new System.NotImplementedException();
        }
    }
}
