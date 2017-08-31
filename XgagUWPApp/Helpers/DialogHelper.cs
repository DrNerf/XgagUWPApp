using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;

namespace XgagUWPApp
{
    public static class DialogHelper
    {
        public static IAsyncOperation<IUICommand> ShowError(string message)
        {
            return new MessageDialog(message, "Whoops").ShowAsync();
        }
    }
}
