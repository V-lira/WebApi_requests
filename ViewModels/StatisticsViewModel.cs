using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.ViewModels
{
    public class StatisticsViewModel
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
        public int Cancelled { get; set; }
    }
}