using System;
using CourseKeeper.Models;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class NewCoursePageViewModel : BaseViewModel
	{
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Status { get; set; }
		public string InstructorName { get; set; }
		public string InstructorPhone { get; set; }
		public string InstructorEmail { get; set; }
		public string Notes { get; set; }
		public bool Notifications { get; set; }
		public int TermID { get; set; }

		public NewCoursePageViewModel(Term term)
		{
			TermID = term.ID;
		}
		public void AddCourse()
		{
			Course course = new Course
			{
				Name = Name,
				StartDate = StartDate,
				EndDate = EndDate,
				Status = Status,
				InstructorName = InstructorName,
				InstructorPhone = InstructorPhone,
				InstructorEmail = InstructorEmail,
				Notes = Notes,
				Notifications = Notifications,
				TermID = TermID
			};

			App.Database.SaveCourseAsync(course);
			MessagingCenter.Send(this, "AddCourse", course);
		}
	}
}
