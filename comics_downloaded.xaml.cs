using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Great_Archive
{
    /// <summary>
    /// Логика взаимодействия для comics_downloaded.xaml
    /// </summary>
    public partial class comics_downloaded : Page
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

        private void ComicsDownloaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new comics_downloaded());
        }

        private void Redirect(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datagrid.SelectedItem;
            String way = row.Row["way"].ToString();

            NavigationService.Navigate(new comics_reader(way: way));
        }

        private void DeleteComics(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)datagrid.SelectedItem;
            String way = row.Row["way"].ToString();

            Directory.Delete(way, true);

            NavigationService.Navigate(new comics_downloaded());
        }

        public comics_downloaded()
        {
            String link = "C:\\MY_COMICS\\";
            DirectoryInfo[] directsArray = new DirectoryInfo("C:\\MY_COMICS").GetDirectories();
            DataTable comicsList = new DataTable();

            String line;
            String[] lines;

            DataColumn publisherColumn = new DataColumn();
            publisherColumn.ColumnName = "Publisher";
            publisherColumn.Caption = "Publisher";
            publisherColumn.DataType = typeof(string);

            DataColumn titleColumn = new DataColumn();
            titleColumn.ColumnName = "Title";
            titleColumn.Caption = "Title";
            titleColumn.DataType = typeof(string);

            DataColumn volumeColumn = new DataColumn();
            volumeColumn.ColumnName = "Volume";
            volumeColumn.Caption = "Volume";
            volumeColumn.DataType = typeof(string);

            DataColumn comicbookColumn = new DataColumn();
            comicbookColumn.ColumnName = "Comicbook";
            comicbookColumn.Caption = "Comicbook";
            comicbookColumn.DataType = typeof(string);

            DataColumn pagesColumn = new DataColumn();
            pagesColumn.ColumnName = "Pages";
            pagesColumn.Caption = "Pages";
            pagesColumn.DataType = typeof(string);

            DataColumn way = new DataColumn();
            way.ColumnName = "Way";
            way.Caption = "Way";
            way.DataType = typeof(string);

            comicsList.Columns.Add(publisherColumn);
            comicsList.Columns.Add(titleColumn);
            comicsList.Columns.Add(volumeColumn);
            comicsList.Columns.Add(comicbookColumn);
            comicsList.Columns.Add(pagesColumn);
            comicsList.Columns.Add(way);

            for (int i = 0; i < directsArray.Length; i++)
            {
                line = directsArray[i].FullName + "\\";
                lines = line.Split("!.!.!");

                DataRow row = comicsList.NewRow();
                row[0] = (lines[0].Split("\\MY_COMICS\\"))[1];
                row[1] = lines[1];
                row[2] = lines[2];
                row[3] = lines[3];
                row[4] = lines[4];
                row[5] = line;
                comicsList.Rows.Add(row);
            }

            InitializeComponent();

            datagrid.ItemsSource = comicsList.DefaultView;
        }
    }
}
