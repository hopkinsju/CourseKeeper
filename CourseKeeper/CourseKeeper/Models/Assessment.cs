using System;
using System.Collections.Generic;
using System.Text;

namespace CourseKeeper.Models
{
    public class Assessment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Notifications { get; set; }
    }
}
