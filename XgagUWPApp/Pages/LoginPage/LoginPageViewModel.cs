using ServiceLayer;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace XgagUWPApp
{
    /// <summary>
    /// Login page view model.
    /// </summary>
    /// <seealso cref="XgagUWPApp.ViewModelBase" />
    public class LoginPageViewModel : ViewModelBase
    {
        private IAuthorizationProxy m_AuthorizationProxy;
        private string m_Username;
        private string m_Password;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                m_Username = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        public DelegateCommand LoginCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageViewModel"/> class.
        /// </summary>
        public LoginPageViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
            m_AuthorizationProxy = ProxyFactory.Instance.CreateAuthorizationProxy();
        }

        private async void Login()
        {
            IsBusy = true;

            try
            {
                var session = await m_AuthorizationProxy.Login(Username, Password);
                NavigationHelper.Navigate(typeof(HomePage));
            }
            catch (ProxyException ex)
            {
                var unauthorizedException = ex as UnauthorizedException;
                if (unauthorizedException != null)
                {
                    await DialogHelper.ShowError("Wrong username or password!");
                }
                else
                {
                    await DialogHelper.ShowError("Whoops, something ain't right!");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void Load()
        {
        }
    }
}
