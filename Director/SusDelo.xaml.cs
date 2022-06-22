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
    /// Логика взаимодействия для SusDelo.xaml
    /// </summary>
    public partial class SusDelo : Page
    {
        private Suspended _currentAcc = new Suspended();
        public SusDelo(Suspended SelectedUser)
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
                UchebnayaPractika1Entities.GetContext().Suspended.Add(_currentAcc);
            try
            {
                Human user0bj = new Human()
                {
                    Name = (string)xName.Content,
                    Family = (string)xFamily.Content,
                    Patronymic = (string)xPatronymic.Content,
                    Age = (string)xAge.Content,
                    Position = (string)xPosition.Content,
                    ExpAge = (string)xExpAge.Content,
                    FaceIM = (byte[])xImageFace.Content,
                    Other = (string)xOther.Content,
                };
                AppConnect.model0db.Human.Add(user0bj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Сотрудник Восстановлен! удалите его запись из Отстраненных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.DFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

    }
}
