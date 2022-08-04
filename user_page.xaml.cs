using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Great_Archive
{
    /// <summary>
    /// Interaction logic for lists_page.xaml
    /// </summary>
    public partial class user_page : Page
    {
        private void Publishers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("publishers"));
        }

        private void Titles(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("titles"));
        }

        private void Volumes(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("volumes"));
        }

        private void Comics(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("comics"));
        }

        private void Tags(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("tags"));
        }

        private void Authors(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new lists_page("authors"));
        }

        private void UserPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new user_page());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["UserKey"] = null;
            NavigationService.Navigate(new authorization());
        }

        public user_page()
        {
            InitializeComponent();
        }
    }
}
