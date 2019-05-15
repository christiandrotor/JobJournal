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
using System.Data.SqlServerCe;
using JobJournal;

namespace JobJournal
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Jobs jobs;
        public Home()
        {
            InitializeComponent();
            jobs = new Jobs();
            this.DataContext = this;
        }

        private void View_All_Click(object sender, RoutedEventArgs e)
        {
            JobFactory.getDatabase();
            JobList jobs = new JobList();
            this.NavigationService.Navigate(jobs);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(searchBox.Text.Equals("search"))
            {
                searchBox.Text = "";
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(searchBox.Text.Equals(""))
            {
                searchBox.Text = "search";
            }
        }
    }
}
