using System;
using System.Collections.Generic;

namespace JobJournal
{
    public partial class Job
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime AppliedDate { get; set; }
        public string ApplicationSource { get; set; }
    }
}
