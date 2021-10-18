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
        private List<Agent> Agents;
        private int agentTypeId = 0;
        private string searchText = "";
        private string agentsSortType = "";

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

            loadAgents();
            listViewRefresh();

            cbSort.Items.Add("Сортировка");
            cbSort.Items.Add("От А до Я");
            cbSort.Items.Add("От Я до А");
            cbSort.SelectedIndex = 0;

            var agentTypes = dbContext.db.AgentType.Select(type => new { titleId = type.ID, typeTitle = type.Title }).ToList();
            cbFilter.ItemsSource = agentTypes.Append(new { titleId = 0, typeTitle = "Все типы" }).Reverse().ToList();
            cbFilter.DisplayMemberPath = "typeTitle";
            cbFilter.SelectedValuePath = "titleId";
            cbFilter.SelectedValue = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(owner.CanGoBack)
                owner.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            lvAgents.SelectedValue = btn.Uid;
            Agent agent = (Agent)lvAgents.SelectedItem;
            AgentEditWindow editWindow = new AgentEditWindow(agent.ID);
            
            if(editWindow.ShowDialog() == true)
            {
                prepareAgents();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AgentEditWindow editWindow = new AgentEditWindow();

            if (editWindow.ShowDialog() == true)
            {
                prepareAgents();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Внимание!", "Удалаить агента?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                Button btnDelete = (Button)sender;
                Agent agent = Agents.Where(a => a.ID == int.Parse(btnDelete.Uid.ToString())).FirstOrDefault();
                agent.IsDeleted = true;
                prepareAgents();
            }
        }


        private void loadAgents()
        {
            Agents = dbContext.db.Agent.ToList().Where(a => a.IsDeleted == false).ToList();
        }

        private void listViewRefresh()
        {
            lvAgents.ItemsSource = Agents;
            lvAgents.Items.Refresh();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchText = tbSearch.Text;
            prepareAgents();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agentsSortType = cbSort.SelectedValue.ToString();
            prepareAgents();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agentTypeId = int.Parse(cbFilter.SelectedValue.ToString());
            prepareAgents();
        }

        private void prepareAgents()
        {
            loadAgents();
            searchAgents();
            sortAgents();
            fitlerAgents();
            listViewRefresh();
        }

        private void fitlerAgents()
        {
            if (agentTypeId != 0)
            {
                Agents = Agents.Where(a => a.AgentTypeID == agentTypeId).ToList();
            }
        }

        private void searchAgents()
        {
            Agents = Agents.Where(a =>
            (a.Title +
            a.SalesPerYear.ToString() +
            a.Phone.ToString())
            .ToLower()
            .Contains(searchText.ToLower())).ToList();
        }

        private void sortAgents()
        {
            string type = agentsSortType;
            if (type == "От А до Я")
            {
                Agents = Agents.OrderBy(a => a.Title).ToList();
            }
            else if (type == "От Я до А")
            {
                Agents = Agents.OrderByDescending(a => a.Title).ToList();
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
