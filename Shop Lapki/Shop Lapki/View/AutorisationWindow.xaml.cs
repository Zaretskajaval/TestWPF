using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        public AutorisationWindow()
        {
            InitializeComponent();
        }
        int countTryOBR = 3;
        int countTry = 0;
        public void Login_Click(object sender, RoutedEventArgs e)
        {


            Regex regexLog = new Regex(@"^Admin$");
            Regex regexPass = new Regex(@"^123$");
            if (regexLog.IsMatch(TextboxLog.Text) && regexPass.IsMatch(TextboxPass.Text))
            {
                View.WorkWithCatalogWindow workWithCatalogWindow = new View.WorkWithCatalogWindow();
                this.Hide();                //Скрыть текущее окно
                workWithCatalogWindow.ShowDialog();	//Показать модально дополнительное
            }
            else
            {
                countTry++;
                countTryOBR--;
                MessageBox.Show($"Неверный логин или пароль.\nОсталось {countTryOBR} попыток");
                if (countTry == 3)
                {
                    MessageBox.Show("Повторите попытку позднее");

                    foreach (Window window in App.Current.Windows)
                    {
                        if (!(window is MainWindow))        //Проверка, что окно не главное
                            window.Close();         //Закрыть все остальные окна, кроме главного
                    }
                }
            }



        }

        public void butExit3_Click()
        {
            throw new NotImplementedException();
        }
      
        public void butExit3_Click(object sender, RoutedEventArgs e)
        {
           
            foreach (Window window in App.Current.Windows)
            {
                if (!(window is MainWindow))
                {
                    //Проверка, что окно не главное
                    window.Close();
                   
    }    //Закрыть все остальные окна, кроме главного
               
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
   

        }

        private void TextboxLog_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
