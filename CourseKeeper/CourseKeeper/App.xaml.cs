using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseKeeper.Services;
using CourseKeeper.Views;
using System.IO;

namespace CourseKeeper
{
    public partial class App : Application
    {
		static CourseKeeperDatabase database;

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new TermsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

		public static CourseKeeperDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new CourseKeeperDatabase(
						DependencyService.Get<IFileHelper>().GetLocalFilePath("CourseKeeperSQLite.db3"));
				}
				return database;
			}
		}

    }
}
