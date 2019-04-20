﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KlitechProba.Services;
using KlitechProba.Views;
using Microsoft.Identity.Client;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KlitechProba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string[] scopes = { "offline_access", "User.Read", "Files.ReadWrite.All" };

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetAccessTokenAsync(object sender, RoutedEventArgs e)
        {
            var authService = AuthService.Instance;
            await authService.ShowLoginDialogAsync();
        }

        public async void ShowLoginDialog(object sender, RoutedEventArgs e)
        {
            var loginDialog = new LoginDialog();

            /*
            loginDialog.Measure(new Size(400, 600));
            loginDialog.Arrange(new Rect(new Point(100, 100), new Size(400, 600)));
            loginDialog.UpdateLayout();*/

            await loginDialog.ShowAsync();
        }

        private async void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            await AuthService.Instance.RefreshTokensAsync();
        }
    }
}
