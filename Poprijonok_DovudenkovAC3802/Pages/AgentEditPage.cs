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
using Microsoft.Win32;
using System.IO;

namespace Poprijonok_DovudenkovAC3802
{
    /// <summary>
    /// Логика взаимодействия для AgentEditPage.xaml
    /// </summary>
    public partial class AgentEditWindow : Window
    {
        public int id;
        private bool isEdited = false;
        private Agent agent;
        private string logoPath;

        public AgentEditWindow()
        {
            InitComponents();

            if(id > 0)
            {
                agent = dbContext.db.Agent.Where(a => a.ID == id).FirstOrDefault();
                tbName.Text = agent.Title;
                tbPhone.Text = agent.Phone;
                tbPreority.Text = agent.Priority.ToString();
                cbType.SelectedValue = agent.AgentTypeID;
            }
        }
        public AgentEditWindow(int id)
        {
            InitComponents();
            this.id = id;
            isEdited = true;
            agent = dbContext.db.Agent.Where(a => a.ID == id).FirstOrDefault();
            tbName.Text = agent.Title;
            tbPhone.Text = agent.Phone;
            tbPreority.Text = agent.Priority.ToString();
            cbType.SelectedValue = agent.AgentTypeID;
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
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
                            //agent.Logo = logoPath;
                            int priority;
                            if(int.TryParse(tbPreority.Text, out priority))
                            {
                                agent.Priority = priority;
                            }
                            agent.AgentTypeID = int.Parse(cbType.SelectedValue.ToString());
                            if(!isEdited)
                            {
                                dbContext.db.Agent.Add(agent);   
                            }
                            dbContext.db.SaveChanges();
                            DialogResult = true;
                            this.Close();
                        }
                        else { MessageBox.Show("Error!", "Введены не парвильные данные! (Приоритет)", MessageBoxButton.OK); }
                    }
                    else { MessageBox.Show("Error!", "Введены не парвильные данные! (Телефон)", MessageBoxButton.OK); }
                }
                else { MessageBox.Show("Error!", "Введены не парвильные данные! (Тип)", MessageBoxButton.OK); }
            }
            else { MessageBox.Show("Error!", "Введены не парвильные данные! (Название)", MessageBoxButton.OK); }
        }
        private void InitComponents()
        {
            InitializeComponent();
            dbContext.db.AgentType.Load();
            cbType.ItemsSource = dbContext.db.AgentType.ToList();
            cbType.SelectedValuePath = "ID";
            cbType.DisplayMemberPath = "Title";
            cbType.SelectedIndex = 0;
            agent = new Agent();
        }

        private void btnLoadLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog save = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png"
            };

            if (save.ShowDialog() == true)
            {
                Uri uri = new Uri(save.FileName);
                var bitmap = new BitmapImage(uri);
                logoPath = @"\agents\" + save.SafeFileName;
                imgLogo.Source = bitmap;
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (var stream = new FileStream(@"../../Resource/agents/"+save.SafeFileName,FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
        }
    }
}
