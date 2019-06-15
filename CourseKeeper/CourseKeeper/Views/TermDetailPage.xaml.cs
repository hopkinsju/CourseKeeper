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
    public partial class TermDetailPage : ContentPage
    {
        TermDetailViewModel viewModel;
	//public Term Term { get; set; }

		public TermDetailPage(TermDetailViewModel vm)
        {
            InitializeComponent();
			BindingContext = viewModel = vm;
        }
        
		async void AddCourse_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushModalAsync(new NavigationPage(new NewCoursePage(viewModel.Term)));
        }

		//async void Delete_Clicked(object sender, EventArgs e)
		//{
		//	var answer = await DisplayAlert("Delete?", "Are you sure you want to delete this item?", "Yes", "No");
		//	if (answer)
		//	{
		//		await App.Database.DeleteTermAsync(viewModel.Term);
		//		MessagingCenter.Send(this, "TermDelete", viewModel.Term);	
		//		await Navigation.PopToRootAsync();
		//	}
		//}
		//async void Edit_Clicked(object sender, EventArgs e)
		//{
		//	await Navigation.PushAsync(new EditTermPage(new EditTermPageViewModel(viewModel)));
		//}
		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Course;
			if (item == null)
				return;

			await Navigation.PushAsync(new CourseDetailPage(new EditCoursePageViewModel(item)));

            // Manually de-select item.
			CourseListView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.LoadItemsCommand.Execute(null);
		}

	}
}