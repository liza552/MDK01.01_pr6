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
using MDK01._01_PR3.Models;

namespace MDK01._01_PR3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client(User user, string role)
        {
            InitializeComponent();
            txtWelcome.Text = user == null
                ? "Вы вошли как гость"
                : "Вы вошли как: " + user.Login + " (" + role + ")";
        }
    }
}
