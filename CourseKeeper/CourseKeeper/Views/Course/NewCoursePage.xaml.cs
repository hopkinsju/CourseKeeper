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

		NewCoursePageViewModel viewModel;
		public Term Term { get; set; }

		public NewCoursePage(Term term)
		{
			InitializeComponent();
			Term = term;
			BindingContext = viewModel = new NewCoursePageViewModel(Term);
		}
	}
}
