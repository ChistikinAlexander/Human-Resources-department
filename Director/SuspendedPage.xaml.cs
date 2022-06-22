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
    /// Логика взаимодействия для SuspendedPage.xaml
    /// </summary>
    public partial class SuspendedPage : Page
    {
        public SuspendedPage()
        {
            InitializeComponent();
            DGrigSus.ItemsSource = UchebnayaPractika1Entities.GetContext().Suspended.ToList();
        }

        private void BtnSusDel_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.DFrame.Navigate(new SusDelo((sender as Button).DataContext as Suspended));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGrigSus.SelectedItems.Cast<Suspended>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UchebnayaPractika1Entities.GetContext().Suspended.RemoveRange(hotelsForRemoving);
                    UchebnayaPractika1Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrigSus.ItemsSource = UchebnayaPractika1Entities.GetContext().Human.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
