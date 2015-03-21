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
    public sealed partial class Clubbing : Page
    {
        public static UserClient user = new UserClient();
        public static UserClient bar = new UserClient();
        public static UserClient user1 = new UserClient();
        public static UserClient user2 = new UserClient();
        public static UserClient user3 = new UserClient();

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

        private void ListView_Tapped()
        {
            if (NumDrinks.Text == "0")
                NumDrinks.Text = "1";
            else if (NumDrinks.Text == "1")
                NumDrinks.Text = "2";
            else if (NumDrinks.Text == "2")
                NumDrinks.Text = "3";
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddonPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void Coke_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Coke.Foreground = new SolidColorBrush(Colors.ForestGreen);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(200));
            Coke.Foreground = new SolidColorBrush(Colors.Black);
            ListView_Tapped();
        }

        private async void Sprite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Sprite.Foreground = new SolidColorBrush(Colors.ForestGreen);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(200));
            Sprite.Foreground = new SolidColorBrush(Colors.Black);
            ListView_Tapped();
        }

        private async void Beer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Beer.Foreground = new SolidColorBrush(Colors.ForestGreen);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(200));
            Beer.Foreground = new SolidColorBrush(Colors.Black);
            ListView_Tapped();
        }

    }
}
