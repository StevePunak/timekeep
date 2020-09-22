using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtil.Database;

namespace TimeKeep
{
	class TimeCardEntryList : List<TimeCardEntry_DO> { }
	class TimeCardEntry_DO : ICloneable
	{
		[ColumnName("id", "entry_id")]
		public UInt32 ID { get; set; }
		[ColumnName("start_time")]
		public DateTime Start { get; set; }
		[ColumnName("end_time")]
		public DateTime End { get; set; }
		[ColumnName("memo")]
		public String Memo { get; set; }

		public Project_DO Project { get; set; }

		public bool IsValid 
		{  
			get 
			{
				return ID > 0 && Start != DateTime.MinValue && End != DateTime.MinValue && Start < End;
			} 
		}

		public TimeCardEntry_DO()
		{
			Project = new Project_DO();
		}

		public override string ToString()
		{
			return $"From {Start} to  {End} {Memo}";
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
