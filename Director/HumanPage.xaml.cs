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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Human_Resources_department.Director
{
    /// <summary>
    /// Логика взаимодействия для HumanPage.xaml
    /// </summary>
    public partial class HumanPage : Page
    {
        public HumanPage()
        {
            InitializeComponent();
            DGrigUsers.ItemsSource = UchebnayaPractika1Entities.GetContext().Human.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGrigUsers.SelectedItems.Cast<Human>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UchebnayaPractika1Entities.GetContext().Human.RemoveRange(hotelsForRemoving);
                    UchebnayaPractika1Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrigUsers.ItemsSource = UchebnayaPractika1Entities.GetContext().Human.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnDelo_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.DFrame.Navigate(new Delo((sender as Button).DataContext as Human));
        }
    }
}
