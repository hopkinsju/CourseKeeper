using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CourseKeeper.Models;
using CourseKeeper.ViewModels;

namespace CourseKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TermDetailPage : ContentPage
    {
        TermDetailViewModel viewModel;

        public TermDetailPage(TermDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TermDetailPage()
        {
            InitializeComponent();

            var item = new Term
            {
                Name = "Term 1"
            };

            viewModel = new TermDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}