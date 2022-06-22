using Human_Resources_department.Application_Data;
using Human_Resources_department.Enter.Base;
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
using System.Windows.Shapes;

namespace Human_Resources_department.Director
{
    /// <summary>
    /// Логика взаимодействия для DirectorWin.xaml
    /// </summary>
    public partial class DirectorWin : Window
    {
        public DirectorWin()
        {
            InitializeComponent();
            AppConnect.model0db = new UchebnayaPractika1Entities();
            AppFrame.DFrame = DirectFrame;

            DirectFrame.Navigate(new HumanPage());
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ARTIKIUM - Проект, сделанный с душой!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectFrame.Navigate(new HumanPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DirectFrame.Navigate(new SuspendedPage());
        }
    }
}
