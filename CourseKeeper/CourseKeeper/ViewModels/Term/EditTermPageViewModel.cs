using System;
using CourseKeeper.Models;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
	public class EditTermPageViewModel : BaseViewModel
	{
		public Term Term;
		public TermDetailViewModel DetailViewModel;
		public string TermName { 
			get
			{
				return Term.Name;
			} 
			set {
					DetailViewModel.Term.Name = value;
					OnPropertyChanged();
					OnPropertyChanged(DetailViewModel.TermName);
				
			} 
		}
		public DateTime TermStartDate { get; set; }
		public DateTime TermEndDate { get; set; }

		public EditTermPageViewModel(TermDetailViewModel vm)
		{
			DetailViewModel = vm;
			Term = DetailViewModel.Term;
			UpdateFields();
		}

		public void UpdateTerm(Term term)
		{
			DetailViewModel.Term = term;
			//term.Name = TermName;
			//term.StartDate = TermStartDate;
			//term.EndDate = TermEndDate;
			App.Database.SaveTermAsync(term);
			MessagingCenter.Send<EditTermPageViewModel, Term>(this, "UpdateTerm", term);
		}

		public void UpdateFields() {
			TermName = Term.Name;
			TermStartDate = Term.StartDate;
			TermEndDate = Term.EndDate;
		}

	}
}
