using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

using System.Windows.Controls;

namespace Shop_Lapki
{
    
    public class CheckForTest
    {
        public bool PassLogIsTrue;
        public bool ExitIsTrue=false;
        public void Check()
        {
            Regex regexLog = new Regex(@"^Admin$");
            Regex regexPass = new Regex(@"^123$");
            string pas = "123";
            string log = "Admin";
             PassLogIsTrue = false;
            if (regexLog.IsMatch(log) && regexPass.IsMatch(pas))
            {
                PassLogIsTrue = true;
            }
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
            CheckExitButton();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        public void CheckExitButton()
        {

            EXIT = true;

        }
        public int countTryOBR = 3;
       public int countTry = 0;
        public void CheckCountTryEnter()//Проверка на отчет количества попыток входа
        {

            Regex regexLog = new Regex(@"^Admin$");
            Regex regexPass = new Regex(@"^123$");
            string pas = "1234";
            string log = "Adminnn";
            PassLogIsTrue = false;
            if (regexLog.IsMatch(log) && regexPass.IsMatch(pas))
            {
                PassLogIsTrue = true;
            }
            else
            {
                countTry++;
                countTryOBR--;
            }
        }


        public bool ReadingFiles = false; 
         public void ReadFiles()
         {
            File.WriteAllLines(@"C:\Users\Senya\Desktop\Shop Lapki\Shop Lapki\bin\Debug\input.txt", File.ReadLines(@"C:\Users\Senya\Desktop\Shop Lapki\Shop Lapki\bin\Debug\Check.txt").Distinct().ToList());
            ReadingFiles = true;
         }



        

    }
}
