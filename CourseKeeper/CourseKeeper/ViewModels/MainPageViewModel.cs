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
        public ObservableCollection<Term> Terms { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MainPageViewModel()
        {
            Title = "CourseKeeper";
            Terms = new ObservableCollection<Term>();
           	LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			PopulateTerms();

            MessagingCenter.Subscribe<NewTermPage, Term>(this, "AddItem", (obj, term) =>
            {
				Terms.Add(term);
            });
			MessagingCenter.Subscribe<TermDetailPage, Term>(this, "TermDelete", (obj, term) =>
			{
				Terms.Remove(term);
			});
		}

		private async void PopulateTerms()
		{
			List<Term> terms = await App.Database.GetTermsAsync();
			foreach (Term term in terms)
			{
				Terms.Add(term);
			}
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