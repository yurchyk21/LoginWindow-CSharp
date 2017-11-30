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
using System.Text.RegularExpressions;

namespace LoginWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassUser.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (ClassUser.search(LoginBox.Text, PassBox.Text))
            {
                case 0:
                    MessageBox.Show("User not exists");
                    break;
                case 1:
                    MessageBox.Show("Welcome");
                    break;
                case -1:
                    MessageBox.Show("Wrong password");
                    break;
                case -2:
                    MessageBox.Show("Wrong login");
                    break;
                default:
                    MessageBox.Show("Internal error", "Error", MessageBoxButton.OK);
                    break;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signUp signup = new signUp();
            signup.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClassUser.Save();
        }
    }
}
