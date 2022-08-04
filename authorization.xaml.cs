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
    /// Логика взаимодействия для authorisation.xaml
    /// </summary>
    public partial class authorization : Page
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new registration());
        }
        private void TryToAuthoricate(object sender, RoutedEventArgs e)
        {

        }
    }
}
