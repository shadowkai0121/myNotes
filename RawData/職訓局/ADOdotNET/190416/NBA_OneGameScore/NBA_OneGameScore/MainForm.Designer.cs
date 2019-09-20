namespace NBA_OneGameScore {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblPrompt_BookTotal = new System.Windows.Forms.Label();
            this.txtBookTotal = new System.Windows.Forms.TextBox();
            this.lblMinMax = new System.Windows.Forms.Label();
            this.chartScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboGameDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.workerDownloadGameList = new System.ComponentModel.BackgroundWorker();
            this.cboMatchup = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtRefreshSeconds = new System.Windows.Forms.TextBox();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblEvent1 = new System.Windows.Forms.Label();
            this.lblEvent2 = new System.Windows.Forms.Label();
            this.chkPace = new System.Windows.Forms.CheckBox();
            this.lblMargin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Match up:";
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(756, 10);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(108, 77);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblPrompt_BookTotal
            // 
            this.lblPrompt_BookTotal.AutoSize = true;
            this.lblPrompt_BookTotal.Location = new System.Drawing.Point(522, 54);
            this.lblPrompt_BookTotal.Name = "lblPrompt_BookTotal";
            this.lblPrompt_BookTotal.Size = new System.Drawing.Size(143, 31);
            this.lblPrompt_BookTotal.TabIndex = 6;
            this.lblPrompt_BookTotal.Text = "Book total:";
            // 
            // txtBookTotal
            // 
            this.txtBookTotal.BackColor = System.Drawing.Color.White;
            this.txtBookTotal.Location = new System.Drawing.Point(668, 50);
            this.txtBookTotal.Name = "txtBookTotal";
            this.txtBookTotal.Size = new System.Drawing.Size(67, 37);
            this.txtBookTotal.TabIndex = 7;
            this.txtBookTotal.Text = "200.5";
            this.txtBookTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinMax
            // 
            this.lblMinMax.AutoSize = true;
            this.lblMinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinMax.ForeColor = System.Drawing.Color.Black;
            this.lblMinMax.Location = new System.Drawing.Point(19, 93);
            this.lblMinMax.Name = "lblMinMax";
            this.lblMinMax.Size = new System.Drawing.Size(77, 29);
            this.lblMinMax.TabIndex = 9;
            this.lblMinMax.Text = "--------";
            // 
            // chartScore
            // 
            this.chartScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartScore.BackColor = System.Drawing.Color.DarkGray;
            this.chartScore.BorderlineColor = System.Drawing.Color.DimGray;
            this.chartScore.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.BackColor = System.Drawing.Color.DarkGray;
            chartArea2.Name = "ChartArea1";
            this.chartScore.ChartAreas.Add(chartArea2);
            this.chartScore.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartScore.Location = new System.Drawing.Point(22, 200);
            this.chartScore.Name = "chartScore";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.LightSlateGray;
            series4.Name = "pace";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.DarkOliveGreen;
            series5.Name = "avgScore";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Maroon;
            series6.Name = "expectedScore";
            this.chartScore.Series.Add(series4);
            this.chartScore.Series.Add(series5);
            this.chartScore.Series.Add(series6);
            this.chartScore.Size = new System.Drawing.Size(842, 325);
            this.chartScore.TabIndex = 18;
            this.chartScore.Text = "chart1";
            this.chartScore.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartScore_GetToolTipText);
            this.chartScore.MouseLeave += new System.EventHandler(this.chartScore_MouseLeave);
            this.chartScore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartScore_MouseMove);
            // 
            // cboGameDate
            // 
            this.cboGameDate.CustomFormat = "yyyy-MM-dd";
            this.cboGameDate.Enabled = false;
            this.cboGameDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cboGameDate.Location = new System.Drawing.Point(179, 10);
            this.cboGameDate.Name = "cboGameDate";
            this.cboGameDate.Size = new System.Drawing.Size(125, 37);
            this.cboGameDate.TabIndex = 1;
            this.cboGameDate.ValueChanged += new System.EventHandler(this.cboGameDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Game Date:";
            // 
            // workerDownloadGameList
            // 
            this.workerDownloadGameList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDownloadGameList_DoWork);
            // 
            // cboMatchup
            // 
            this.cboMatchup.BackColor = System.Drawing.Color.White;
            this.cboMatchup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatchup.Enabled = false;
            this.cboMatchup.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMatchup.FormattingEnabled = true;
            this.cboMatchup.Location = new System.Drawing.Point(152, 50);
            this.cboMatchup.Name = "cboMatchup";
            this.cboMatchup.Size = new System.Drawing.Size(265, 37);
            this.cboMatchup.TabIndex = 3;
            this.cboMatchup.SelectedIndexChanged += new System.EventHandler(this.cboMatchup_SelectedIndexChanged);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 30000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(227, 31);
            this.label8.TabIndex = 4;
            this.label8.Text = "Refresh seconds:";
            // 
            // txtRefreshSeconds
            // 
            this.txtRefreshSeconds.Location = new System.Drawing.Point(669, 10);
            this.txtRefreshSeconds.Name = "txtRefreshSeconds";
            this.txtRefreshSeconds.Size = new System.Drawing.Size(67, 37);
            this.txtRefreshSeconds.TabIndex = 5;
            this.txtRefreshSeconds.Text = "-1";
            this.txtRefreshSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRefreshSeconds.TextChanged += new System.EventHandler(this.txtRefreshSeconds_TextChanged);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "notifyIcon1";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // lblEvent1
            // 
            this.lblEvent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent1.Location = new System.Drawing.Point(19, 164);
            this.lblEvent1.Name = "lblEvent1";
            this.lblEvent1.Size = new System.Drawing.Size(416, 25);
            this.lblEvent1.TabIndex = 19;
            this.lblEvent1.Text = "--";
            // 
            // lblEvent2
            // 
            this.lblEvent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent2.Location = new System.Drawing.Point(442, 164);
            this.lblEvent2.Name = "lblEvent2";
            this.lblEvent2.Size = new System.Drawing.Size(416, 23);
            this.lblEvent2.TabIndex = 20;
            this.lblEvent2.Text = "--";
            // 
            // chkPace
            // 
            this.chkPace.AutoSize = true;
            this.chkPace.Location = new System.Drawing.Point(334, 12);
            this.chkPace.Name = "chkPace";
            this.chkPace.Size = new System.Drawing.Size(98, 35);
            this.chkPace.TabIndex = 21;
            this.chkPace.Text = "Pace";
            this.chkPace.UseVisualStyleBackColor = true;
            this.chkPace.CheckedChanged += new System.EventHandler(this.chkPace_CheckedChanged);
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.ForeColor = System.Drawing.Color.Black;
            this.lblMargin.Location = new System.Drawing.Point(19, 124);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(86, 31);
            this.lblMargin.TabIndex = 22;
            this.lblMargin.Text = "--------";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 537);
            this.Controls.Add(this.lblMargin);
            this.Controls.Add(this.chkPace);
            this.Controls.Add(this.lblEvent2);
            this.Controls.Add(this.lblEvent1);
            this.Controls.Add(this.txtRefreshSeconds);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboMatchup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGameDate);
            this.Controls.Add(this.chartScore);
            this.Controls.Add(this.lblMinMax);
            this.Controls.Add(this.txtBookTotal);
            this.Controls.Add(this.lblPrompt_BookTotal);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.Text = "Viewing NBA Game Score";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblPrompt_BookTotal;
        private System.Windows.Forms.TextBox txtBookTotal;
        private System.Windows.Forms.Label lblMinMax;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScore;
        internal System.Windows.Forms.DateTimePicker cboGameDate;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker workerDownloadGameList;
        private System.Windows.Forms.ComboBox cboMatchup;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRefreshSeconds;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Label lblEvent1;
        private System.Windows.Forms.Label lblEvent2;
        private System.Windows.Forms.CheckBox chkPace;
        private System.Windows.Forms.Label lblMargin;
    }
}

