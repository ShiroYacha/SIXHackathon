using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace iOSMockDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Clubbing : Page
    {


        public Clubbing()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void Order_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrderPage));
        }

        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (NumDrinks.Text == "0")
                NumDrinks.Text = "1";
            else if (NumDrinks.Text == "1")
                NumDrinks.Text = "2";
            else if (NumDrinks.Text == "2")
                NumDrinks.Text = "3";
        }
    }
}
