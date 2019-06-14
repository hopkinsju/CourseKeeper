using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CourseKeeper.Models;
using SQLite;
namespace CourseKeeper.Services
{
	public class CourseKeeperDatabase
	{
		readonly SQLiteAsyncConnection database;

		public CourseKeeperDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTablesAsync<Term, Course, Assessment>().Wait();
		}

		public Task<List<Term>> GetTermsAsync()
		{
			return database.Table<Term>().ToListAsync();
		}

		public Task<Term> GetTermAsync(int id)
		{
			return database.Table<Term>()
				.Where(i => i.ID == id)
				.FirstOrDefaultAsync();
		}

		public Task<int> SaveTermAsync(Term term)
		{
			if (term.ID == 0)
			{
				return database.InsertAsync(term);
			}
			else
			{
				return database.UpdateAsync(term);
			}
		}

		public Task<int> DeleteTermAsync(Term term)
		{
			return database.DeleteAsync(term);
		}

		public Task<List<Course>> GetCoursesAsync(Term term)
		{
			return database.Table<Course>()
				.Where(a => a.TermID == term.ID).ToListAsync();
		}

		public Task<int> SaveCourseAsync(Course course)
		{
			if (course.ID == 0)
			{
				return database.InsertAsync(course);
			}
			else
			{
				return database.UpdateAsync(course);
			}
		}
		public Task<int> DeleteCourseAsync(Course course)
		{
			return database.DeleteAsync(course);
		}

   	}

}
