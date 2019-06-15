using System;
using System.ComponentModel;
using System.Collections.Generic;
using CourseKeeper.Models;
using System.Threading.Tasks;
using SQLite;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using CourseKeeper.Views;
using System.Diagnostics;

namespace CourseKeeper.ViewModels
{
	public class TermDetailViewModel : BaseViewModel
	{
		private Term _term = new Term();
        private bool _showCourseLabel = false;
        // I don't think I need this
        public Term Term
        {
            get
            {
                return _term;
            }
            set
            {
                _term = value;
                OnPropertyChanged();
            }
        }

        #region Props
        public string TermName
		{
			get
			{
				return _term.Name;
			}
			set
			{
				_term.Name = value;
				OnPropertyChanged();
			}
		}
		public string TermStartDate
		{
			get
			{
				return _term.StartDate.ToShortDateString();
			}
			set
			{
				_term.StartDate = DateTime.Parse(value);
				OnPropertyChanged();
			}
		}
		public string TermEndDate
		{
			get
			{
				return _term.EndDate.ToShortDateString();
			}
			set
			{
                _term.EndDate = DateTime.Parse(value);
                OnPropertyChanged();
			}
		}
        public ObservableCollection<Course> CourseList { get; set; }
        public bool ShowCourseLabel {
            get
            {
                return _showCourseLabel;
            }
            set
            {
                _showCourseLabel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public Command LoadItemsCommand { get; set; }
        public Command EditTermCommand { get; set; }
        public Command DeleteTermCommand { get; set; }
        #endregion

        public TermDetailViewModel(Term term = null)

		{
			_term = term;
			CourseList = new ObservableCollection<Course>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            EditTermCommand = new Command(async () => await ExecuteEditTermCommand());
            DeleteTermCommand = new Command(async () => await ExecuteDeleteTermCommand());
			GetCourses();

			

			MessagingCenter.Subscribe<NewCoursePage, Course>(this, "AddCourse", (obj, course) =>
			{
				CourseList.Add(course);
			});
			MessagingCenter.Subscribe<EditTermPageViewModel, Term>(this, "UpdateTerm", (sender, obj) =>
			{
				UpdateFields(obj);
			});

		}

        public void UpdateFields(Term term)
		{
			TermName = term.Name;
			TermStartDate = term.StartDate.ToShortDateString();
			TermEndDate = term.EndDate.ToShortDateString();
		}

		private async void GetCourses()
		{
			List<Course> courses = await App.Database.GetCoursesAsync(_term);
			foreach (Course course in courses)
			{
				CourseList.Add(course);
			}
            if (CourseList.Count > 0)
            {
                ShowCourseLabel = true;
            }
        }

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				CourseList.Clear();
				var items = await App.Database.GetCoursesAsync(Term);
				foreach (var item in items)
				{
					CourseList.Add(item);
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
        async Task ExecuteEditTermCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditTermPage(new EditTermPageViewModel(this)));
        }
        async Task ExecuteDeleteTermCommand()
        {
            var answer = await App.Current.MainPage.DisplayAlert("Delete?", "Are you sure you want to delete this item?", "Yes", "No");
            if (answer)
            {
                await App.Database.DeleteTermAsync(_term);
                MessagingCenter.Send(this, "TermDelete", _term);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

	}
}
