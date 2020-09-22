namespace TimeKeep
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listItems = new CommonControls.ListViewEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfirmRow = new FontAwesome.Sharp.IconButton();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnNew = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textCurDate = new System.Windows.Forms.TextBox();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listTotalsProject = new System.Windows.Forms.ComboBox();
            this.textWeekTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDayTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listItems);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(800, 512);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 0;
            // 
            // listItems
            // 
            this.listItems.AllowColumnReorder = true;
            this.listItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listItems.DoubleClickActivation = false;
            this.listItems.FullRowSelect = true;
            this.listItems.HideSelection = false;
            this.listItems.Location = new System.Drawing.Point(0, 205);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(800, 192);
            this.listItems.TabIndex = 1;
            this.listItems.UseCompatibleStateImageBehavior = false;
            this.listItems.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConfirmRow);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 42);
            this.panel2.TabIndex = 3;
            // 
            // btnConfirmRow
            // 
            this.btnConfirmRow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmRow.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnConfirmRow.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConfirmRow.IconColor = System.Drawing.Color.Black;
            this.btnConfirmRow.IconSize = 16;
            this.btnConfirmRow.Location = new System.Drawing.Point(668, 0);
            this.btnConfirmRow.Name = "btnConfirmRow";
            this.btnConfirmRow.Rotation = 0D;
            this.btnConfirmRow.Size = new System.Drawing.Size(44, 42);
            this.btnConfirmRow.TabIndex = 2;
            this.btnConfirmRow.Text = "cfrm";
            this.btnConfirmRow.UseVisualStyleBackColor = true;
            this.btnConfirmRow.Click += new System.EventHandler(this.OnConfirmRowClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconSize = 16;
            this.btnDelete.Location = new System.Drawing.Point(712, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Rotation = 0D;
            this.btnDelete.Size = new System.Drawing.Size(44, 42);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.OnDeleteClicked);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNew.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNew.IconColor = System.Drawing.Color.Black;
            this.btnNew.IconSize = 16;
            this.btnNew.Location = new System.Drawing.Point(756, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Rotation = 0D;
            this.btnNew.Size = new System.Drawing.Size(44, 42);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "new";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.OnNewClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textCurDate);
            this.panel1.Controls.Add(this.calendar);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 163);
            this.panel1.TabIndex = 2;
            // 
            // textCurDate
            // 
            this.textCurDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textCurDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCurDate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCurDate.Location = new System.Drawing.Point(75, 0);
            this.textCurDate.Multiline = true;
            this.textCurDate.Name = "textCurDate";
            this.textCurDate.ReadOnly = true;
            this.textCurDate.Size = new System.Drawing.Size(423, 163);
            this.textCurDate.TabIndex = 0;
            this.textCurDate.Text = "Friday the 13th";
            this.textCurDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // calendar
            // 
            this.calendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar.Location = new System.Drawing.Point(498, 0);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.OnDatePickerChanged);
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPrev.IconColor = System.Drawing.Color.ForestGreen;
            this.btnPrev.IconSize = 50;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Rotation = 0D;
            this.btnPrev.Size = new System.Drawing.Size(75, 163);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.OnPreviousClicked);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNext.IconColor = System.Drawing.Color.ForestGreen;
            this.btnNext.IconSize = 50;
            this.btnNext.Location = new System.Drawing.Point(725, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Rotation = 0D;
            this.btnNext.Size = new System.Drawing.Size(75, 163);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.OnNextClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listTotalsProject);
            this.panel3.Controls.Add(this.textWeekTotal);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textDayTotal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(600, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 111);
            this.panel3.TabIndex = 0;
            // 
            // listTotalsProject
            // 
            this.listTotalsProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listTotalsProject.FormattingEnabled = true;
            this.listTotalsProject.Location = new System.Drawing.Point(96, 7);
            this.listTotalsProject.Name = "listTotalsProject";
            this.listTotalsProject.Size = new System.Drawing.Size(100, 21);
            this.listTotalsProject.TabIndex = 2;
            this.listTotalsProject.SelectedIndexChanged += new System.EventHandler(this.OnProjectListSelectedIndexChanged);
            // 
            // textWeekTotal
            // 
            this.textWeekTotal.Location = new System.Drawing.Point(97, 63);
            this.textWeekTotal.Name = "textWeekTotal";
            this.textWeekTotal.ReadOnly = true;
            this.textWeekTotal.Size = new System.Drawing.Size(100, 22);
            this.textWeekTotal.TabIndex = 1;
            this.textWeekTotal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Week Total";
            // 
            // textDayTotal
            // 
            this.textDayTotal.Location = new System.Drawing.Point(96, 35);
            this.textDayTotal.Name = "textDayTotal";
            this.textDayTotal.ReadOnly = true;
            this.textDayTotal.Size = new System.Drawing.Size(100, 22);
            this.textDayTotal.TabIndex = 1;
            this.textDayTotal.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day Total";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Time Keep";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MonthCalendar calendar;
		private CommonControls.ListViewEx listItems;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textCurDate;
		private FontAwesome.Sharp.IconButton btnNext;
		private System.Windows.Forms.Panel panel2;
		private FontAwesome.Sharp.IconButton btnDelete;
		private FontAwesome.Sharp.IconButton btnNew;
		private FontAwesome.Sharp.IconButton btnPrev;
		private FontAwesome.Sharp.IconButton btnConfirmRow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox listTotalsProject;
        private System.Windows.Forms.TextBox textWeekTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDayTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

