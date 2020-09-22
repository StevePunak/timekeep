using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonUtil.CommonObjects;
using CommonUtil.Database;
using CommonUtil.Extensions;
using FontAwesome.Sharp;

namespace TimeKeep
{
	public partial class MainForm : Form
	{
		const String COL_ID = "ID";
		const String COL_PROJECT = "Project";
		const String COL_START = "Begin";
		const String COL_END = "End";
		const String COL_MEMO = "Memo";

		TextBox textStartTimeInput;
		TextBox textEndTimeInput;
		TextBox textMemo;
		ComboBox listProjects;

		TimeCardEntryList DisplayItems;

		TimeDataSource DataSource;
		DateTime CurrentDate;
		Project_DO SelectedProject;

		public MainForm()
		{
			CurrentDate = DateTime.Now;
			InitializeComponent();
		}

		private void OnFormLoad(object sender, EventArgs args)
		{
			try
			{
				DataSource = new TimeDataSource(new SqlDBCredentials()
				{
					UserName = "timecard",
					Password = "passw0rd",
					Host = "jessica",
					Driver = SqlDataSource.MYSQL_NATIVE_DRIVER,
				});

				CreateControls();
				InitializeListBox();
				LoadTimeCardsForDate(DateTime.Now);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				Close();
			}

		}

		private void CreateControls()
		{
			textStartTimeInput = MakeTimeEditor();
			textEndTimeInput = MakeTimeEditor();
			textMemo = new TextBox() { Visible = false };
			listItems.Controls.Add(textMemo);

			btnNext.IconChar = IconChar.ArrowCircleRight;
			btnNext.Text = String.Empty;

			btnPrev.IconChar = IconChar.ArrowCircleLeft;
			btnPrev.Text = String.Empty;

			btnNew.IconChar = IconChar.PlusCircle;
			btnNew.Text = String.Empty;

			btnDelete.IconChar = IconChar.MinusCircle;
			btnDelete.Text = String.Empty;

			btnConfirmRow.IconChar = IconChar.CheckCircle;
			btnConfirmRow.Text = String.Empty;

			listProjects = new ComboBox()
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				Visible = false,
			};
			ProjectList projects;
			DBResult result = DataSource.ProjectsGet(out projects);
			if(result.ResultCode != DBResult.Result.Success)
            {
				throw new CommonException("Can't load projects");
            }
			listProjects.Items.AddRange(projects.ToArray());
			listItems.Controls.Add(listProjects);

			listTotalsProject.Items.AddRange(projects.ToArray());
			listTotalsProject.SelectedItem = listTotalsProject.Items[0];
		}

		TextBox MakeTimeEditor()
		{
			TextBox editor = new TextBox()
			{
				TextAlign = HorizontalAlignment.Center,
				Visible = false,
			};
			editor.TextChanged += OnTextTimeInput_TextChanged;
			listItems.Controls.Add(editor);
			return editor;
		}

		private void SetTotalsProject(Project_DO project)
		{
			Project_DO selected = null;
			if (listTotalsProject.Items.Count > 0)
			{
				foreach (Project_DO projectInList in listTotalsProject.Items)
				{
					if (projectInList.ID == project.ID)
					{
						selected = projectInList;
						break;
					}
				}
			}

			if(selected != null)
            {
				UpdateTotals(selected);
            }

		}

		private void UpdateTotals(Project_DO project)
		{
			if (project == null)
				return;

			TimeSpan dayTotal, weekTotal;
			DataSource.TotalsForProjectDateRangeGet(project.ID, CurrentDate.GetDateOnly(), CurrentDate.GetDateOnly().AddDays(1), out dayTotal);
			DateTime startOfWeek = CurrentDate.GetStartOfWeek();
			DataSource.TotalsForProjectDateRangeGet(project.ID, startOfWeek, startOfWeek.AddDays(7), out weekTotal);
			textDayTotal.Text = dayTotal.TotalHours.ToString();
			textWeekTotal.Text = weekTotal.TotalHours.ToString();
		}

