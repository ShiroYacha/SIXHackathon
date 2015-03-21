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
    public sealed partial class CircleRequest : Page
    {
        public CircleRequest()
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

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ActivityPage));
        }

        private async void Accept_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //var heidi = Circle.heidi;
            //var trans = await heidi.GetTransactions();
            //var item1 = trans.FirstOrDefault(t=>t.status == "4" && t.type == "4");
            //if (item1 != null)
            //    await heidi.AcceptRequestFrom(item1.id);
            ActivityPage.status = 1;
            Frame.Navigate(typeof(ActivityPage));
        }

        private async void Reject_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //var heidi = Circle.heidi;
            //var trans = await heidi.GetTransactions();
            //var item1 = trans.FirstOrDefault(t => t.status == "4" && t.type == "4");
            //if (item1 != null)
            //    await heidi.RejectRequestFrom(item1.id);
            ActivityPage.status = 0;
            Frame.Navigate(typeof(ActivityPage));
        }
    }
}
