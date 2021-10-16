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

            cbFilter.Items.Add("Фильтрация");
            cbFilter.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(owner.CanGoBack)
                owner.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = (Agent)lvAgents.SelectedItem;
            AgentEditWindow editWindow = new AgentEditWindow(agent.ID);
            
            if(editWindow.ShowDialog() == true)
            {
                pageRefresh();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AgentEditWindow editWindow = new AgentEditWindow();

            if (editWindow.ShowDialog() == true)
            {
                pageRefresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Внимание!", "Удалаить агента?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                Button btnDelete = (Button)sender;
                Agent agent = Agents.Where(a => a.ID == int.Parse(btnDelete.Uid.ToString())).FirstOrDefault();
                agent.IsDeleted = true;
                pageRefresh();
            }
        }

        private void pageRefresh()
        {
            tbSearch.Text = "";
            loadAgents();
            listViewRefresh();
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
            lvAgents.ItemsSource = Agents.Where(a => (
            a.Title + a.SalesPerYear.ToString() + a.Phone.ToString()
            ).ToLower().Contains(tbSearch.Text.ToLower()));
            lvAgents.Items.Refresh();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string searchText = tbSearch.Text;
            if (cbSort.SelectedValue.ToString() == "От А до Я")
            {
                Agents = Agents.OrderBy(a => a.Title).ToList();
            }
            else if (cbSort.SelectedValue.ToString() == "От Я до А")
            {
                Agents = Agents.OrderByDescending(a => a.Title).ToList();
            }
            else
            {
                loadAgents();
            }
            listViewRefresh();
            if(searchText != "")
            {
                tbSearch.Text = searchText;
            }
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
