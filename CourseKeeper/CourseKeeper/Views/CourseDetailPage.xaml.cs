using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CourseKeeper.Models;
using CourseKeeper.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CourseKeeper.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class CourseDetailPage : ContentPage
	{
        EditCoursePageViewModel viewModel;
		public Course Course { get; set; }

		public CourseDetailPage(EditCoursePageViewModel vm)
		{
			InitializeComponent();
			BindingContext = viewModel = vm;
			//Course = viewModel.Course;
		}

		public CourseDetailPage(Course course)
		{
			InitializeComponent();
			Course = course;
			BindingContext = viewModel = new EditCoursePageViewModel(Course);
		}

		async void OnListViewItemSelected(Course course)
		{
		}
		async void Delete_Clicked(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("Delete?", "Are you sure you want to delete this item?", "Yes", "No");
			if (answer)
			{
				await App.Database.DeleteCourseAsync(Course);
				MessagingCenter.Send(this, "CourseDelete", Course);
				await Navigation.PopToRootAsync();
			}
		}
		async void Edit_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EditCoursePage(Course));
		}
	}
}