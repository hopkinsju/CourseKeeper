using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CourseKeeper.Models;
using CourseKeeper.Views;
using System.Collections.Generic;

namespace CourseKeeper.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Term> _terms;
        public ObservableCollection<Term> Terms
        {
            get
            {
                return _terms;
            }
            set
            {
                _terms = value;
                OnPropertyChanged();
            }
        }
        public Command LoadItemsCommand { get; set; }
        public Command AddTermCommand { get; set; }

        public MainPageViewModel()
        {
            Title = "CourseKeeper";
            _terms = new ObservableCollection<Term>();
           	LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddTermCommand = new Command(async () => await ExecuteAddTermCommand());
            PopulateTerms();

            MessagingCenter.Subscribe<NewTermPageViewModel, Term>(this, "AddTerm", (sender, obj) =>
            {
				Terms.Add(obj);
            });
			MessagingCenter.Subscribe<TermDetailViewModel, Term>(this, "TermDelete", (sender, obj) =>
			{
				Terms.Remove(obj);
			});
            MessagingCenter.Subscribe<NewTermPageViewModel>(this, "TermUpdate", async (obj) =>
            {
                await ExecuteLoadItemsCommand();
            });

        }

        private async void PopulateTerms()
		{
			List<Term> terms = await App.Database.GetTermsAsync();
            Terms.Clear();
			foreach (Term term in terms)
			{
				Terms.Add(term);
			}
		}

        async Task ExecuteAddTermCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTermPage());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Terms.Clear();
                var items = await App.Database.GetTermsAsync();
                foreach (var item in items)
                {
                    Terms.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}