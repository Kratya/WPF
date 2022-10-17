using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPF
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

      public SeriesCollection SeriesCollection { get; set; }

      public string[] Labels { get; set; }

      public Func<double, string> YFormatter { get; set; }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         SeriesCollection = new SeriesCollection
         {
            new LineSeries
            {
                  Values = new ChartValues<ObservablePoint>
                  {
                     new ObservablePoint(0,10),
                     new ObservablePoint(2,11),
                     new ObservablePoint(3,12),
                     new ObservablePoint(4,13),
                     new ObservablePoint(6,14)
                  },
                  Title = "graph1",
                  Fill = Brushes.Transparent,
                  PointGeometrySize = 10,
                  PointGeometry = DefaultGeometries.Square
            },


            new LineSeries
            {
                  Values = new ChartValues<ObservablePoint>
                  {
                     new ObservablePoint(0,5),
                     new ObservablePoint(2,5),
                     new ObservablePoint(3,3),
                     new ObservablePoint(4,15),
                     new ObservablePoint(6,20)
                  },
                  Title = "graph2",
                  Stroke = Brushes.Red,
                  Fill = Brushes.Transparent,
                  PointGeometrySize = 10,

            }



         };

         YFormatter = value => value.ToString("C");
         DataContext = this;

      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "Файлы (* .txt)| *.txt|Все файлы (*.*)|*.*";
         ofd.FilterIndex = 1;
         ofd.RestoreDirectory = true;
         ofd.ShowDialog();
         if (ofd.FileName != "") //Проверка на выбор файла
         {
            using (var reader = File.OpenText(ofd.FileName))
            {
               //Пропусть первую строку в файле
               // if (!reader.EndOfStream)
               // reader.ReadLine();

               while (!reader.EndOfStream)
               {
                  string line = reader.ReadLine();
            

               }

            }
         }
         else MessageBox.Show("Файл не найден");
      }

      private void Graf_Loaded(object sender, RoutedEventArgs e)
      {

      }
   }
}
