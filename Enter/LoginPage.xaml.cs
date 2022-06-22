using Human_Resources_department.Application_Data;
using Human_Resources_department.Director;
using Human_Resources_department.Manager;
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

namespace Human_Resources_department.Enter
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {

            try
            {

                var userObj = AppConnect.model0db.Аккаунт.FirstOrDefault(x => x.PhoneNum == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IDRole)
                    {

                        case 2:
                            MessageBox.Show("Здравствуйте, Бухалтер " + userObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            new ManageWin().Show();
                            Application.Current.MainWindow.Close();
                            break;
                        case 1:
                            MessageBox.Show("Здравствуйте, Директор " + userObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            new DirectorWin().Show();
                            Application.Current.MainWindow.Close();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                    }
                }
              
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

       
    }
}
