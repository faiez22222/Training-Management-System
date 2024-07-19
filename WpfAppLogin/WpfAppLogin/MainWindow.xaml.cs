using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void register(object sender  , RoutedEventArgs e )
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;

            string gender = ((ComboBoxItem)txtGender.SelectedItem)?.Content.ToString();
            string contactNo = txtContact.Text;
            string dateOfBirth = dobp.SelectedDate?.ToString("yyyy-MM-dd");
            string country = txtCountry.Text;
            string state = txtState.Text;
            string city = txtCity.Text;
            using (LoginCodeFirstContext login = new LoginCodeFirstContext())
            {
                LoginDetail loginDetail = new LoginDetail();
                loginDetail.Id = 1;
                loginDetail.FirstName = firstName;
                loginDetail.MiddleName = middleName;    
                loginDetail.LastName = lastName;
                loginDetail.Gender = gender;
                loginDetail.ContactNo = contactNo;
                loginDetail.ContactNo = contactNo;
                loginDetail.DateOfBirth = dateOfBirth;
                loginDetail.country = country;
                loginDetail.state = state;
                loginDetail.city = city;    
                login.LoginDetails.Add(loginDetail);
                login.SaveChanges();
                MessageBox.Show($"Registered:\n{firstName} {middleName} {lastName}\n{gender}\n{contactNo}\n{dateOfBirth}\n{country}, {state}, {city}");
            }

        }
    }
}