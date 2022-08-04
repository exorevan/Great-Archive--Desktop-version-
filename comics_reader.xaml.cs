using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Drawing;

namespace Great_Archive
{
    /// <summary>
    /// Логика взаимодействия для reader.xaml
    /// </summary>
    public partial class comics_reader : Page
    {
        public DataBaseUtil dbu = new DataBaseUtil();

        private int currentPage = 1;
        private int lastPage = 999;
        private String currentName = "";
        private String currentLink = "";
        private bool donwloaded = false;

        public void BackPage(object sender, RoutedEventArgs e)
        {
            if (currentPage != 1)
            {
                currentPage -= 1;

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentLink + currentPage + ".jpg");
                bi3.EndInit();
                img.Source = bi3;
            } else if (currentPage == 1) {
                currentPage -= 1;
                img.Source=null;
            }
        }

        private void ForwardPage(object sender, RoutedEventArgs e)
        {
            if (currentPage != lastPage)
            {
                currentPage += 1;

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentLink + currentPage + ".jpg");
                bi3.EndInit();
                img.Source = bi3;
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new comics_downloaded());
        }

        public comics_reader(String way = "", String name = "", String publisher = "", int id = 0)
        {
            if (name != "")
            {
                String new_way = "http://localhost/main/source/" + publisher + "/";
                String[] a1 = name.Split(" том ");
                new_way += a1[0] + "/";
                String[] a2 = a1[1].Split(" # ");
                new_way += a2[0] + "/" + a2[1] + "/";

                DataTable dt = dbu.GetQuery("select number_of_pages from comics_files where comicbook=" + id);
                var cell = dt.Rows[0][0];
                lastPage = (int)cell;

                currentLink = new_way;
            }
            else
            {
                donwloaded = true;
                currentLink = way;
                lastPage = (int)Convert.ToDouble(way.Split("!.!.!")[4].Split("\\")[0]);
            }
            currentPage = 0;
            InitializeComponent();
            ForwardPage(null, null);
        }
    }
}
