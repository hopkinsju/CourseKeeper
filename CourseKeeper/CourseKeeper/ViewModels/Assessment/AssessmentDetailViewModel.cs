using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseKeeper.Models;
using CourseKeeper.Views;
using Xamarin.Forms;

namespace CourseKeeper.ViewModels
{
    class AssessmentViewModel : BaseViewModel
    {
        private Assessment _assessment;
        public Assessment Assessment
        {
            get
            {
                return _assessment;
            }
            set
            {
                _assessment = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get
            {
                return _assessment.Name;
            }
            set
            {
                _assessment.Name = value;
                OnPropertyChanged();
            }
        }
        public string DueDate
        {
            get
            {
                return _assessment.DueDate.ToShortDateString();
            }
            set
            {
                _assessment.DueDate = DateTime.Parse(value);
                OnPropertyChanged();
            }
        }
        public string AssessmentType
        {
            get
            {
                return _assessment.AssessmentType;
            }
            set
            {
                _assessment.AssessmentType = value;
                OnPropertyChanged();
            }
        }
        public bool Notifications
        {
            get
            {
                return _assessment.Notifications;
            }
            set
            {
                _assessment.Notifications = value;
                OnPropertyChanged();
            }
        }
        public int CourseID
        {
            get
            {
                return _assessment.CourseID;
            }
            set
            {
                _assessment.CourseID = value;
                OnPropertyChanged();
            }
        }
        public Assessment ObjectiveAssessment { get; set; }
        public Assessment PerformanceAssessment { get; set; }
        public Command SaveAssessmentCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command EditAssessmentCommand { get; set; }
        public Command DeleteAssessmentCommand { get; set; }

        // Base for creating commands
        public AssessmentViewModel()
        {
            SaveAssessmentCommand = new Command(async () => await ExecuteSaveAssessmentCommand());
            CancelCommand = new Command(async () => await App.Current.MainPage.Navigation.PopAsync());
            EditAssessmentCommand = new Command(async () => await ExecuteEditAssessmentCommand());
            DeleteAssessmentCommand = new Command(async () => await ExecuteDeleteAssessmentCommand());

        }
        // For modifying or displaying EditAssessementPage
        public AssessmentViewModel(Assessment assessment)
            : this()
        {
            Assessment = assessment;
        }

        // For creating new NewAssessmentPage
        public AssessmentViewModel(Course course, bool isNew)
            : this()
        {
            Assessment = new Assessment();
            CourseID = course.ID;
        }

        // For displaying list of both assessments: AssessmentDetailPage
        public AssessmentViewModel(Course course)
            : this()
        {
            ObjectiveAssessment = GetAssessmentObjective(course.ID);
            PerformanceAssessment = GetAssessmentPerformance(course.ID);
        }

        async Task<Assessment> GetAssessmentObjective(int courseID)
        {
            return await App.Database.GetAssessmentObjective(courseID);
        }

        async Task<Assessment> GetAssessmentPerformance(int courseID)
        {
            return await App.Database.GetAssessmentPerformance(courseID);
        }

        async Task ExecuteSaveAssessmentCommand()
        {
            await App.Database.SaveAssessmentAsync(Assessment);
        }

        async Task ExecuteEditAssessmentCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditAssessmentPage(Assessment));
        }
        async Task ExecuteDeleteAssessmentCommand()
        {
            await App.Database.DeleteAssessmentAsync(Assessment);
        }
    }
}