		private void OnTextTimeInput_TextChanged(object sender, EventArgs e)
		{
			TextBox control = sender as TextBox;
			TimeSpan time;
			if(TimeSpanExtensions.TryParseTimeOfDay(control.Text, out time) == false)
			{
				control.ForeColor = Color.Red;
			}
			else
			{
				control.ForeColor = Color.Black;
			}
		}

		private void LoadTimeCardsForDate(DateTime date)
		{
			DBResult result = DataSource.EntriesForDateGet(date, out DisplayItems);
			if(result.ResultCode == DBResult.Result.Success) { }
			else if(result.ResultCode == DBResult.Result.NoData) { DisplayItems = new TimeCardEntryList(); }
			else throw new Exception("Bad database response");
			ReloadLineItems();
			textCurDate.Text = date.ToString("ddd MMMM d, yyyy");
		}

		private void InitializeListBox()
		{
			listItems.DoubleClickActivation = true;
			listItems.SubItemClicked += OnListItems_SubItemClicked;
			listItems.SubItemEndEditing += OnListItems_SubItemEndEditing;
			listItems.EditComplete += OnListItems_EditComplete;
			listItems.AddColumnHeader(COL_ID, 60);
			listItems.AddColumnHeader(COL_PROJECT, 120);
			listItems.AddColumnHeader(COL_START, 100);
			listItems.AddColumnHeader(COL_END, 100);
			listItems.AddColumnHeader(COL_MEMO, -2);
		}

		private void ReloadLineItems()
		{
			listItems.Items.Clear();

			foreach(TimeCardEntry_DO lineItem in DisplayItems)
			{
				AddRowToListBox(lineItem);
			}
		}

		private void AddRowToListBox(TimeCardEntry_DO timeItem)
		{
			ListViewItem item = listItems.AddRow(COL_ID, timeItem.ID, timeItem);
			listItems.SetListViewColumn(item, COL_PROJECT, timeItem.Project.Name);
			listItems.SetListViewColumn(item, COL_START, timeItem.Start.TimeOfDay.ToTimeOfDayString());
			listItems.SetListViewColumn(item, COL_END, timeItem.End.TimeOfDay.ToTimeOfDayString());
			listItems.SetListViewColumn(item, COL_MEMO, timeItem.Memo);
			item.BackColor = timeItem.IsValid ? Color.White : Color.LightSalmon;
		}

		private void OnListItems_SubItemClicked(object sender, CommonControls.SubItemEventArgs e)
		{
			switch(listItems.ColumnName(e.SubItem))
			{
				case COL_PROJECT:
					listItems.StartEditing(listProjects, e.Item, e.SubItem);
					break;
				case COL_START:
					listItems.StartEditing(textStartTimeInput, e.Item, e.SubItem);
					break;
				case COL_END:
					listItems.StartEditing(textEndTimeInput, e.Item, e.SubItem);
					break;
				case COL_MEMO:
					listItems.StartEditing(textMemo, e.Item, e.SubItem);
					break;
			}
		}
		private void OnListItems_SubItemEndEditing(object sender, CommonControls.SubItemEndEditingEventArgs e)
		{
			bool valid = false;
			switch(listItems.ColumnName(e.SubItem))
			{
				case COL_PROJECT:
					if(listProjects.SelectedItem != null)
                    {
						Project_DO project = listProjects.SelectedItem as Project_DO;
						e.Item.SubItems[e.SubItem].Text = project.Name;
						((TimeCardEntry_DO)e.Item.Tag).Project = project;
						valid = true;
					}
					break;
				case COL_START:
					if(textStartTimeInput.ForeColor == Color.Black)
					{
						e.Item.SubItems[e.SubItem].Text = textStartTimeInput.Text;
						valid = true;
					}
					break;
				case COL_END:
					if(textEndTimeInput.ForeColor == Color.Black)
					{
						e.Item.SubItems[e.SubItem].Text = textEndTimeInput.Text;
						valid = true;
					}
					break;
				case COL_MEMO:
					if(((TimeCardEntry_DO)e.Item.Tag).IsValid)
					{
						e.Item.SubItems[e.SubItem].Text = textMemo.Text;
						valid = true;
					}
					break;
			}

			if(valid)
			{
				LoadLineItemFromRow(e.Item);
				UpdateDatabase(e.Item.Tag as TimeCardEntry_DO);
				SelectedProject = ((TimeCardEntry_DO)e.Item.Tag).Project;
				UpdateTotals(SelectedProject);
			}
		}

