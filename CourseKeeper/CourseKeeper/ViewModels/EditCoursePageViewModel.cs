using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseKeeper.Models;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class EditCoursePageViewModel : BaseViewModel
	{
        private Course _course;
        public string Name
        {
            get { return _course.Name; }
            set { _course.Name = value; OnPropertyChanged(); }
        }
		public DateTime StartDate
        {
            get { return _course.StartDate; }
            set { _course.StartDate = value; OnPropertyChanged(); }
        }
		public DateTime EndDate
        {
            get { return _course.EndDate; }
            set { _course.EndDate = value; OnPropertyChanged(); }
        }
		public string CurrentStatus
        {
            get { return _course.Status; }
            set { _course.Status = value; OnPropertyChanged(); }
        }
        public List<string> StatusList { get; } = new List<string> { "Enrolled", "Not Enrolled" };
        public string InstructorName
        {
            get { return _course.InstructorName; }
            set { _course.InstructorName = value; OnPropertyChanged(); }
        }
		public string InstructorPhone
        {
            get { return _course.InstructorPhone; }
            set { _course.InstructorPhone = value; OnPropertyChanged(); }
        }
		public string InstructorEmail
        {
            get { return _course.InstructorEmail; }
            set { _course.InstructorEmail = value; OnPropertyChanged(); }
        }
		public string Notes
        {
            get { return _course.Notes; }
            set { _course.Notes = value; OnPropertyChanged(); }
        }
		public bool Notifications
        {
            get { return _course.Notifications; }
            set { _course.Notifications = value; OnPropertyChanged(); }
        }
        public Command SaveCourseCommand { get; set; }
        public Command CancelEditCommand { get; set; }

		public EditCoursePageViewModel(Course course)
		{
            _course = course;
            SaveCourseCommand = new Command(async () => await ExecuteSaveCourseCommand());
            CancelEditCommand = new Command(async () => await ExecuteCancelEditCommand());
        }
		public void SaveCourse()
		{
			App.Database.SaveCourseAsync(_course);
			MessagingCenter.Send(this, "UpdateCourse", _course);
		}

        async Task ExecuteSaveCourseCommand()
        {
            await App.Database.SaveCourseAsync(_course);
            await App.Current.MainPage.Navigation.PopAsync();
            MessagingCenter.Send(this, "UpdateCourse", _course);
        }

        async Task ExecuteCancelEditCommand()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
	}
}
