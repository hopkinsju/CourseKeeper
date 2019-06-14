using System;
using System.Collections.Generic;
using System.ComponentModel;
using CourseKeeper.Models;
using CourseKeeper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CourseKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[DesignTimeVisible(false)]
	public partial class EditCoursePage : ContentPage
	{

		EditCoursePageViewModel vm;
		public Course Course { get; set; }

		public EditCoursePage(Course course)
		{
			InitializeComponent();
			Course = course;
			vm = new EditCoursePageViewModel(Course);
			BindingContext = vm;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			vm.SaveCourse(Course);
			await Navigation.PopAsync();
			MessagingCenter.Send(this, "UpdateCourse");
		}

		async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
