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
    public sealed partial class PaymentPage : Page
    {
        private static bool amountSent = false;
        public PaymentPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(100));
        }

        private void ShareButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SharePage));
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrderPage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!amountSent)
            {
                Progress.IsActive = true;
                Progress.Visibility = Visibility.Visible;
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(0.5));                
                Progress.IsActive = false;
                Progress.Visibility = Visibility.Collapsed;
                Result.Visibility = Visibility.Visible;
                //make sure does not resend
                amountSent = true;
            }
        }

        private async void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
