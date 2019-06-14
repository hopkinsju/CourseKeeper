﻿using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace CourseKeeper.Models
{
	public class Assessment
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Notifications { get; set; }
        public int CourseID { get; set; }
	}
}
