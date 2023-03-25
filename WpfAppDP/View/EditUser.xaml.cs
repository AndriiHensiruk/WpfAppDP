using WpfAppDP.Model;
using WpfAppDP.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfAppDP.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser(User userToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedUser = userToEdit;
            DataManageVM.UserName = userToEdit.Name;
            DataManageVM.UserSurName = userToEdit.SurName;
            DataManageVM.UserPhone = userToEdit.Phone;
            //DataManageVM.UserPosition = userToEdit.Position;
        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
