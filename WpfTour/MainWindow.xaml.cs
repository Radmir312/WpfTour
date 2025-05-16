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

namespace WpfTour
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ToursPage());
            Manager.MainFrame = MainFrame;

            ImportTours();
        }
        private void ImportTours()
        {
            var images = Directory.GetFiles(@"C:\img");

            foreach (var imagePath in images)
            {
                try
                {
                    var imageName = System.IO.Path.GetFileNameWithoutExtension(imagePath);
                    var tempTour = new Tour
                    {
                        ImagePreview = File.ReadAllBytes(imagePath)
                    };

                    ToursBaseEntities.GetContext().Tour.Add(tempTour);
                    ToursBaseEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки изображения {imagePath}: {ex.Message}");
                }
            }
        }
        //private void ImportTours()
        //{
        //    var images = Directory.GetFiles(@"C:\img");

        //    foreach (var imagePath in images)
        //    {
        //        try
        //        {
        //            var imageName = Path.GetFileNameWithoutExtension(imagePath);
        //            var tempTour = new Tour
        //            {
        //                ImagePreview = File.ReadAllBytes(imagePath)
        //            };

        //            ToursBaseEntities.GetContext().Tour.Add(tempTour);
        //            ToursBaseEntities.GetContext().SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Ошибка обработки изображения {imagePath}: {ex.Message}");
        //        }
        //    }
        //}

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                button_back.Visibility = Visibility.Visible;
            }
            else
            {
                button_back.Visibility = Visibility.Hidden;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
