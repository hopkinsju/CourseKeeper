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
	public partial class NewCoursePage : ContentPage
	{

		NewCoursePageViewModel vm;
		public Term Term { get; set; }

		public NewCoursePage(Term term)
		{
			InitializeComponent();
			Term = term;
			vm = new NewCoursePageViewModel(Term);
			BindingContext = vm;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			vm.AddCourse();
			await Navigation.PopModalAsync();
		}

		async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
