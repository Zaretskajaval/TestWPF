using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Shop_Lapki.View
{
    /// <summary>
    /// Логика взаимодействия для PriceWindow.xaml
    /// </summary>
    public partial class PriceWindow : Window
    {
        Database database = new Database();
        int selectedRow;
    
        public PriceWindow()
        {
            InitializeComponent();
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-JQ6M829\MSSQLSERVER01;Initial catalog=Shop;Integrated Security=true");
            connection.Open();
            string cmd = "SELECT * FROM RaccoonDryEat,RaccoonPreservedEat,RaccoonGoodies,RaccoonToys,RaccoonMedecine WHERE RaccoonDryEat.Id=RaccoonPreservedEat.Id and RaccoonDryEat.Id=RaccoonGoodies.Id and RaccoonDryEat.Id=RaccoonToys.Id and RaccoonDryEat.Id=RaccoonMedecine.Id "; // Из какой таблицы нужен вывод 
            string cmdFox = "SELECT * FROM FoxDryEat,FoxPreservedEat,FoxGoodies,FoxToys,FoxMedecine,FoxBed WHERE FoxDryEat.Id=FoxPreservedEat.Id and FoxDryEat.Id=FoxGoodies.Id and FoxDryEat.Id=FoxToys.Id and FoxDryEat.Id=FoxMedecine.Id and FoxDryEat.Id=FoxBed.Id";//таблицы лис
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            SqlCommand createCommandFox = new SqlCommand(cmdFox, connection);
            createCommand.ExecuteNonQuery();
            createCommandFox.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            SqlDataAdapter dataAdp2 = new SqlDataAdapter(createCommandFox);
            DataTable dt = new DataTable("RaccoonDryEat,RaccoonPreservedEat,RaccoonGoodies,RaccoonToys,RaccoonMedecine"); // В скобках указываем название таблицы
            DataTable dtFox = new DataTable("FoxDryEat, FoxPreservedEat, FoxGoodies, FoxToys, FoxMedecine, FoxBed");
            dataAdp.Fill(dt);
            dataAdp2.Fill(dtFox);
            gridPriceRuccoon.ItemsSource = dt.DefaultView; // Сам вывод 
            gridPriceFox.ItemsSource = dtFox.DefaultView;
            connection.Close();

        }

        private void butExitMainMenu_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (!(window is MainWindow))		//Проверка, что окно не главное
                    window.Close();         //Закрыть все остальные окна, кроме главного
            }
        }
    }
}
