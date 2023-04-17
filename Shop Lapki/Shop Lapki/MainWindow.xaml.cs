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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Shop_Lapki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           InitializeComponent();
        }
        public int sum = 0;
     
        private void butPrice_Click(object sender, RoutedEventArgs e)
        {
           
            View.PriceWindow priceWindow = new View.PriceWindow();

          
           
            this.Hide();				//Скрыть текущее окно
            priceWindow.ShowDialog(); //Показать модально дополнительное

        }
        private void butOrder_Click(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();
             sum = rnd.Next(500, 5000);
          // MessageBox.Show($"Мы заглянули на Вашу карту. На ней сумма: {sum} ");
            View.CreateOrderWindow createOrderWindow = new View.CreateOrderWindow();
            
            createOrderWindow.ViewSum = "" + sum;
            createOrderWindow.ShowViewSum();
            this.Hide();				//Скрыть текущее окно
            createOrderWindow.ShowDialog(); //Показать модально дополнительное
           
            this.Show();
          

        }

        public void butExit3_Click(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        private void butManagment_Click(object sender, RoutedEventArgs e)
        {
            string pass;
 
            StreamReader sr = new StreamReader("C:\\Users\\Senya\\source\\repos\\Shop Lapki\\Shop Lapki\\Passwords.txt");
            pass = sr.ReadLine();
           
            View.AutorisationWindow autorisationWindow = new View.AutorisationWindow();
            this.Hide();				//Скрыть текущее окно
            autorisationWindow.ShowDialog();	//Показать модально дополнительное
            this.Show();
        }
        public bool EXIT = false;
        public void butExit_Click(object sender, RoutedEventArgs e)
        {
            
            App.excelApp.Quit();            //Выйти из Excel
                                            //Уничтожить все COM-объекты
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(App.excelApp);
            //Заставляет сборщик мусора провести сборку мусора
            GC.Collect();

            this.Close();
            EXIT = true;
        }
    }
}
