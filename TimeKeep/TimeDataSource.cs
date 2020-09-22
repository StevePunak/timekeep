using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtil.Conversions;
using CommonUtil.Database;
using CommonUtil.Extensions;

namespace TimeKeep
{
	[DatabaseVersion("0.1")]
	class TimeDataSource : DataSourceBase
	{
		public TimeDataSource(SqlDBCredentials sqlCredentials) 
			: base(sqlCredentials)
		{
		}

		public virtual DBResult EntriesForDateGet(DateTime day, out TimeCardEntryList entries)
		{
			entries = new TimeCardEntryList();
			DBResult result;

			QueryString sql = DB.Format(
				$"SELECT \n" +
				$"E.id as entry_id, \n" +
				$"E.start_time as start_time, \n" +
				$"E.end_time as end_time, \n" +
				$"E.memo as memo, \n" +
				$"P.id as project_id, \n" +
				$"P.name as project_name \n" +
				$"FROM timekeep.entries E  \n" +
				$"JOIN timekeep.projects P ON E.project_id = P.id \n" +
				$"WHERE  \n" + 
				$" (start_time >= '{day.Date.ToMySqlString()}' AND start_time <= '{(day.Date + TimeSpan.FromDays(1)).ToMySqlString()}') OR \n" +
				$" (end_time >= '{day.Date.ToMySqlString()}' AND end_time <= '{(day.Date + TimeSpan.FromDays(1)).ToMySqlString()}') \n"  +
				$"ORDER BY start_time ASC");
			DatabaseDataReader reader;
			result = DB.Query(sql, out reader);
			using(reader)
			{
				if(result.ResultCode == DBResult.Result.Success)
				{
					while(reader.Read())
					{
						TimeCardEntry_DO entry = DataReaderConverter.CreateClassFromDataReader<TimeCardEntry_DO>(reader);
						entry.Project = DataReaderConverter.CreateClassFromDataReader<Project_DO>(reader);
						entries.Add(entry);
					}
				}
			}
			return result;
		}

		public virtual DBResult TotalsForProjectDateRangeGet(UInt32 projectID, DateTime start, DateTime end, out TimeSpan totalTime)
		{
			totalTime = TimeSpan.Zero;
			DBResult result;

			QueryString sql = DB.Format(
				$" SELECT sec_to_time(A.totalsecs) as secs FROM \n" +
				$"(\n" +
				$"  SELECT sum(unix_timestamp(end_time) - unix_timestamp(start_time)) as totalsecs \n" +
				$"  FROM timekeep.entries  \n" +
				$"  WHERE  \n" +
				$"   (start_time >= '{start.ToMySqlString()}' AND start_time <= '{end.ToMySqlString()}') AND \n" +
				$"   project_id = {projectID} \n" +
				$")A");
			DatabaseDataReader reader;
			result = DB.Query(sql, out reader);
			using (reader)
			{
				if (result.ResultCode == DBResult.Result.Success)
				{
					if(reader.Read())
					{
						totalTime = DBUtil.GetTimeSpan(reader["secs"]);
					}
				}
			}
			return result;
		}

		public virtual DBResult ProjectsGet(out ProjectList projects)
		{
			projects = new ProjectList();
			DBResult result;

			QueryString sql = DB.Format(
				$"SELECT * FROM timekeep.projects ORDER by name");
			DatabaseDataReader reader;
			result = DB.Query(sql, out reader);
			using (reader)
			{
				if (result.ResultCode == DBResult.Result.Success)
				{
					while (reader.Read())
					{
						Project_DO project = DataReaderConverter.CreateClassFromDataReader<Project_DO>(reader);
						projects.Add(project);
					}
				}
			}
			return result;
		}

		public virtual DBResult ItemInsert(TimeCardEntry_DO entry)
		{
			QueryString sql = DB.Format(
				$"INSERT INTO timekeep.entries \n" +
				$" SET project_id = {entry.Project.ID}, start_time = '{entry.Start.ToMySqlString()}', end_time = '{entry.End.ToMySqlString()}', memo = '{entry.Memo}'");
			DBResult result = DB.Insert(sql);
			if(result.ResultCode == DBResult.Result.Success)
			{
				entry.ID = result.ItemID;
			}
			return result;
		}

		public virtual DBResult ItemUpdate(TimeCardEntry_DO entry)
		{
			QueryString sql = DB.Format(
				$"UPDATE timekeep.entries SET \n" +
				$" project_id = {entry.Project.ID}, start_time = '{entry.Start.ToMySqlString()}', end_time = '{entry.End.ToMySqlString()}', memo = '{entry.Memo}' \n" +
				$"WHERE id = {entry.ID}");
			return DB.Update(sql);
		}
	}
}
