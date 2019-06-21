using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CourseKeeper.Models;
using CourseKeeper.Views;
using CourseKeeper.ViewModels;
using Plugin.LocalNotifications;

namespace CourseKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var term = args.SelectedItem as Term;
            if (term == null)
                return;

            await Navigation.PushAsync(new TermDetailPage(term));

            // Manually de-select item.
            ItemsListView.SelectedItem = null;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //if (viewModel.Terms.Count == 0)
        //    //viewModel.LoadItemsCommand.Execute(null);
        //}
    }
}