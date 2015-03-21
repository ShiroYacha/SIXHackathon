using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Circle : Page
    {
        public static UserClient heidi = new UserClient();
        public static UserClient peter = new UserClient();
        public static UserClient vreni = new UserClient();


        public Circle()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ActivityPage.status == -1)
                PeterMeter.Fill = new SolidColorBrush(Colors.Red);
            else
                PeterMeter.Fill = new SolidColorBrush(Colors.Orange);
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddonPage));
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddonPage));
        }

        private void MomButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivityPage.name = "Heidi";
            ActivityPage.client = heidi;
            Frame.Navigate(typeof(ActivityPage));
        }

        private void VreniButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivityPage.name = "Vreni";
            ActivityPage.client = vreni;
            Frame.Navigate(typeof(ActivityPage));
        }

        private void PeterButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivityPage.name = "Peter";
            ActivityPage.client = peter;
            Frame.Navigate(typeof(ActivityPage));
        }

        private async void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
