using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
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
    /// Логика взаимодействия для AgentEditPage.xaml
    /// </summary>
    public partial class AgentEditWindow : Window
    {
        public int id;
        private Agent agent;

        public AgentEditWindow()
        {
            InitializeComponent();
            dbContext.db.AgentType.Load();
            cbType.ItemsSource = dbContext.db.AgentType.ToList();
            cbType.SelectedValuePath = "ID";
            cbType.DisplayMemberPath = "Title";
            cbType.SelectedIndex = 0;
            agent = new Agent();

            if(id > 0)
            {
                agent = dbContext.db.Agent.Where(a => a.ID == id).FirstOrDefault();
                tbName.Text = agent.Title;
                tbPhone.Text = agent.Phone;
                tbPreority.Text = agent.Priority.ToString();
                cbType.SelectedValue = agent.AgentTypeID;
            }
        }
        public AgentEditWindow()
        {
            InitializeComponent();
            dbContext.db.AgentType.Load();
            cbType.ItemsSource = dbContext.db.AgentType.ToList();
            cbType.SelectedValuePath = "ID";
            cbType.DisplayMemberPath = "Title";
            cbType.SelectedIndex = 0;
            agent = new Agent();

            if (id > 0)
            {
                agent = dbContext.db.Agent.Where(a => a.ID == id).FirstOrDefault();
                tbName.Text = agent.Title;
                tbPhone.Text = agent.Phone;
                tbPreority.Text = agent.Priority.ToString();
                cbType.SelectedValue = agent.AgentTypeID;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if(tbName.Text != "")
            {
                if(cbType.SelectedItem != null)
                {
                    if (tbPhone.Text != "")
                    {
                        if (tbPreority.Text != "")
                        {
                            agent.Title = tbName.Text;
                            agent.Phone = tbPhone.Text;
                            int priority;
                            if(int.TryParse(tbPreority.Text, out priority))
                            {
                                agent.Priority = priority;
                            }
                            agent.AgentTypeID = int.Parse(cbType.SelectedValue.ToString());
                            if( id == 0)
                            {
                                dbContext.db.Agent.Add(agent);
                                this.Close();
                            }
                            else
                            {

                            }
                        }
                        else { MessageBox.Show("Error!", "Введены не парвильные данные! (Приоритет)", MessageBoxButton.OK); }
                    }
                    else { MessageBox.Show("Error!", "Введены не парвильные данные! (Телефон)", MessageBoxButton.OK); }
                }
                else { MessageBox.Show("Error!", "Введены не парвильные данные! (Тип)", MessageBoxButton.OK); }
            }
            else { MessageBox.Show("Error!", "Введены не парвильные данные! (Название)", MessageBoxButton.OK); }
        }
    }
}
