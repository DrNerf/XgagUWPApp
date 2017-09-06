using System;
using Windows.UI.Core;

namespace XgagUWPApp
{
    public static class DispatcherHelper
    {
        public static async void Invoke(Action method)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => method());
        }
    }
}
