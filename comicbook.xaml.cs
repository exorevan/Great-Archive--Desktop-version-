using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для comicbook.xaml
    /// </summary>
    public partial class comicbook : Page
    {
        public DataBaseUtil dbu = new DataBaseUtil();

        public int currentWriter = 0;
        public int currentPencil = 0;
        public int currentInk = 0;
        public int currentColor = 0;

        public int currentPublisher = 0;
        public String currentTitle = "";
        public String currentVolume = "";
        public String currentNumber = "";
        public int currentComicbook = 0;
        public int pagesCount = 0;

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

        private void PublisherRedirect(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new lists_page("titles", publisher_id:currentPublisher));
        }

        private void AuthorRedirect(object sender, RoutedEventArgs e)
        {
            //String name = ((Button)sender).Content;
            //Button currentButton = sender as Button;
            String post = (sender as Button).Name;
            int id = 0;

            if (post == "writer_button")
            {
                id = currentWriter;
            }
            else if (post == "pencil_button")
            {
                id = currentPencil;
            }
            else if (post == "ink_button")
            {
                id = currentInk;
            }
            else if (post == "color_button")
            {
                id = currentColor;
            }

            NavigationService.Navigate(new lists_page("comics", author_id:id));
        }

        private void TagRedirect(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)sender;
            DataRowView rowView = (DataRowView)row.Item;
            DataRow rowData = rowView.Row;
            object[] array = rowData.ItemArray;
            int id = (int)(long)array[0];

            NavigationService.Navigate(new lists_page("comics", tag_id: id));
        } 

        public void ComicsDownload(object sender, RoutedEventArgs e)
        {
            String name = comicbook_name.Text;
            String publisher = publicher_name_button.Content.ToString();
            String new_path = "C:\\MY_COMICS\\";

            new_path += publisher + "!.!.!" + currentTitle + "!.!.!" + currentVolume + "!.!.!" + currentNumber + "!.!.!" + pagesCount;

            if (!Directory.Exists(new_path))
            {
                Directory.CreateDirectory(new_path);

                DataTable dt11 = dbu.GetQuery("select link from comics_files where comicbook=" + currentComicbook);
                var cell = dt11.Rows[0][0];
                String new_link = (String)cell;
                WebClient wclient = new WebClient();

                for (int i = 0; i < pagesCount; i++)
                {
                    wclient.DownloadFile(("http://localhost/main/" + new_link + "/" + (i + 1) + ".jpg"), (new_path + "\\" + (i + 1) + ".jpg"));
                }
            }
        }

        public void ReaderRedirect(object sender, RoutedEventArgs e)
        {
            String name = comicbook_name.Text;
            String publisher = publicher_name_button.Content.ToString();
            NavigationService.Navigate(new comics_reader(name: name, publisher: publisher, id: currentComicbook));
        }

        public comicbook(int id = 2, float avgRate = 0)
        {
            String select = "";

            InitializeComponent();
            select = "select titles.name, volumes.name, comics.name, publishers.name, people.name, people.lname, comics.description, people.id, publishers.id " +
                        "from ((((comics " +
                        "inner join volumes on volumes.id = comics.volume) " +
                        "inner join titles on titles.id = volumes.title) " +
                        "inner join publishers on publishers.id = titles.publisher) " +
                        "inner join creators on creators.comicbook = comics.id) " +
                        "inner join people on people.id = creators.people_id " +
                        "where comics.id = " + id;
            DataTable query = dbu.GetQuery(select);
            comicbook_name.Text = query.Rows[0][0].ToString() + " том " + query.Rows[0][1].ToString() + " # " + query.Rows[0][2].ToString();
            publicher_name_button.Content = query.Rows[0][3].ToString();
            description.Text = query.Rows[0][6].ToString();

            currentWriter = (int)Convert.ToDouble(query.Rows[0][7]);
            currentPencil = (int)Convert.ToDouble(query.Rows[1][7]);
            currentInk = (int)Convert.ToDouble(query.Rows[2][7]);
            currentColor = (int)Convert.ToDouble(query.Rows[3][7]);

            currentPublisher = (int)Convert.ToDouble(query.Rows[0][8]);
            currentTitle = query.Rows[0][0].ToString();
            currentVolume = query.Rows[0][1].ToString();
            currentNumber = query.Rows[0][2].ToString();
            DataTable dt11 = dbu.GetQuery("select number_of_pages from comics_files where comicbook=" + id);
            var cell = dt11.Rows[0][0];
            pagesCount = (int)cell;
            currentComicbook = id;

            writer_button.Content = query.Rows[0][4] + " " + query.Rows[0][5];
            pencil_button.Content = query.Rows[1][4] + " " + query.Rows[1][5];
            ink_button.Content = query.Rows[2][4] + " " + query.Rows[2][5];
            color_button.Content = query.Rows[3][4] + " " + query.Rows[3][5];

            average_rate.Content = avgRate;

            select = "select tags.id, tags.name from comics_to_tags " +
                        "inner join tags on tags.id=comics_to_tags.tag " +
                        "where comics_to_tags.comicbook=" + id;
            query = dbu.GetQuery(select);
            tags_grid.ItemsSource = query.DefaultView;
        }
    }
}
