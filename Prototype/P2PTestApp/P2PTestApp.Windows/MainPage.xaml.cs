using Data;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace P2PTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        UserClient client1 = new UserClient();
        UserClient client2 = new UserClient();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string number1="+41799123423";
            string number2="+41799126223";
            await client1.Signin(number1,"terst","set");
            await client1.SetupCreditCard("1235233412341234");
            await client2.Signin(number2,"weterst","set");
            await client2.SetupCreditCard("1123142123412434");
            await client1.SendMoneyTo(number2, "20","1");
            await client1.RequestMoneyFrom(number2,"60");
            var trans = await client2.GetTransactions();
            await client2.AcceptRequestFrom(trans.First(t=>t.status=="4"&&t.type=="4").id);
            await client2.RejectRequestFrom(trans.First(t => t.status == "4" && t.type == "4").id);

        }
    }
}
