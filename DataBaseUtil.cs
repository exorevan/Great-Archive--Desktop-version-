using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Great_Archive
{
    public class DataBaseUtil
    {
        NpgsqlConnection GetConnection()
        {
            string ConnectDB = "Server=localhost;Port=5432;Username=postgres;Password=qwerty1245;Database=comicsdb;";
            NpgsqlConnection Connection = new Npgsql.NpgsqlConnection(ConnectDB);

            return Connection;
        }

        public DataTable GetQuery(string select)
        {
            NpgsqlConnection connection = GetConnection();
            connection.Open();

            DataSet dataSet = new DataSet();
            string SQL_Query = select;

            NpgsqlCommand Command = connection.CreateCommand();
            Command.CommandText = SQL_Query;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Command);

            dataSet.Reset();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            connection.Close();

            return dataTable;
        }
    }
}
