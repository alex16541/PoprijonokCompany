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
            lvAgents.ItemsSource = dbContext.db.Agent.ToList();
            lvAgents.SelectedValuePath = "ID";
            hideDeletedItem();

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
                dgRefresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Внимание!", "Удалаить агента?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                Button btnEdit = (Button)sender;
                Agent agent = dbContext.db.Agent.Where(a => a.ID == int.Parse(btnEdit.Uid.ToString())).FirstOrDefault();
                agent.IsDeleted = true;
                dgRefresh();
            }
        }
        private void dgRefresh()
        {
            lvAgents.ItemsSource = dbContext.db.Agent.ToList();
            lvAgents.Items.Refresh();
            hideDeletedItem();
        }
        private void hideDeletedItem()
        {
            //foreach (item in lvAgents.Items)
            //{
            //    if ((item.DataContext as Agent).IsDeleted)
            //    {
            //        item.Visibility = Visibility.Collapsed;
            //    }
            //}
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
