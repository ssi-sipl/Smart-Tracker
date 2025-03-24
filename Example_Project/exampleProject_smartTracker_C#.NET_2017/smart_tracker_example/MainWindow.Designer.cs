namespace smart_tracker_example
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.buttonRun = new System.Windows.Forms.Button();
            this.chartPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.labelProductcode = new System.Windows.Forms.Label();
            this.comboBoxProductCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSmartTrackerCompiliationDate = new System.Windows.Forms.Label();
            this.labelSmartTrackerVersionDate = new System.Windows.Forms.Label();
            this.labelSmartTrackerVersion = new System.Windows.Forms.Label();
            this.labelSmartTrackerCompiliationDateValue = new System.Windows.Forms.Label();
            this.labelSmartTrackerVersionDateValue = new System.Windows.Forms.Label();
            this.labelSmartTrackerVersionValue = new System.Windows.Forms.Label();
            this.labelEthernetAPIversionValue = new System.Windows.Forms.Label();
            this.labelEthernetAPIversion = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.numericUpIp4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpIp3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpIp2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpIp1 = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDataAcquisition = new System.Windows.Forms.GroupBox();
            this.buttonInstallationAngle = new System.Windows.Forms.Button();
            this.labelInstallationAngle = new System.Windows.Forms.Label();
            this.numericUpDownInstallationAngle = new System.Windows.Forms.NumericUpDown();
            this.buttonInstallationHeight = new System.Windows.Forms.Button();
            this.labelInstallationHeight = new System.Windows.Forms.Label();
            this.numericUpDownInstallationHeight = new System.Windows.Forms.NumericUpDown();
            this.checkBoxWindFilter = new System.Windows.Forms.CheckBox();
            this.buttonIgnoreZoneExample = new System.Windows.Forms.Button();
            this.checkBoxHoldPlotTracks = new System.Windows.Forms.CheckBox();
            this.buttonResetTracks = new System.Windows.Forms.Button();
            this.checkBoxShowTracks = new System.Windows.Forms.CheckBox();
            this.checkBoxHoldPlotTargets = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTargets = new System.Windows.Forms.CheckBox();
            this.numericUpDownTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.labelTimerInterval = new System.Windows.Forms.Label();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFrameID = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp1)).BeginInit();
            this.groupBoxDataAcquisition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstallationAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstallationHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(15, 22);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(118, 38);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // chartPlot
            // 
            this.chartPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPlot.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Interval = 20D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.Maximum = 170D;
            chartArea1.AxisX.Minimum = -170D;
            chartArea1.AxisY.Interval = 20D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.Maximum = 170D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPlot.Legends.Add(legend1);
            this.chartPlot.Location = new System.Drawing.Point(9, 8);
            this.chartPlot.Name = "chartPlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.Name = "Targets";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.MarkerSize = 9;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Tracks";
            series2.YValuesPerPoint = 2;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series3.Name = "Ignore Zone";
            series3.YValuesPerPoint = 2;
            this.chartPlot.Series.Add(series1);
            this.chartPlot.Series.Add(series2);
            this.chartPlot.Series.Add(series3);
            this.chartPlot.Size = new System.Drawing.Size(907, 434);
            this.chartPlot.TabIndex = 2;
            this.chartPlot.Text = "chart1";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxConnection.Controls.Add(this.labelProductcode);
            this.groupBoxConnection.Controls.Add(this.comboBoxProductCode);
            this.groupBoxConnection.Controls.Add(this.label1);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerCompiliationDate);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerVersionDate);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerVersion);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerCompiliationDateValue);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerVersionDateValue);
            this.groupBoxConnection.Controls.Add(this.labelSmartTrackerVersionValue);
            this.groupBoxConnection.Controls.Add(this.labelEthernetAPIversionValue);
            this.groupBoxConnection.Controls.Add(this.labelEthernetAPIversion);
            this.groupBoxConnection.Controls.Add(this.buttonConnect);
            this.groupBoxConnection.Controls.Add(this.numericUpIp4);
            this.groupBoxConnection.Controls.Add(this.numericUpIp3);
            this.groupBoxConnection.Controls.Add(this.numericUpIp2);
            this.groupBoxConnection.Controls.Add(this.numericUpIp1);
            this.groupBoxConnection.Location = new System.Drawing.Point(11, 448);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(387, 212);
            this.groupBoxConnection.TabIndex = 3;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection to iSYS-5011/5021";
            // 
            // labelProductcode
            // 
            this.labelProductcode.AutoSize = true;
            this.labelProductcode.Location = new System.Drawing.Point(18, 35);
            this.labelProductcode.Name = "labelProductcode";
            this.labelProductcode.Size = new System.Drawing.Size(68, 13);
            this.labelProductcode.TabIndex = 6;
            this.labelProductcode.Text = "Productcode";
            // 
            // comboBoxProductCode
            // 
            this.comboBoxProductCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductCode.FormattingEnabled = true;
            this.comboBoxProductCode.Items.AddRange(new object[] {
            "5011",
            "5021"});
            this.comboBoxProductCode.Location = new System.Drawing.Point(98, 32);
            this.comboBoxProductCode.Name = "comboBoxProductCode";
            this.comboBoxProductCode.Size = new System.Drawing.Size(106, 21);
            this.comboBoxProductCode.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(18, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "note: WinPcap must be installed for ethernet connection";
            // 
            // labelSmartTrackerCompiliationDate
            // 
            this.labelSmartTrackerCompiliationDate.AutoSize = true;
            this.labelSmartTrackerCompiliationDate.Location = new System.Drawing.Point(18, 155);
            this.labelSmartTrackerCompiliationDate.Name = "labelSmartTrackerCompiliationDate";
            this.labelSmartTrackerCompiliationDate.Size = new System.Drawing.Size(160, 13);
            this.labelSmartTrackerCompiliationDate.TabIndex = 3;
            this.labelSmartTrackerCompiliationDate.Text = "Smart Tracker Compilation Date:";
            // 
            // labelSmartTrackerVersionDate
            // 
            this.labelSmartTrackerVersionDate.AutoSize = true;
            this.labelSmartTrackerVersionDate.Location = new System.Drawing.Point(18, 139);
            this.labelSmartTrackerVersionDate.Name = "labelSmartTrackerVersionDate";
            this.labelSmartTrackerVersionDate.Size = new System.Drawing.Size(141, 13);
            this.labelSmartTrackerVersionDate.TabIndex = 2;
            this.labelSmartTrackerVersionDate.Text = "Smart Tracker Version Date:";
            // 
            // labelSmartTrackerVersion
            // 
            this.labelSmartTrackerVersion.AutoSize = true;
            this.labelSmartTrackerVersion.Location = new System.Drawing.Point(18, 122);
            this.labelSmartTrackerVersion.Name = "labelSmartTrackerVersion";
            this.labelSmartTrackerVersion.Size = new System.Drawing.Size(118, 13);
            this.labelSmartTrackerVersion.TabIndex = 2;
            this.labelSmartTrackerVersion.Text = "Smart Tracker Version: ";
            // 
            // labelSmartTrackerCompiliationDateValue
            // 
            this.labelSmartTrackerCompiliationDateValue.AutoSize = true;
            this.labelSmartTrackerCompiliationDateValue.Location = new System.Drawing.Point(204, 155);
            this.labelSmartTrackerCompiliationDateValue.Name = "labelSmartTrackerCompiliationDateValue";
            this.labelSmartTrackerCompiliationDateValue.Size = new System.Drawing.Size(10, 13);
            this.labelSmartTrackerCompiliationDateValue.TabIndex = 2;
            this.labelSmartTrackerCompiliationDateValue.Text = "-";
            // 
            // labelSmartTrackerVersionDateValue
            // 
            this.labelSmartTrackerVersionDateValue.AutoSize = true;
            this.labelSmartTrackerVersionDateValue.Location = new System.Drawing.Point(204, 139);
            this.labelSmartTrackerVersionDateValue.Name = "labelSmartTrackerVersionDateValue";
            this.labelSmartTrackerVersionDateValue.Size = new System.Drawing.Size(10, 13);
            this.labelSmartTrackerVersionDateValue.TabIndex = 2;
            this.labelSmartTrackerVersionDateValue.Text = "-";
            // 
            // labelSmartTrackerVersionValue
            // 
            this.labelSmartTrackerVersionValue.AutoSize = true;
            this.labelSmartTrackerVersionValue.Location = new System.Drawing.Point(204, 122);
            this.labelSmartTrackerVersionValue.Name = "labelSmartTrackerVersionValue";
            this.labelSmartTrackerVersionValue.Size = new System.Drawing.Size(10, 13);
            this.labelSmartTrackerVersionValue.TabIndex = 2;
            this.labelSmartTrackerVersionValue.Text = "-";
            // 
            // labelEthernetAPIversionValue
            // 
            this.labelEthernetAPIversionValue.AutoSize = true;
            this.labelEthernetAPIversionValue.Location = new System.Drawing.Point(204, 105);
            this.labelEthernetAPIversionValue.Name = "labelEthernetAPIversionValue";
            this.labelEthernetAPIversionValue.Size = new System.Drawing.Size(10, 13);
            this.labelEthernetAPIversionValue.TabIndex = 2;
            this.labelEthernetAPIversionValue.Text = "-";
            // 
            // labelEthernetAPIversion
            // 
            this.labelEthernetAPIversion.AutoSize = true;
            this.labelEthernetAPIversion.Location = new System.Drawing.Point(18, 105);
            this.labelEthernetAPIversion.Name = "labelEthernetAPIversion";
            this.labelEthernetAPIversion.Size = new System.Drawing.Size(108, 13);
            this.labelEthernetAPIversion.TabIndex = 2;
            this.labelEthernetAPIversion.Text = "Ethernet API Version:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(262, 63);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(103, 38);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // numericUpIp4
            // 
            this.numericUpIp4.Location = new System.Drawing.Point(192, 71);
            this.numericUpIp4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpIp4.Name = "numericUpIp4";
            this.numericUpIp4.Size = new System.Drawing.Size(51, 20);
            this.numericUpIp4.TabIndex = 0;
            this.numericUpIp4.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpIp3
            // 
            this.numericUpIp3.Location = new System.Drawing.Point(135, 71);
            this.numericUpIp3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpIp3.Name = "numericUpIp3";
            this.numericUpIp3.Size = new System.Drawing.Size(51, 20);
            this.numericUpIp3.TabIndex = 0;
            this.numericUpIp3.Value = new decimal(new int[] {
            252,
            0,
            0,
            0});
            // 
            // numericUpIp2
            // 
            this.numericUpIp2.Location = new System.Drawing.Point(78, 71);
            this.numericUpIp2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpIp2.Name = "numericUpIp2";
            this.numericUpIp2.Size = new System.Drawing.Size(51, 20);
            this.numericUpIp2.TabIndex = 0;
            this.numericUpIp2.Value = new decimal(new int[] {
            168,
            0,
            0,
            0});
            // 
            // numericUpIp1
            // 
            this.numericUpIp1.Location = new System.Drawing.Point(21, 71);
            this.numericUpIp1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpIp1.Name = "numericUpIp1";
            this.numericUpIp1.Size = new System.Drawing.Size(51, 20);
            this.numericUpIp1.TabIndex = 0;
            this.numericUpIp1.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            // 
            // groupBoxDataAcquisition
            // 
            this.groupBoxDataAcquisition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDataAcquisition.Controls.Add(this.buttonInstallationAngle);
            this.groupBoxDataAcquisition.Controls.Add(this.labelInstallationAngle);
            this.groupBoxDataAcquisition.Controls.Add(this.numericUpDownInstallationAngle);
            this.groupBoxDataAcquisition.Controls.Add(this.buttonInstallationHeight);
            this.groupBoxDataAcquisition.Controls.Add(this.labelInstallationHeight);
            this.groupBoxDataAcquisition.Controls.Add(this.numericUpDownInstallationHeight);
            this.groupBoxDataAcquisition.Controls.Add(this.checkBoxWindFilter);
            this.groupBoxDataAcquisition.Controls.Add(this.buttonIgnoreZoneExample);
            this.groupBoxDataAcquisition.Controls.Add(this.checkBoxHoldPlotTracks);
            this.groupBoxDataAcquisition.Controls.Add(this.buttonResetTracks);
            this.groupBoxDataAcquisition.Controls.Add(this.checkBoxShowTracks);
            this.groupBoxDataAcquisition.Controls.Add(this.checkBoxHoldPlotTargets);
            this.groupBoxDataAcquisition.Controls.Add(this.checkBoxShowTargets);
            this.groupBoxDataAcquisition.Controls.Add(this.buttonRun);
            this.groupBoxDataAcquisition.Controls.Add(this.numericUpDownTimerInterval);
            this.groupBoxDataAcquisition.Controls.Add(this.labelTimerInterval);
            this.groupBoxDataAcquisition.Location = new System.Drawing.Point(404, 448);
            this.groupBoxDataAcquisition.Name = "groupBoxDataAcquisition";
            this.groupBoxDataAcquisition.Size = new System.Drawing.Size(514, 210);
            this.groupBoxDataAcquisition.TabIndex = 4;
            this.groupBoxDataAcquisition.TabStop = false;
            this.groupBoxDataAcquisition.Text = "Data acquisition";
            // 
            // buttonInstallationAngle
            // 
            this.buttonInstallationAngle.Enabled = false;
            this.buttonInstallationAngle.Location = new System.Drawing.Point(452, 173);
            this.buttonInstallationAngle.Name = "buttonInstallationAngle";
            this.buttonInstallationAngle.Size = new System.Drawing.Size(41, 24);
            this.buttonInstallationAngle.TabIndex = 13;
            this.buttonInstallationAngle.Text = "set";
            this.buttonInstallationAngle.UseVisualStyleBackColor = true;
            this.buttonInstallationAngle.Click += new System.EventHandler(this.buttonInstallationAngle_Click);
            // 
            // labelInstallationAngle
            // 
            this.labelInstallationAngle.AutoSize = true;
            this.labelInstallationAngle.Location = new System.Drawing.Point(272, 177);
            this.labelInstallationAngle.Name = "labelInstallationAngle";
            this.labelInstallationAngle.Size = new System.Drawing.Size(117, 13);
            this.labelInstallationAngle.TabIndex = 12;
            this.labelInstallationAngle.Text = "Installation Angle (deg):";
            // 
            // numericUpDownInstallationAngle
            // 
            this.numericUpDownInstallationAngle.DecimalPlaces = 1;
            this.numericUpDownInstallationAngle.Enabled = false;
            this.numericUpDownInstallationAngle.Location = new System.Drawing.Point(391, 175);
            this.numericUpDownInstallationAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownInstallationAngle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDownInstallationAngle.Name = "numericUpDownInstallationAngle";
            this.numericUpDownInstallationAngle.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownInstallationAngle.TabIndex = 11;
            this.numericUpDownInstallationAngle.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonInstallationHeight
            // 
            this.buttonInstallationHeight.Enabled = false;
            this.buttonInstallationHeight.Location = new System.Drawing.Point(452, 143);
            this.buttonInstallationHeight.Name = "buttonInstallationHeight";
            this.buttonInstallationHeight.Size = new System.Drawing.Size(41, 24);
            this.buttonInstallationHeight.TabIndex = 10;
            this.buttonInstallationHeight.Text = "set";
            this.buttonInstallationHeight.UseVisualStyleBackColor = true;
            this.buttonInstallationHeight.Click += new System.EventHandler(this.buttonInstallationHeight_Click);
            // 
            // labelInstallationHeight
            // 
            this.labelInstallationHeight.AutoSize = true;
            this.labelInstallationHeight.Location = new System.Drawing.Point(272, 147);
            this.labelInstallationHeight.Name = "labelInstallationHeight";
            this.labelInstallationHeight.Size = new System.Drawing.Size(111, 13);
            this.labelInstallationHeight.TabIndex = 9;
            this.labelInstallationHeight.Text = "Installation Height (m):";
            // 
            // numericUpDownInstallationHeight
            // 
            this.numericUpDownInstallationHeight.DecimalPlaces = 1;
            this.numericUpDownInstallationHeight.Enabled = false;
            this.numericUpDownInstallationHeight.Location = new System.Drawing.Point(391, 145);
            this.numericUpDownInstallationHeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInstallationHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInstallationHeight.Name = "numericUpDownInstallationHeight";
            this.numericUpDownInstallationHeight.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownInstallationHeight.TabIndex = 8;
            this.numericUpDownInstallationHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // checkBoxWindFilter
            // 
            this.checkBoxWindFilter.AutoSize = true;
            this.checkBoxWindFilter.Checked = true;
            this.checkBoxWindFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWindFilter.Enabled = false;
            this.checkBoxWindFilter.Location = new System.Drawing.Point(275, 123);
            this.checkBoxWindFilter.Name = "checkBoxWindFilter";
            this.checkBoxWindFilter.Size = new System.Drawing.Size(70, 17);
            this.checkBoxWindFilter.TabIndex = 7;
            this.checkBoxWindFilter.Text = "wind filter";
            this.checkBoxWindFilter.UseVisualStyleBackColor = true;
            this.checkBoxWindFilter.CheckedChanged += new System.EventHandler(this.checkBoxWindFilter_CheckedChanged);
            // 
            // buttonIgnoreZoneExample
            // 
            this.buttonIgnoreZoneExample.Enabled = false;
            this.buttonIgnoreZoneExample.Location = new System.Drawing.Point(256, 22);
            this.buttonIgnoreZoneExample.Name = "buttonIgnoreZoneExample";
            this.buttonIgnoreZoneExample.Size = new System.Drawing.Size(167, 38);
            this.buttonIgnoreZoneExample.TabIndex = 6;
            this.buttonIgnoreZoneExample.Text = "Set example Ignore Zone";
            this.buttonIgnoreZoneExample.UseVisualStyleBackColor = true;
            this.buttonIgnoreZoneExample.Click += new System.EventHandler(this.buttonIgnoreZoneExample_Click);
            // 
            // checkBoxHoldPlotTracks
            // 
            this.checkBoxHoldPlotTracks.AutoSize = true;
            this.checkBoxHoldPlotTracks.Location = new System.Drawing.Point(135, 146);
            this.checkBoxHoldPlotTracks.Name = "checkBoxHoldPlotTracks";
            this.checkBoxHoldPlotTracks.Size = new System.Drawing.Size(102, 17);
            this.checkBoxHoldPlotTracks.TabIndex = 4;
            this.checkBoxHoldPlotTracks.Text = "hold Tracks plot";
            this.checkBoxHoldPlotTracks.UseVisualStyleBackColor = true;
            // 
            // buttonResetTracks
            // 
            this.buttonResetTracks.Enabled = false;
            this.buttonResetTracks.Location = new System.Drawing.Point(139, 22);
            this.buttonResetTracks.Name = "buttonResetTracks";
            this.buttonResetTracks.Size = new System.Drawing.Size(111, 38);
            this.buttonResetTracks.TabIndex = 3;
            this.buttonResetTracks.Text = "Reset Tracks";
            this.buttonResetTracks.UseVisualStyleBackColor = true;
            this.buttonResetTracks.Click += new System.EventHandler(this.buttonResetTracks_Click);
            // 
            // checkBoxShowTracks
            // 
            this.checkBoxShowTracks.AutoSize = true;
            this.checkBoxShowTracks.Checked = true;
            this.checkBoxShowTracks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTracks.Location = new System.Drawing.Point(15, 146);
            this.checkBoxShowTracks.Name = "checkBoxShowTracks";
            this.checkBoxShowTracks.Size = new System.Drawing.Size(87, 17);
            this.checkBoxShowTracks.TabIndex = 2;
            this.checkBoxShowTracks.Text = "show Tracks";
            this.checkBoxShowTracks.UseVisualStyleBackColor = true;
            // 
            // checkBoxHoldPlotTargets
            // 
            this.checkBoxHoldPlotTargets.AutoSize = true;
            this.checkBoxHoldPlotTargets.Location = new System.Drawing.Point(135, 123);
            this.checkBoxHoldPlotTargets.Name = "checkBoxHoldPlotTargets";
            this.checkBoxHoldPlotTargets.Size = new System.Drawing.Size(105, 17);
            this.checkBoxHoldPlotTargets.TabIndex = 2;
            this.checkBoxHoldPlotTargets.Text = "hold Targets plot";
            this.checkBoxHoldPlotTargets.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTargets
            // 
            this.checkBoxShowTargets.AutoSize = true;
            this.checkBoxShowTargets.Checked = true;
            this.checkBoxShowTargets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTargets.Location = new System.Drawing.Point(15, 123);
            this.checkBoxShowTargets.Name = "checkBoxShowTargets";
            this.checkBoxShowTargets.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowTargets.TabIndex = 2;
            this.checkBoxShowTargets.Text = "show Targets";
            this.checkBoxShowTargets.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTimerInterval
            // 
            this.numericUpDownTimerInterval.Location = new System.Drawing.Point(115, 75);
            this.numericUpDownTimerInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTimerInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTimerInterval.Name = "numericUpDownTimerInterval";
            this.numericUpDownTimerInterval.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTimerInterval.TabIndex = 0;
            this.numericUpDownTimerInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelTimerInterval
            // 
            this.labelTimerInterval.AutoSize = true;
            this.labelTimerInterval.Location = new System.Drawing.Point(12, 77);
            this.labelTimerInterval.Name = "labelTimerInterval";
            this.labelTimerInterval.Size = new System.Drawing.Size(96, 13);
            this.labelTimerInterval.TabIndex = 2;
            this.labelTimerInterval.Text = "Timer Interval (ms):";
            // 
            // dataTimer
            // 
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabelFrameID});
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 24);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(90, 19);
            this.toolStripStatusLabelStatus.Text = "Status:Stopped";
            // 
            // toolStripStatusLabelFrameID
            // 
            this.toolStripStatusLabelFrameID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelFrameID.Name = "toolStripStatusLabelFrameID";
            this.toolStripStatusLabelFrameID.Size = new System.Drawing.Size(67, 19);
            this.toolStripStatusLabelFrameID.Text = "FrameID: 0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 688);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxDataAcquisition);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.chartPlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(941, 695);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "smart_tracker_example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Closing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).EndInit();
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpIp1)).EndInit();
            this.groupBoxDataAcquisition.ResumeLayout(false);
            this.groupBoxDataAcquisition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstallationAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstallationHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlot;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.NumericUpDown numericUpIp4;
        private System.Windows.Forms.NumericUpDown numericUpIp3;
        private System.Windows.Forms.NumericUpDown numericUpIp2;
        private System.Windows.Forms.NumericUpDown numericUpIp1;
        private System.Windows.Forms.GroupBox groupBoxDataAcquisition;
        private System.Windows.Forms.Label labelSmartTrackerVersionDate;
        private System.Windows.Forms.Label labelSmartTrackerVersion;
        private System.Windows.Forms.Label labelEthernetAPIversion;
        private System.Windows.Forms.Label labelSmartTrackerCompiliationDate;
        private System.Windows.Forms.Label labelSmartTrackerCompiliationDateValue;
        private System.Windows.Forms.Label labelSmartTrackerVersionDateValue;
        private System.Windows.Forms.Label labelSmartTrackerVersionValue;
        private System.Windows.Forms.Label labelEthernetAPIversionValue;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFrameID;
        private System.Windows.Forms.CheckBox checkBoxShowTracks;
        private System.Windows.Forms.CheckBox checkBoxShowTargets;
        private System.Windows.Forms.NumericUpDown numericUpDownTimerInterval;
        private System.Windows.Forms.Label labelTimerInterval;
        private System.Windows.Forms.CheckBox checkBoxHoldPlotTargets;
        private System.Windows.Forms.Button buttonResetTracks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxHoldPlotTracks;
        private System.Windows.Forms.Button buttonIgnoreZoneExample;
        private System.Windows.Forms.CheckBox checkBoxWindFilter;
        private System.Windows.Forms.NumericUpDown numericUpDownInstallationHeight;
        private System.Windows.Forms.Button buttonInstallationHeight;
        private System.Windows.Forms.Label labelInstallationHeight;
        private System.Windows.Forms.Label labelProductcode;
        private System.Windows.Forms.ComboBox comboBoxProductCode;
        private System.Windows.Forms.Button buttonInstallationAngle;
        private System.Windows.Forms.Label labelInstallationAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownInstallationAngle;
    }
}

