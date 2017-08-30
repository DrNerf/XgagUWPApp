using System;
using System.Threading.Tasks;

namespace XgagUWPApp
{
    /// <summary>
    /// Login page view model.
    /// </summary>
    /// <seealso cref="XgagUWPApp.ViewModelBase" />
    public class LoginPageViewModel : ViewModelBase
    {
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
        }

        private void Login()
        {
            BusyExecute(Task.Delay(3000));
        }

        protected override void Load()
        {
        }
    }
}
