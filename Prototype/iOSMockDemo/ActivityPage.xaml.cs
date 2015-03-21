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
    public sealed partial class ActivityPage : Page
    {
        public static UserClient client;
        public static String name;
        public static int status = -1;

        public ActivityPage()
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            UserName.Text = name;
            // Load the activities
            var activities = await client.GetTransactions();
            activities.Sort((x, y) => { return Int64.Parse(x.timestamp).CompareTo(Int64.Parse(y.timestamp)); });
            // Show
            List<string> existing = new List<string>();
            DataList.Items.Clear();
            if (name == "Peter")
            {
                ListViewItem item = new ListViewItem();
                item.FontSize = 20;
                item.Margin = new Thickness(5, 10, 5, 0);
                if (status == -1)
                {
                    item.Tapped += item_Tapped;
                    item.Foreground = new SolidColorBrush(Colors.Red);
                    item.Content = string.Format("{0}: {1} - {2}", DateTime.Now.AddMinutes(-14).ToString("dd/MM, HH:mm"), "Request", "Open");
                }
                else if (status == 0)
                {
                    item.Foreground = new SolidColorBrush(Colors.Black);
                    item.Content = string.Format("{0}: {1} - {2}", DateTime.Now.AddMinutes(-14).ToString("dd/MM, HH:mm"), "Request", "Rejected");
                }
                else
                {
                    item.Foreground = new SolidColorBrush(Colors.Black);
                    item.Content = string.Format("{0}: {1} - {2}", DateTime.Now.AddMinutes(-14).ToString("dd/MM, HH:mm"), "Request", "Accepted");
                }
                DataList.Items.Add(item);
            }
            foreach (var tran in activities)
            {
                string outString;
                string dataString = tran.MockToString(out outString);
                if (!existing.Contains(outString))
                {
                    ListViewItem item = new ListViewItem();
                    item.FontSize = 20;
                    item.Margin = new Thickness(5, 10, 5, 0);
                    item.Content = dataString;
                    DataList.Items.Add(item);
                    existing.Add(outString);
                }
            }

        }

        async void item_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //await client.RequestMoneyFrom(Circle.heidi.mobile, "99");
            Frame.Navigate(typeof(CircleRequest));
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Circle));
        }
    }
}
