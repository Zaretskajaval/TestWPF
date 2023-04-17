using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Shop_Lapki
{
    class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-JQ6M829\MSSQLSERVER01;Initial catalog=Probnaja;Integrated Security=true");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
