using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
