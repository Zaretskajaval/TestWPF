using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {

        public string ViewSum { get; set; }
     
        string pathExe = "";
        string ThePathToTest = "";
        public CreateOrderWindow()
        {
            InitializeComponent();
            ListOfGoods.Visibility = Visibility.Collapsed;
            ListOfGoods_Copy.Visibility = Visibility.Collapsed;
            Splitter.Visibility = Visibility.Collapsed;
            ListBoxGoods.Visibility = Visibility.Collapsed;
            ListBoxGoodsChoised.Visibility = Visibility.Collapsed;
        
            TextBlockSumItog.Text = "Общая сумма: ";

            pathExe = Environment.CurrentDirectory;    //К файлу exe
            ThePathToTest = pathExe + @"\Check.txt";    //К файлу 
            if (File.Exists(ThePathToTest) == true)
            {
                File.Delete(ThePathToTest);
            }
        }

        public void ShowViewSum()
        {
            TextBlockSum.Text = "Сумма на карте:   " + ViewSum;
           // MessageBox.Show(ViewSum);
        }


        private void butExit2_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (!(window is MainWindow))		//Проверка, что окно не главное
                    window.Close();         //Закрыть все остальные окна, кроме главного
            }
            
        }
        public List<string> lines = new List<string>();
        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
          
        
            View.ToMakeOrder toMakeOrder = new View.ToMakeOrder();
         
            toMakeOrder.FullSum="" + TotalSummOrder.ToString();
            
            this.Hide();				//Скрыть текущее окно
            toMakeOrder.ShowDialog();	//Показать модально дополнительное
           // this.Show();


        }
        List<string> listCat;
        List<string> listCat2;
        private void ButtonRaccoon_Click(object sender, RoutedEventArgs e)
        {
            ButtonFox.Visibility = Visibility.Collapsed;
            TextBlockChoiseOfCategory.Visibility = Visibility.Collapsed;
            ButtonRaccoon.Visibility = Visibility.Collapsed;
            ListOfGoods.Visibility = Visibility.Visible;
            ListOfGoods_Copy.Visibility = Visibility.Visible;
            Splitter.Visibility = Visibility.Visible;
            ListBoxGoods.Visibility = Visibility.Visible;
            ListBoxGoodsChoised.Visibility = Visibility.Visible;
            try                 //Обработка исключения
            {
                App.excelApp = new Excel.Application();     //Создать объект Excel
                App.excelApp.Visible = false;           //Не отображать пустой Excel
                if (File.Exists(App.fileMenu) )          //Проверить наличие документа
                {     //Открыть книгу Excel
                    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenu);  //Открыть книгу
              
                    App.excelApp.Visible = true;        //Сделать Excel видимым
                }
                else
                { MessageBox.Show("Файл с меню отсутствует"); this.Close(); }
            }
            catch
            { }
            ListBoxGoods.Items.Clear();		//Элемент интерфейса ListBox
            listCat = new List<string>();
            //Получить все категории из коллекции всех листов книги
            foreach (Excel.Worksheet item in App.excelBook.Worksheets)
            {
                listCat.Add(item.Name);		//Поместить название листа в список
            }
          
            ListBoxGoods.ItemsSource = listCat;



        }

        private void ButtonFox_Click(object sender, RoutedEventArgs e)
        {
            ButtonFox.Visibility = Visibility.Collapsed;
            TextBlockChoiseOfCategory.Visibility = Visibility.Collapsed;
            ButtonRaccoon.Visibility = Visibility.Collapsed;
            ListOfGoods.Visibility = Visibility.Visible;
            ListOfGoods_Copy.Visibility = Visibility.Visible;
            Splitter.Visibility = Visibility.Visible;
            ListBoxGoods.Visibility = Visibility.Visible;
            ListBoxGoodsChoised.Visibility = Visibility.Visible;
            ListBoxGoods.Visibility = Visibility.Visible;
            ListBoxGoodsChoised.Visibility = Visibility.Visible;
            try                
            {
                App.excelApp = new Excel.Application();     //Создать объект Excel
                App.excelApp.Visible = false;           //Не отображать пустой Excel
                if (File.Exists(App.fileMenuFox))          //Проверить наличие документа
                {     //Открыть книгу Excel
                    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenuFox);  //Открыть книгу

                    App.excelApp.Visible = true;        //Сделать Excel видимым

                }
                else
                { MessageBox.Show("Файл с меню отсутствует"); this.Close(); }
            }
            catch
            { }
            ListBoxGoods.Items.Clear();		//Элемент интерфейса ListBox
            listCat2 = new List<string>();
            //Получить все категории из коллекции всех листов книги
            foreach (Excel.Worksheet item in App.excelBook.Worksheets)
            {
                listCat2.Add(item.Name);
            }
          
            ListBoxGoods.ItemsSource = listCat2;
       
            
        }
        string categoryName = "";
        TextBlock textBlockPrice; Button button; StackPanel stackPanelDescription;  TextBlock textBlockName;
        private void SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            categoryName = ListBoxGoods.SelectedItem.ToString();
            ListBoxGoodsChoised.Items.Clear();
            Excel.Worksheet worksheet = App.excelBook.Worksheets[categoryName];
            for (int row = 1,col=1; row <= worksheet.UsedRange.Rows.Count; row++)
            {
                StackPanel stackPanelItem = new StackPanel();
                stackPanelItem.Orientation = Orientation.Horizontal;
                Image image = new Image();
 
               image.Source = new BitmapImage(new Uri(@"\FotoRaccoon\" + worksheet.Cells[row, col].value2 + ".jpg", UriKind.Relative)); 
              
                image.Width = 60; image.Height = 60; image.Stretch = Stretch.Fill;
                stackPanelItem.Children.Add(image);
                 stackPanelDescription = new StackPanel();
                stackPanelDescription.Orientation = Orientation.Vertical;
                textBlockName = new TextBlock();
                textBlockName.Text = "Именование товара: " + worksheet.Cells[row, col].value2 +"  ";

                stackPanelDescription.Children.Add(textBlockName);
                stackPanelItem.Children.Add(stackPanelDescription);
                 button = new Button();
                button.Background = Brushes.HotPink;
                button.Content = "В заказ";
                button.Tag = row.ToString();
              
                button.Click += button_Click;
                stackPanelItem.Children.Add(button);
                textBlockPrice = new TextBlock();
                textBlockPrice.Text = "Цена: " + worksheet.Cells[row, col+1].value2 + "  ";
                stackPanelDescription.Children.Add(textBlockPrice);
                ListBoxGoodsChoised.Items.Add(stackPanelItem);
              
               
            }
       


        }
        Button btn;int TotalSummOrder = 0; public List<string> listKorzina;
        int amount = 1;
        private void button_Click(object sender, RoutedEventArgs e)
        {
           // listProductsInOrders = new List<Classes.ProductsInOrder>();
            btn = (Button)e.OriginalSource;
            Excel.Worksheet worksheet = App.excelBook.Worksheets[categoryName]; 
            for (int i = 0; i <= worksheet.Cells[btn.Tag, 2].value2; i++)
            {
              
                if (Convert.ToString(btn.Tag) == i.ToString())
                {
                    TextBlockSumItog.Text = Convert.ToString(worksheet.Cells[btn.Tag, 2].value2);
                    TotalSummOrder += Convert.ToInt32(TextBlockSumItog.Text);
                    TextBlockSumItog.Text = "Общая сумма: " + TotalSummOrder.ToString();
                 
                    if (TotalSummOrder>=Convert.ToInt32( ViewSum))
                    {
                        MessageBox.Show("Вы превышаете лимит на карте");
                        TextBlockSumItog.Text = Convert.ToString(worksheet.Cells[btn.Tag, 2].value2);
                        TotalSummOrder -= Convert.ToInt32(TextBlockSumItog.Text);
                        TextBlockSumItog.Text = "Общая сумма: " + TotalSummOrder.ToString();
                    }
                }
            
            }
         
            for (int i = 0; i <= worksheet.Cells[btn.Tag, 2].value2; i++)
            {
              
                if (Convert.ToString(btn.Tag) == i.ToString())
                {
                    textBlockName.Text = Convert.ToString(worksheet.Cells[btn.Tag, 1].value2);
                  
                    textBlockPrice.Text = Convert.ToString(worksheet.Cells[btn.Tag, 2].value2);
                  
                }

            }
       
            pathExe = Environment.CurrentDirectory;    //К файлу exe
                ThePathToTest = pathExe + @"\Check.txt";    //К файлу 

            

            using (StreamWriter WriterTest = new StreamWriter(ThePathToTest, true)) 
            {
              
                WriterTest.WriteLine(textBlockName.Text + "," + textBlockPrice.Text + "," + amount);

            }

            //foreach (var line in File.ReadLines(@"\Check.txt").Distinct())
            //    Console.WriteLine(line);
            File.WriteAllLines(@"C:\Users\Senya\Desktop\Shop Lapki\Shop Lapki\bin\Debug\input.txt", File.ReadLines(@"C:\Users\Senya\Desktop\Shop Lapki\Shop Lapki\bin\Debug\Check.txt").Distinct().ToList());
          
        }

            private void SelectionChanged2(object sender, SelectionChangedEventArgs e)
            {
          
            }
    }
}
