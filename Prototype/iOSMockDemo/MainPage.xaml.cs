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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace iOSMockDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void AddonButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddonPage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string numberUser = "+41333333331";
            string numberBar = "+41333333332";
            string numberUser1 = "+41333333333";
            string numberUser2 = "+41333333334";
            string numberUser3 = "+41333333335";
            var user = Clubbing.user;
            var bar = Clubbing.bar;
            var user1 = Clubbing.user1;
            var user2 = Clubbing.user2;
            var user3 = Clubbing.user3;
            if (!user.SetupDone)
            {
                await user.Signin(numberUser, "Peter", "Krumer");
                await user.SetupCreditCard("1235233412231234");
            }
            if (!bar.SetupDone)
            {
                await bar.Signin(numberBar, "Faceclub", "");
                await bar.SetupCreditCard("1288233412341234");
            }
            if (!user1.SetupDone)
            {
                await user1.Signin(numberUser1, "Manuel", "Neuer");
                await user1.SetupCreditCard("1235233362341234");
            }
            if (!user2.SetupDone)
            {
                await user2.Signin(numberUser2, "Marc", "Faber");
                await user2.SetupCreditCard("1235233412355234");
            }
            if (!user3.SetupDone)
            {
                await user3.Signin(numberUser3, "David", "Beckham");
                await user3.SetupCreditCard("1235223512341234");
            }

        }
    }
}
