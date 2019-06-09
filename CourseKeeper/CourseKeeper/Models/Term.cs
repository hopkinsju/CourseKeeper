using System;
using System.Collections.Generic;

namespace CourseKeeper.Models
{
    public class Term
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Course> CourseList { get; set; }
    }
}