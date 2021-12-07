using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FormToResults
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results()
        {
            InitializeComponent();
            CheckList.ItemsSource = NewChecks;
            ResultList.ItemsSource = NewResults;
        }

        public static List<string> NewChecks = new();
        public static List<string> NewResults = new();

        private void Nav(object sender, MouseButtonEventArgs e)
        {
            // Back to form
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Form.xaml", UriKind.Relative));
        }

        private void Close(object sender, MouseButtonEventArgs e)
        {
            // Close app
            Application.Current.Shutdown();
        }
    }
}
