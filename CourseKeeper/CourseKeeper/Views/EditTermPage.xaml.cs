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
    public partial class EditTermPage : ContentPage
    {
		EditTermPageViewModel vm;
		public Term Term { get; set; }
        public EditTermPage(EditTermPageViewModel viewModel)
        {
            InitializeComponent();
			Term = viewModel.Term;
			BindingContext = vm = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
			vm.UpdateTerm(Term);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}