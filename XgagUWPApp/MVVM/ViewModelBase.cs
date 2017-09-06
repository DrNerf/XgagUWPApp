using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XgagUWPApp
{
    /// <summary>
    /// View Model Base.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private bool m_IsBusy;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return m_IsBusy;
            }
            set
            {
                m_IsBusy = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void ExecuteInBackground(Action method)
        {
            IsBusy = true;

            Task.Factory.StartNew(method).ContinueWith(t =>
            {
                IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="property">The property.</param>
        protected void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            if (!string.IsNullOrEmpty(property))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
