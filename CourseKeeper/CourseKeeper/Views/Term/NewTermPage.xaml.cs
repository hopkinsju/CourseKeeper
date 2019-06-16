using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CourseKeeper.Models;
using CourseKeeper.ViewModels;

namespace CourseKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class NewTermPage : ContentPage
    {
		NewTermPageViewModel vm;
		public Term Term { get; set; }
        public NewTermPage()
        {
            InitializeComponent();
			vm = new NewTermPageViewModel();
			BindingContext = vm;
			//Term = new Term();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
			vm.AddTerm();
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}