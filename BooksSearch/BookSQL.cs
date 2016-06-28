using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace BooksSearch
{
    public class BookSQL
    {
        private MySqlConnection connection;     
        public BookSQL()
        {
           Initialize();
        }

        private void Initialize()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["MYSQLServerConnection"].ConnectionString;
           connection = new MySqlConnection(connectionString);
        }    
  
        public DataTable Select1()
        {
            string query = "SELECT ISBN,Title, Description, substr(LTRIM(RTRIM(Title)),1,1) as Letter FROM BookInfo";
            connection.Open();          
               //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter Adap = new MySqlDataAdapter(query, connection);
                DataTable dtBook = new DataTable("BookInfo");            
                Adap.Fill(dtBook);
                //close Connection
                connection.Close();               
               return dtBook;
           
        }
    }

   
}