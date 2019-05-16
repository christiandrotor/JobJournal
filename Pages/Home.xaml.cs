using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
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
using JobJournal;
using Microsoft.EntityFrameworkCore;

namespace JobJournal
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private JobJournalContext db = new JobJournalContext();
        public Home()
        {
            InitializeComponent();
        }

        private void View_All_Click(object sender, RoutedEventArgs e)
        {
            JobList jobs = new JobList();
            this.NavigationService.Navigate(jobs);
            foreach(Control c in AddGrid.Children)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Text = "";
                }
            }

            RemoveCompanyName.Text = "";
            searchBox.Text = "search";

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // showing simple query in SQL
            string query = @"
                            SELECT *
                            FROM Jobs
                            WHERE CompanyName=@CompanyName";
            int exist = db.Jobs.FromSql(query, new SqlCeParameter("@CompanyName", searchBox.Text)).Count();
            if (exist == 0)
            {
                Message.Text = "You have not applied to " + searchBox.Text;
            }
            else
            {
                Message.Text = "You have already applied to " + searchBox.Text;
            }
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (AddCompanyName.Text == "" || AddAppliedDate.Text == "" || AddApplicationSource.Text == "")
                return;
            if (db.Jobs.Where(x => x.CompanyName.Equals(AddCompanyName.Text)).Count() == 0)
            {
                db.Jobs.Add(new Job { CompanyName = AddCompanyName.Text, AppliedDate = AddAppliedDate.SelectedDate.Value, ApplicationSource = AddApplicationSource.Text });
                db.SaveChanges();
                AddAppliedDate = new DatePicker();
                AddApplicationSource.Text = "";

                MessageBox.Show("The company " + AddCompanyName.Text + " was successfully added to the database");
                AddCompanyName.Text = "";

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Job> find = db.Jobs.Where(x => x.CompanyName.Equals(RemoveCompanyName.Text));
            int resultAmt = find.Count();
            if (resultAmt == 1)
            {
                db.Jobs.Remove(find.First());
                db.SaveChanges();
                MessageBox.Show("The company " + RemoveCompanyName.Text + " was successfully removed from the database");
            }
            else if (resultAmt > 1)
            {
                throw new Exception("There were more than 2 results returned when searching database to remove");
            }

            RemoveCompanyName.Text = "";
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text.Equals("search"))
            {
                searchBox.Text = "";
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text.Equals(""))
            {
                searchBox.Text = "search";
            }
        }
    }
}
