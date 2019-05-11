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
using JobJournal;

namespace JobJournal
{
    /// <summary>
    /// Interaction logic for JobResult.xaml
    /// </summary>
    public partial class JobList : Page
    {
        private Jobs j = new Jobs();
        public JobList()
        {
            InitializeComponent();
            GridJobList.DataContext = j.GetList();
        }
    }
}
