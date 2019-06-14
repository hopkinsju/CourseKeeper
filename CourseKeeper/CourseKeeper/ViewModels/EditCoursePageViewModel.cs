using System;
using CourseKeeper.Models;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class EditCoursePageViewModel : BaseViewModel
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
		public int CourseID { get; set; }

		public EditCoursePageViewModel(Course course)
		{
			CourseID = course.ID;
			Name = course.Name;
			StartDate = course.StartDate;
			EndDate = course.EndDate;
				Status = course.Status;
			InstructorName = course.InstructorName;
			InstructorPhone = course.InstructorPhone;
			InstructorEmail = course.InstructorEmail;
			Notes = course.Notes;
				Notifications = course.Notifications;
		}
		public void SaveCourse(Course course)
		{
			App.Database.SaveCourseAsync(course);
			MessagingCenter.Send(this, "UpdateCourse", course);
		}
	}
}
