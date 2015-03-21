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
    public sealed partial class SharePage : Page
    {
        static int mode = -1;
        public static string Name;
        public static string CokeTarget;
        public static string SpriteTarget;
        public static string BeerTarget;


        public SharePage()
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
            if (mode == 0)
            {
                CokeTarget = Name;
            }
            if (mode == 1)
            {
                SpriteTarget = Name;
            }
            if (mode == 2)
            {
                BeerTarget = Name;
            }
            CokeName.Text = CokeTarget!=null?CokeTarget:"";
            CokeContact.Visibility = CokeName.Text == "" ? Visibility.Visible : Visibility.Collapsed;
            CokeName.Visibility = CokeName.Text == "" ? Visibility.Collapsed : Visibility.Visible;
            SpriteName.Text = SpriteTarget != null ? SpriteTarget : "";
            SpriteContact.Visibility = SpriteName.Text == "" ? Visibility.Visible : Visibility.Collapsed;
            SpriteName.Visibility = SpriteName.Text == "" ? Visibility.Collapsed : Visibility.Visible;
            BeerName.Text = BeerTarget != null ? BeerTarget : "";
            BeerContact.Visibility = BeerName.Text == "" ? Visibility.Visible : Visibility.Collapsed;
            BeerName.Visibility = BeerName.Text == "" ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void RequestButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RequestPage));
        }

        private void CokeContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mode = 0;
            Frame.Navigate(typeof(ContactPage));

        }

        private void SpriteContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mode = 1;
            Frame.Navigate(typeof(ContactPage));

        }

        private void BeerContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mode = 2;
            Frame.Navigate(typeof(ContactPage));

        }

        private void ContactPopup_Closed(object sender, object e)
        {

        }
    }
}
