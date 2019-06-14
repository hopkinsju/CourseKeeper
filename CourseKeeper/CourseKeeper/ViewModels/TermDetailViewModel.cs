using System;
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
		private Term thisTerm = new Term();
		public Term Term { 
			get
			{
				return thisTerm;
			}
			set
			{
				thisTerm = value;
				OnPropertyChanged();
			}
		}
		public string TermName
		{
			get
			{
				return Term.Name;
			}
			set
			{
				Term.Name = value;
				OnPropertyChanged();
			}
		}
		public string TermStartDate
		{
			get
			{
				return TermStartDate;
			}
			set
			{
				TermStartDate = value;
				OnPropertyChanged();
			}
		}
		public string TermEndDate
		{
			get
			{
				return TermEndDate;
			}
			set
			{
				TermEndDate = value;
				OnPropertyChanged();
			}
		}
		public int TermID { get; set; }
		public ObservableCollection<Course> CourseList { get; set; }
		public bool ShowCourseLabel { get; set; }
		public Command LoadItemsCommand { get; set; }

		public TermDetailViewModel(Term term = null)

		{
			Term = term;
			TermID = term.ID;
			//UpdateFields(term);
			CourseList = new ObservableCollection<Course>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			//GetCourses();

			if (CourseList.Count > 0)
			{
				ShowCourseLabel = true;
			}

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
			TermID = term.ID;
		}

		private async void GetCourses()
		{
			List<Course> courses = await App.Database.GetCoursesAsync(Term);
			foreach (Course course in courses)
			{
				CourseList.Add(course);
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

	}
}
