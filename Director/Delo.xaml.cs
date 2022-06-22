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
    /// Логика взаимодействия для Delo.xaml
    /// </summary>
    public partial class Delo : Page
    {
        private Human _currentAcc = new Human();
        public Delo(Human SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null)
                _currentAcc = SelectedUser;

            DataContext = _currentAcc;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.DFrame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (_currentAcc.ID == 0)
                UchebnayaPractika1Entities.GetContext().Human.Add(_currentAcc);
            try
            {
                Suspended user0bj = new Suspended()
                {
                    Name = (string)xName.Content,
                    Family = (string)xFamily.Content,
                    Patronymic = (string)xPatronymic.Content,
                    Age = (string)xAge.Content,
                    LastPos = (string)xPosition.Content,
                    ExpAge = (string)xExpAge.Content,
                    FaceIM = (byte[])xImageFace.Content,
                    Other = (string)xOther.Content,
                };
                AppConnect.model0db.Suspended.Add(user0bj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Сотрудник отстранен! удалите его запись из бд", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.DFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
