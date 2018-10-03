using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWebAPI.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Priority { get; set; }
        public DateTime TaskDate { get; set; }
        public double EstimatedCost { get; set; }
        public string Description { get; set; }
    }
}