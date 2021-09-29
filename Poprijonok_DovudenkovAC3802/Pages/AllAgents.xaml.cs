using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AllAgents.xaml
    /// </summary>
    public partial class AllAgents : Page
    {
        NavigationWindow owner;
        public AllAgents()
        {
            InitializeComponent();
        }
        public AllAgents(NavigationWindow owner)
        {
            InitializeComponent();
            this.owner = owner;
            dbContext.db.Agent.Load();
            dbContext.db.AgentType.Load();
            dgAgents.ItemsSource = dbContext.db.Agent.ToList();
            dgAgents.SelectedValuePath = "ID";

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(owner.CanGoBack)
                owner.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AgentEditWindow editWindow = new AgentEditWindow(int.Parse(dgAgents.SelectedValue.ToString()));
            
            if(editWindow.ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Внимание!", "Удалаить агента?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                dbContext.db.Agent.Remove(dbContext.db.Agent.Where(a => a.ID == int.Parse(dgAgents.SelectedValue.ToString())).FirstOrDefault());
                dgRefresh();
            }
        }
        private void dgRefresh()
        {
            dgAgents.ItemsSource = dbContext.db.Agent.ToList();
            dgAgents.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AgentEditWindow editWindow = new AgentEditWindow();

            if (editWindow.ShowDialog() == true)
            {
                dgRefresh();
            }
        }
    }
}
