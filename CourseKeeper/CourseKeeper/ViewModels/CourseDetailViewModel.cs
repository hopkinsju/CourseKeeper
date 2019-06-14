using System;
using CourseKeeper.Models;
using CourseKeeper.Views;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class CourseDetailViewModel : BaseViewModel
	{
		public Course Course { get; set; }
		public string Name { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Status { get; set; }
		public string InstructorName { get; set; }
		public string InstructorPhone { get; set; }
		public string InstructorEmail { get; set; }
		public string Notes { get; set; }
		public bool Notifications { get; set; }

		public CourseDetailViewModel(Course course)
		{
			Name = course.Name;
			StartDate = course.StartDate.ToShortDateString();
			EndDate = course.EndDate.ToShortDateString();
			Status = course.Status;
			InstructorName = course.InstructorName;
			InstructorPhone = course.InstructorPhone;
			InstructorEmail = course.InstructorEmail;
			Notes = course.Notes;
			Notifications = course.Notifications;
			Course = course;

			//MessagingCenter.Subscribe<EditCoursePage, Course>(this, "UpdateCourse", async (obj, Course) =>
			//{
			//	Name = Course.Name;
			//});
		}
	}
}
