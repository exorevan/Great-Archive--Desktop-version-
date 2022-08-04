using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class lists_page : Page
    {
        public DataBaseUtil dbu = new DataBaseUtil();
        public string currentGrid = "";

        public int currentPublisher = 0;
        public int currentTitle = 0;
        public int currentVolume = 0;
        public int currentAuthor = 0;
        public int currentTag = 0;

        private DataTable AddRateColumn(DataTable datatable)
        {
            DataColumn column = new DataColumn();
            column.ColumnName = "Rate";
            column.Caption = "Rate";
            column.DataType = typeof(float);
            datatable.Columns.Add(column);
            DataTable newDataTable = new DataTable();

            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                DataColumn newDataColumn = new DataColumn();
                newDataColumn.ColumnName = datatable.Columns[i].ColumnName;
                newDataColumn.DataType = typeof(string);

                newDataTable.Columns.Add();
            }

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow row = datatable.Rows[i];
                object[] itemRow = row.ItemArray;
                int id = (int)(long)itemRow[0];
                float avgRate = 0;
                string select = "";

                if (currentGrid == "titles")
                {
                    select = "select avg(rate) from rates_tl where title=" + id;
                }
                else if (currentGrid == "volumes")
                {
                    select = "select avg(rate) from rates_vl where volume=" + id;
                }
                else if (currentGrid == "comics")
                {
                    select = "select avg(rate) from rates_cb where comicbook=" + id;
                }

                DataTable query = dbu.GetQuery(select);
                DataRow query_row = query.Rows[0];
                object[] array = query_row.ItemArray;

                if (!(array[0] is DBNull))
                {
                    avgRate = (float)Convert.ToSingle(query.Rows[0].ItemArray[0]);
                }

                row["Rate"] = avgRate;
                newDataTable.Rows.Add(row.ItemArray);
            }

            return newDataTable;
        }

        private void Publishers(object sender, RoutedEventArgs e)
        {
            currentGrid = "publishers";
            String select = "select publishers.id as \"id\", publishers.name as \"Издатель\", countries.name as \"Страна\" " +
                                "from publishers inner join countries on countries.id=publishers.country";
            DataTable query = dbu.GetQuery(select);
            datagrid.ItemsSource = query.DefaultView;
        }
        
        private void Titles(object sender, RoutedEventArgs e)
        {
            String select;

            currentGrid = "titles";

            if (currentPublisher != 0)
            {
                select = "select id as \"id\", name as \"Линейка\" " +
                    "from titles where publisher=" + currentPublisher;
            } else
            {
                select = "select id as \"id\", name as \"Линейка\" from titles";
            }

            DataTable query = dbu.GetQuery(select);
            DataTable new_query = AddRateColumn(query);

            new_query.Columns["Column1"].ColumnName = "id";
            new_query.Columns["Column2"].ColumnName = "Линейка";
            new_query.Columns["Column3"].ColumnName = "Средняя оценка";

            datagrid.ItemsSource = new_query.DefaultView;

            currentPublisher = 0;
            currentTitle = 0;
            currentVolume = 0;
            currentAuthor = 0;
            currentTag = 0;
        }
        
        private void Volumes(object sender, RoutedEventArgs e)
        {
            String select;

            currentGrid = "volumes";

            if (currentTitle != 0)
            {
                select = "select volumes.id as \"id\", titles.name as \"Линйека\", volumes.name as \"Том\" " +
                                "from volumes " +
                                "inner join titles on titles.id=volumes.title " +
                                "where volumes.title=" + currentTitle;
            }
            else
            {
                select = "select volumes.id as \"id\", titles.name as \"Линейка\", volumes.name as \"Том\" " +
                                "from volumes " +
                                "inner join titles on titles.id=volumes.title";
            }

            DataTable query = dbu.GetQuery(select);
            DataTable new_query = AddRateColumn(query);

            new_query.Columns["Column1"].ColumnName = "id";
            new_query.Columns["Column2"].ColumnName = "Линейка";
            new_query.Columns["Column3"].ColumnName = "Том";
            new_query.Columns["Column4"].ColumnName = "Средняя оценка";

            datagrid.ItemsSource = new_query.DefaultView;

            currentPublisher = 0;
            currentTitle = 0;
            currentVolume = 0;
            currentAuthor = 0;
            currentTag = 0;
        }

        private void Comics(object sender, RoutedEventArgs e)
        {
            String select;

            currentGrid = "comics";

            if (currentVolume != 0)
            {
                select = "select comics.id as \"id\", titles.name as \"Линейка\", volumes.name as \"Том\", comics.name as \"Выпуск\" " +
                                "from (comics inner join volumes on volumes.id=comics.volume) " +
                                "inner join titles on titles.id=volumes.title " +
                                "where volumes.id=" + currentVolume;
            }
            else if (currentAuthor != 0)
            {
                select = "select comics.id as \"id\", titles.name as \"Линейка\", volumes.name as \"Том\", comics.name as \"Выпуск\" " +
                                "from ((comics " +
                                "inner join volumes on volumes.id=comics.volume) " +
                                "inner join titles on titles.id=volumes.title) " +
                                "inner join creators on creators.comicbook=comics.id " +
                                "where creators.people_id=" + currentAuthor + " " +
                                "group by 1, 2, 3, 4";
            }
            else if (currentTag != 0)
            {
                select = "select comics.id as \"id\", titles.name as \"Линейка\", volumes.name as \"Том\", comics.name as \"Выпуск\" " +
                                "from ((comics " +
                                "inner join volumes on volumes.id=comics.volume) " +
                                "inner join titles on titles.id=volumes.title) " +
                                "inner join comics_to_tags on comics_to_tags.comicbook=comics.id " +
                                "where comics_to_tags.tag=" + currentTag;
            }
            else
            {
                select = "select comics.id as \"id\", titles.name as \"Линейка\", volumes.name as \"Том\", comics.name as \"Выпуск\" " +
                                "from (comics inner join volumes on volumes.id=comics.volume) " +
                                "inner join titles on titles.id=volumes.title";
            }

            DataTable query = dbu.GetQuery(select);
            DataTable new_query = AddRateColumn(query);

            new_query.Columns["Column1"].ColumnName = "id";
            new_query.Columns["Column2"].ColumnName = "Линейка";
            new_query.Columns["Column3"].ColumnName = "Том";
            new_query.Columns["Column4"].ColumnName = "Выпуск";
            new_query.Columns["Column5"].ColumnName = "Средняя оценка";

            datagrid.ItemsSource = new_query.DefaultView;

            currentPublisher = 0;
            currentTitle = 0;
            currentVolume = 0;
            currentAuthor = 0;
            currentTag = 0;
        }

        private void Tags(object sender, RoutedEventArgs e)
        {
            currentGrid = "tags";

            String select = "select id as \"id\", name as \"Тег\" from tags";
            DataTable query = dbu.GetQuery(select);
            datagrid.ItemsSource = query.DefaultView;

            currentPublisher = 0;
            currentTitle = 0;
            currentVolume = 0;
            currentAuthor = 0;
            currentTag = 0;
        }

        private void Authors(object sender, RoutedEventArgs e)
        {
            currentGrid = "authors";

            String select = "select id as \"id\", name as \"Имя\", lname as \"Фамилия\" from people";
            DataTable query = dbu.GetQuery(select);
            datagrid.ItemsSource = query.DefaultView;

            currentPublisher = 0;
            currentTitle = 0;
            currentVolume = 0;
            currentAuthor = 0;
            currentTag = 0;
        }

        private void ComicsDownloaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new comics_downloaded());
        }

        public lists_page()
        {
            InitializeComponent();
        }

        private void Redirect (object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datagrid.SelectedItem;
            int id = (int)Convert.ToDouble(row.Row["id"].ToString());

            if (currentGrid == "comics")
            {
                float avgRate = Convert.ToSingle(row.Row["Средняя оценка"]);
                NavigationService.Navigate(new comicbook(id, avgRate));
            }
            else if (currentGrid == "volumes")
            {
                NavigationService.Navigate(new lists_page("comics", volume_id: id));
            }
            else if (currentGrid == "titles")
            {
                NavigationService.Navigate(new lists_page("volumes", title_id: id));
            }
            else if (currentGrid == "publishers")
            {
                NavigationService.Navigate(new lists_page("titles", publisher_id: id));
            }
            else if (currentGrid == "tags")
            {
                NavigationService.Navigate(new lists_page("comics", tag_id: id));
            }
            else if (currentGrid == "authors")
            {
                NavigationService.Navigate(new lists_page("comics", author_id: id));
            }
        }

        public lists_page(String select, int publisher_id = 0, int title_id = 0, int volume_id = 0, int author_id = 0, int tag_id = 0)
        {
            InitializeComponent();

            if (select == "publishers")
            {
                Publishers(new object(), new RoutedEventArgs());
            } 
            else if (select == "titles")
            {
                if (publisher_id == 0)
                {
                    Titles(new object(), new RoutedEventArgs());
                } else
                {
                    currentPublisher = publisher_id;
                    Titles(new object(), new RoutedEventArgs());
                }
            } 
            else if (select == "volumes")
            {
                if (title_id == 0)
                {
                    Volumes(new object(), new RoutedEventArgs());
                } else
                {
                    currentTitle = title_id;
                    Volumes(new object(), new RoutedEventArgs());
                }
            }
            else if (select == "comics")
            {
                if (volume_id != 0)
                {
                    currentVolume = volume_id;
                    Comics(new object(), new RoutedEventArgs());
                }
                else if (author_id != 0)
                {
                    currentAuthor = author_id;
                    Comics(new object(), new RoutedEventArgs());
                }
                else if (tag_id != 0)
                {
                    currentTag = tag_id;
                    Comics(new object(), new RoutedEventArgs());
                } else
                {
                    Comics(new object(), new RoutedEventArgs());
                }
            }
            else if (select == "tags")
            {
                Tags(new object(), new RoutedEventArgs());
            }
            else if (select == "authors")
            {
                Authors(new object(), new RoutedEventArgs());
            }
        }
    }
}
