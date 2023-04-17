using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace Shop_Lapki.View
{
    /// <summary>
    /// Логика взаимодействия для ToMakeOrder.xaml
    /// </summary>
    public partial class ToMakeOrder : Window
    {
        public string FullSum { get; set; }
        int amount = 1;
        public ToMakeOrder()
        {
            InitializeComponent();
            Loaded += ToMakeOrder_Loaded;
        }
        public class CartData                           // класс создал 
        {
            public String NameProduct { get; set; }
            public double PriceProduct { get; set; }
            public double CountProduct { get; set; }
            //public double FullPriceProduct { get; set; }
            
        }
        List<CartData> listdata = new List<CartData>(); // Лист для данных
        List<CartData> listdata1 = new List<CartData>();

        private void ToMakeOrder_Loaded(object sender, RoutedEventArgs e)
        {
            string pathExe = Environment.CurrentDirectory;    //К файлу exe
            string ThePathToTest = pathExe + @"\input.txt";    //К файлу 
            int count = File.ReadAllLines(ThePathToTest).Length;
            String read = "";

         



            using (StreamReader WriterTest = new StreamReader(ThePathToTest, false))
            {
                for (int i = 0; i < count; i++)
                {

                    read = WriterTest.ReadLine();
                    string[] dataforgrid = read.Split(',');
                    listdata.Add(new CartData { NameProduct = dataforgrid[0], PriceProduct = Convert.ToDouble(dataforgrid[1]), CountProduct = Convert.ToDouble(dataforgrid[2])});

                }
            }

            datagrid.ItemsSource = listdata;
            datagrid.IsReadOnly = true;

 
        }

        private void butExitMainMenu_Click(object sender, RoutedEventArgs e)
        {

            foreach (Window window in App.Current.Windows)
            {
                if (!(window is MainWindow))		//Проверка, что окно не главное
                    window.Close();         //Закрыть все остальные окна, кроме главного
            }



        }
        double chena;
        private void Button_Click(object sender, RoutedEventArgs e)//Кнопка +
        {
            
            string pathExe = Environment.CurrentDirectory;    //К файлу exe
            string ThePathToTest = pathExe + @"\input.txt";    //К файлу 

            int count = File.ReadAllLines(ThePathToTest).Length;
           
            String read = "";
            using (StreamReader WriterTest = new StreamReader(ThePathToTest, true))
            {
                for (int i = 0; i < count; i++)
                {
                    read = WriterTest.ReadLine();
                    string[] dataforgrid = read.Split(',');
                    if (i == datagrid.SelectedIndex)
                    {
                        chena = (listdata[datagrid.SelectedIndex].CountProduct);
                        chena++;
                        if (chena > 15)
                        {
                            MessageBox.Show("Не более 15 шт.");
                            chena--;

                        }
                        
                        listdata.RemoveAt(datagrid.SelectedIndex);
                        listdata.Insert(datagrid.SelectedIndex, new CartData { NameProduct = dataforgrid[0], PriceProduct = Convert.ToDouble(dataforgrid[1]), CountProduct = chena });
                        TextBlockSumWithCount.Text +=Convert.ToString(Convert.ToDouble(FullSum) * chena) ;
                    }
                    
                }



            }
          
            datagrid.ItemsSource = null;
            datagrid.Items.Refresh();
            datagrid.ItemsSource = listdata;
            datagrid.IsReadOnly = true;

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Кнопка -
        {
            string pathExe = Environment.CurrentDirectory;    //К файлу exe
            string ThePathToTest = pathExe + @"\input.txt";    //К файлу 

            int count = File.ReadAllLines(ThePathToTest).Length;

            String read = "";
            using (StreamReader WriterTest = new StreamReader(ThePathToTest, true))
            {
                for (int i = 0; i < count; i++)
                {
                    read = WriterTest.ReadLine();
                    string[] dataforgrid = read.Split(',');
                    if (i == datagrid.SelectedIndex)
                    {
                        double chena = (listdata[datagrid.SelectedIndex].CountProduct);
                        chena--;
                        if (chena <= 0)
                        {
                            listdata.RemoveAt(datagrid.SelectedIndex);
                        }
                        else
                        {
                            listdata.RemoveAt(datagrid.SelectedIndex);
                            listdata.Insert(datagrid.SelectedIndex, new CartData { NameProduct = dataforgrid[0], PriceProduct = Convert.ToDouble(dataforgrid[1]), CountProduct = chena });
                        }
                        
                        

                    }

                }



            }

            datagrid.ItemsSource = null;
            datagrid.Items.Refresh();
            datagrid.ItemsSource = listdata;
            datagrid.IsReadOnly = true;

        }
    }
}
