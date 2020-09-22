using CommonUtil.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeep
{
	class ProjectList : List<Project_DO> { }
	class Project_DO
	{
		[ColumnName("id", "project_id")]
		public UInt32 ID { get; set; }
		[ColumnName("name", "project_name")]
		public String Name { get; set; }
		public Project_DO()
		{
			ID = 0;
			Name = String.Empty;
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}
