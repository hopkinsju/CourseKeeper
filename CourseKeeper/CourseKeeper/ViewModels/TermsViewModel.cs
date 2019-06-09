using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CourseKeeper.Models;
using CourseKeeper.Views;

namespace CourseKeeper.ViewModels
{
    public class TermsViewModel : BaseViewModel
    {
        public ObservableCollection<Term> Terms { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TermsViewModel()
        {
            Title = "CourseKeeper";
            Terms = new ObservableCollection<Term>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewTermPage, Term>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Term;
                Terms.Add(newItem);
                await DataStore.SaveItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Terms.Clear();
                var items = await DataStore.GetItemsAsync();
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