		private void OnListItems_EditComplete(object sender, CommonControls.SubItemEventArgs e)
		{
			ReloadLineItems();

			ListViewItem selectItem;
			if(listItems.TryGetItem(((TimeCardEntry_DO)e.Item.Tag).ID.ToString(), out selectItem))
			{
				selectItem.Selected = true;
				listItems.Select();
			}
		}

		private void LoadLineItemFromRow(ListViewItem row)
		{
			TimeCardEntry_DO lineItem = row.Tag  as TimeCardEntry_DO;
			if(int.Parse(row.SubItems[COL_ID].Text) != lineItem.ID)
				throw new ArgumentException("Row mismatch");
			TimeSpan start, end;
			if(TimeSpanExtensions.TryParseTimeOfDay(row.SubItems[COL_START].Text, out start) == false)
				throw new ArgumentException("Bad begin");
			if(TimeSpanExtensions.TryParseTimeOfDay(row.SubItems[COL_END].Text, out end) == false)
				throw new ArgumentException("Bad end");
			lineItem.Start = lineItem.Start.Date + start;
			lineItem.End = lineItem.End.Date + end;
			lineItem.Memo = row.SubItems[COL_MEMO].Text;
		}

		private void UpdateDatabase(TimeCardEntry_DO item)
		{
			try
			{
				DBResult result;
				if(item.ID == 0)
				{
					if((result = DataSource.ItemInsert(item)).ResultCode != DBResult.Result.Success)
						throw new CommonException("Could not insert");
				}
				else
				{
					if((result = DataSource.ItemUpdate(item)).ResultCode != DBResult.Result.Success)
						throw new CommonException("Could not update");
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void OnPreviousClicked(object sender, EventArgs e)
		{
			CurrentDate -= TimeSpan.FromDays(1);
			calendar.SelectionStart = CurrentDate;
		}

		private void OnNextClicked(object sender, EventArgs e)
		{
			CurrentDate += TimeSpan.FromDays(1);
			calendar.SelectionStart = CurrentDate;
		}

		private void OnDatePickerChanged(object sender, DateRangeEventArgs e)
		{
			CurrentDate = calendar.SelectionStart;
			LoadTimeCardsForDate(CurrentDate);
			UpdateTotals(SelectedProject);
		}

		private void OnDeleteClicked(object sender, EventArgs e)
		{
		}

		private void OnNewClicked(object sender, EventArgs e)
		{
			TimeCardEntry_DO item = new TimeCardEntry_DO()
			{
				ID = 0,
				Start = CurrentDate.Date,
				End = CurrentDate.Date + TimeSpan.FromHours(8),
				Memo = "",
			};
			DisplayItems.Add(item);
			AddRowToListBox(item);
		}

		private void OnConfirmRowClicked(object sender, EventArgs e)
		{

		}

        private void OnProjectListSelectedIndexChanged(object sender, EventArgs e)
        {
			if(listTotalsProject.SelectedItem is Project_DO)
            {
				SelectedProject = listTotalsProject.SelectedItem as Project_DO;
				SetTotalsProject(SelectedProject);
            }

        }
    }
}
