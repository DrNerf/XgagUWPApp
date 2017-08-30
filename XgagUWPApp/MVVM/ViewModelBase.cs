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

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected void Initialize()
        {
            IsBusy = true;
            Task.Factory.StartNew(Load).ContinueWith((t) => 
            {
                IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Executes the method with busy indicator.
        /// </summary>
        /// <param name="method">The method.</param>
        protected void BusyExecute(Task method)
        {
            IsBusy = true;
            method.ContinueWith((t) =>
            {
                IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        protected abstract void Load();

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
