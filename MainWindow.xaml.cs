using Human_Resources_department.Application_Data;
using Human_Resources_department.Enter;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Human_Resources_department
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.model0db = new UchebnayaPractika1Entities();
            AppFrame.StartFrame = StartFrame;

            StartFrame.Navigate(new LoginPage());
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ARTIKIUM - Проект, сделанный с душой!");
        }
    }
}
