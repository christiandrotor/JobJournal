using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;
using System.Data.Common;
using System.Data;

namespace JobJournal
{

    public class Jobs
    {
        public Dictionary<string, Job> jobs;
        
        public Jobs()
        {
            jobs = new Dictionary<string, Job>();
            jobs.Add("InsightSoftware", new Job("InsightSoftware", "Vaco"));
            jobs.Add("KellyServices", new Job("KellyServices", "LinkedIn"));
        }

        public bool GetJob(string job)
        {
            if (!jobs.TryGetValue(job, out Job temp))
            {
                return false;
            }
            return true;
        }

        public void RemoveJob(string job)
        {
            jobs.Remove(job);
        }

        public List<Job> GetList()
        {
            return jobs.Values.ToList();
        }
    }
    public class Job
    {
        public string Name { get; private set; }
        public DateTime AppDate { get; private set; }
        public string AppSource { get; private set; }

        public Job(string name, string source)
        {
            Name = name;
            AppSource = source;
            AppDate = DateTime.Today;
        }
    }

    public class JobFactory
    {
        public static void  getDatabase()
        {
            if (!File.Exists("JobJournal.sdf"))
                File.Create("JobJournal.sdf");

            SqlCeConnection connection = new SqlCeConnection();

            try
            {
                connection = new SqlCeConnection("Data Source='JobJournal.sdf';");
                connection.Open();
                //DbCommand command = connection.CreateCommand();
                //command.CommandText = @"
                //                        SELECT COLUMN_NAME
                //                        FROM INFORMATION_SCHEMA.COLUMNS
                //                        WHERE TABLE_NAME='Jobs'";

                //DbDataReader reader = command.ExecuteReader();
                //while (reader.Read()) {
                //    System.Diagnostics.Debug.WriteLine(reader[0]);
                //}

                System.Diagnostics.Debug.WriteLine(connection.Database);
            } catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("There was a problem connecting to the database\nMessage: " + ex.Message);
            } finally
            {
                connection.Close();
            }
        }
    }
}
