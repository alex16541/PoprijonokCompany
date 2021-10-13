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
        List<Agent> Agents;
        public AllAgents()
        {
            InitializeComponent();
        }
        public AllAgents(NavigationWindow owner)
        {
            this.owner = owner;
            InitializeComponent();
            dbContext.db.Agent.Load();
            lvAgents.SelectedValuePath = "ID";
            listViewRefresh();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(owner.CanGoBack)
                owner.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = (Button)sender;
            AgentEditWindow editWindow = new AgentEditWindow(int.Parse(btnEdit.Uid.ToString()));
            
            if(editWindow.ShowDialog() == true)
            {
                listViewRefresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Внимание!", "Удалаить агента?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                Button btnDelete = (Button)sender;
                Agent agent = Agents.Where(a => a.ID == int.Parse(btnDelete.Uid.ToString())).FirstOrDefault();
                agent.IsDeleted = true;
                listViewRefresh();
            }
        }
        private void listViewRefresh()
        {
            Agents = dbContext.db.Agent.ToList().Where(a => a.IsDeleted == false).ToList();
            lvAgents.ItemsSource = Agents;
            lvAgents.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AgentEditWindow editWindow = new AgentEditWindow();

            if (editWindow.ShowDialog() == true)
            {
                listViewRefresh();
            }
        }
    }
}
