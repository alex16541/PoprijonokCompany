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

namespace Poprijonok_DovudenkovAC3802
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        NavigationWindow owner;
        public MainMenu()
        {
            InitializeComponent();
        }
        public MainMenu(NavigationWindow owner)
        {
            InitializeComponent();
            
            this.owner = owner;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            owner.Close();
        }

        private void btnAgents_Click(object sender, RoutedEventArgs e)
        {
            owner.Navigate(new AllAgents(owner));
        }
    }
}
