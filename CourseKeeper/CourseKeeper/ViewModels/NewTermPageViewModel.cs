using System;
using CourseKeeper.Models;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class NewTermPageViewModel : BaseViewModel
	{
		public string TermName { get; set; }
		public DateTime TermStartDate { get; set; }
		public DateTime TermEndDate { get; set; }
	

		public void AddTerm()
		{
			Term term = new Term();
			term.Name = TermName;
			term.StartDate = TermStartDate;
			term.EndDate = TermEndDate;
			App.Database.SaveTermAsync(term);
			MessagingCenter.Send(this, "AddItem", term);
		}
	}
}
