using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmaTest.Models
{
    public class ModulesViewModel
    {
        public List<Modules> Modules { get; set; }
    }

    public class MainTableViewModel
    {
        public List<MainTable> Clients { get; set; }
        public string Client { get; set; }
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
    }
}