using System;
using Windows.UI.Xaml.Controls;

namespace XgagUWPApp
{
    /// <summary>
    /// Menu Item.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public Symbol Icon { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the page.
        /// </summary>
        public Type PageType { get; set; }

        public string Image { get; set; }
    }   
}
