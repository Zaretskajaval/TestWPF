using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace Shop_Lapki
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Excel.Application excelApp;	//Сервер Excel
        public static Excel.Workbook excelBook;	//Отдельная книга
        public static Excel.Worksheet excelSheet;	//Один лист
        public static Excel.Range excelCells;   //Ячейки листа
        public static string pathExe = Environment.CurrentDirectory;    //К файлу exe
        public static string fileMenu = pathExe + @"\LapkiRuccoon.xlsx";    //К файлу Excel
        public static string pathExeFox = Environment.CurrentDirectory;    //К файлу exe
        public static string fileMenuFox = pathExe + @"\LapkiFox.xlsx";	//К файлу Excel

    }
}
