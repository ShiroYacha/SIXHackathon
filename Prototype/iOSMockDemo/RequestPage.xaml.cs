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
    public sealed partial class RequestPage : Page
    {
        private static bool requested = false;
        public RequestPage()
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

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SharePage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!requested)
            {
                // Request
                var user = Clubbing.user;
                var bar = Clubbing.bar;
                var user1 = Clubbing.user1;
                var user2 = Clubbing.user2;
                var user3 = Clubbing.user3;
                await user.RequestMoneyFrom(user1.mobile, "4");
                await user.RequestMoneyFrom(user2.mobile, "3");
                await user.RequestMoneyFrom(user3.mobile, "3");
                Progress.IsActive = false;
                Progress.Visibility = Visibility.Collapsed;
                Request.Visibility = Visibility.Visible;
                User1Name.Text = user1.name;
                User2Name.Text = user2.name;
                User3Name.Text = user3.name;
                StatusCanvus.Visibility = Visibility.Visible;
                // W8 to response
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(3));
                var trans1 = await user1.GetTransactions();
                var trans2 = await user2.GetTransactions();
                var item1 = trans1.FirstOrDefault(t => Int32.Parse(t.amount) < 0 && t.phoneNumber == user.mobile && t.status == "4" && t.type == "4");
                if (item1 != null)
                    await user1.AcceptRequestFrom(item1.id);
                // Show
                User1Status.Text = "Accepted";
                User1Status.Foreground = new SolidColorBrush(Colors.ForestGreen);
                requested = true;
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddonPage));
        }
    }
}
