using System;
using System.Collections.Generic;
using CourseKeeper.Models;

namespace CourseKeeper.ViewModels
{
    public class TermDetailViewModel : BaseViewModel
    {
        public Term Item { get; set; }
        public List<Course> CourseList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TermDetailViewModel(Term term = null)
        {
            Title = term?.Name;
            Item = term;
            CourseList = term.CourseList;
            StartDate = term.StartDate;
            EndDate = term.EndDate;
        }
    }
}
