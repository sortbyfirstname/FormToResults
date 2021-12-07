using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Linq;

namespace FormToResults
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page
    {
        public Form()
        {
            InitializeComponent();

            // Clear lists on each initialization
            Results.NewChecks.Clear();
            Results.NewResults.Clear();
        }

        public void Run(object sender, RoutedEventArgs e)
        {
            // Complete actions to output an identifier for the check you performed and a symbol to acknowledge pass/fail
            List<int> iterate = new();
            iterate.AddRange(Enumerable.Range(1, 25));

            foreach (int i in iterate)
            {
                Results.NewChecks.Add($"test {i}");
                Results.NewResults.Add("✔");
            }

            // This will navigate to the results page once completed
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Results.xaml", UriKind.Relative));
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }

        public void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (PasswordBox)sender;
            pb.Password = string.Empty;
            pb.GotFocus -= PasswordBox_GotFocus;
        }

        private void Close(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
