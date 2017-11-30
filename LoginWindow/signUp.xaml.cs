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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Mail;

namespace LoginWindow
{
    /// <summary>
    /// Interaction logic for signUp.xaml
    /// </summary>
    public partial class signUp : Window
    {
        public signUp()
        {
            InitializeComponent();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //email validation
            try { new MailAddress(LoginBox2.Text); }
            catch (ArgumentException)
            {
                MessageBox.Show("Email is empty", "Error", MessageBoxButton.OK);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Email is invalid", "Error", MessageBoxButton.OK);
                return;
            }

            //password validation

            if (!Regex.IsMatch(PassBox2.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$"))
            {
                MessageBox.Show("Password is invalid", "Error", MessageBoxButton.OK);
                return;
            }
            //login exist

            if (ClassUser.search(LoginBox2.Text, PassBox2.Text)==1 || ClassUser.search(LoginBox2.Text, PassBox2.Text) == -1)
            {
                MessageBox.Show("Current email is already used", "Error", MessageBoxButton.OK);
                return;
            }
            //phone validation
            if (!Regex.IsMatch(Phone.Text, @"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$"))
            {
                MessageBox.Show("Phone is invalid", "Error", MessageBoxButton.OK);
                return;
            }
            //phone exist
            if (ClassUser.searchPhone(Phone.Text))
            {
                MessageBox.Show("Current Phone is already used", "Error", MessageBoxButton.OK);
                return;
            }
            //name validation

            if (String.IsNullOrWhiteSpace(UserName.Text))
            {
                MessageBox.Show("Name is invalid", "Error", MessageBoxButton.OK);
                return;
            }
            ClassUser.AddUser(LoginBox2.Text, Phone.Text, UserName.Text, PassBox2.Text);
        }
    }
}
