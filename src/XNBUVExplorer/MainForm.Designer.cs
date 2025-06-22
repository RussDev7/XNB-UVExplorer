namespace XNBUVExplorer
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
            if (disposing && (components != null))
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
            this.LoadXnb_Button = new System.Windows.Forms.Button();
            this.TileU_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TileV_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Zoom_TrackBar = new System.Windows.Forms.TrackBar();
            this.Zoom_Label = new System.Windows.Forms.Label();
            this.XnbView_Panel = new System.Windows.Forms.Panel();
            this.U_Label = new System.Windows.Forms.Label();
            this.V_Label = new System.Windows.Forms.Label();
            this.TextureInfo_Grid = new System.Windows.Forms.DataGridView();
            this.TextureDetectionSettings_GroupBox = new System.Windows.Forms.GroupBox();
            this.CanvasMargin_Label = new System.Windows.Forms.Label();
            this.CanvasMargin_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SeamGap_Label = new System.Windows.Forms.Label();
            this.GapThreshold_Label = new System.Windows.Forms.Label();
            this.InitialGapExtendedLimit_Label = new System.Windows.Forms.Label();
            this.InitialGapThreshold_Label = new System.Windows.Forms.Label();
            this.TileSize_Label = new System.Windows.Forms.Label();
            this.SeamGap_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GapThreshold_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InitialGapExtendedLimit_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InitialGapThreshold_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TileSize_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CopyData_Button = new System.Windows.Forms.Button();
            this.RefreshUI_Button = new System.Windows.Forms.Button();
            this.DynamicLabeling_CheckBox = new System.Windows.Forms.CheckBox();
            this.UOffset_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VOffset_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VOffset_Label = new System.Windows.Forms.Label();
            this.UOffset_Label = new System.Windows.Forms.Label();
            this.UVDataSettings_GroupBox = new System.Windows.Forms.GroupBox();
            this.Alerts_CheckBox = new System.Windows.Forms.CheckBox();
            this.DataFormatting_GroupBox = new System.Windows.Forms.GroupBox();
            this.RowSorting_RadioButton = new System.Windows.Forms.RadioButton();
            this.ColumnSorting_RadioButton = new System.Windows.Forms.RadioButton();
            this.TileCount_GroupBox = new System.Windows.Forms.GroupBox();
            this.TileCount_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TileU_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileV_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom_TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureInfo_Grid)).BeginInit();
            this.TextureDetectionSettings_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasMargin_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeamGap_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GapThreshold_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitialGapExtendedLimit_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitialGapThreshold_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileSize_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOffset_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VOffset_NumericUpDown)).BeginInit();
            this.UVDataSettings_GroupBox.SuspendLayout();
            this.DataFormatting_GroupBox.SuspendLayout();
            this.TileCount_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadXnb_Button
            // 
            this.LoadXnb_Button.Location = new System.Drawing.Point(177, 8);
            this.LoadXnb_Button.Name = "LoadXnb_Button";
            this.LoadXnb_Button.Size = new System.Drawing.Size(111, 23);
            this.LoadXnb_Button.TabIndex = 1;
            this.LoadXnb_Button.Text = "Load .xnb";
            this.LoadXnb_Button.UseVisualStyleBackColor = true;
            this.LoadXnb_Button.Click += new System.EventHandler(this.LoadXnb_Button_Click);
            // 
            // TileU_NumericUpDown
            // 
            this.TileU_NumericUpDown.Location = new System.Drawing.Point(30, 9);
            this.TileU_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.TileU_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TileU_NumericUpDown.Name = "TileU_NumericUpDown";
            this.TileU_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.TileU_NumericUpDown.TabIndex = 3;
            this.TileU_NumericUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // TileV_NumericUpDown
            // 
            this.TileV_NumericUpDown.Location = new System.Drawing.Point(30, 35);
            this.TileV_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.TileV_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TileV_NumericUpDown.Name = "TileV_NumericUpDown";
            this.TileV_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.TileV_NumericUpDown.TabIndex = 4;
            this.TileV_NumericUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // Zoom_TrackBar
            // 
            this.Zoom_TrackBar.Location = new System.Drawing.Point(0, 58);
            this.Zoom_TrackBar.Maximum = 20;
            this.Zoom_TrackBar.Minimum = 1;
            this.Zoom_TrackBar.Name = "Zoom_TrackBar";
            this.Zoom_TrackBar.Size = new System.Drawing.Size(288, 45);
            this.Zoom_TrackBar.TabIndex = 2;
            this.Zoom_TrackBar.Value = 6;
            // 
            // Zoom_Label
            // 
            this.Zoom_Label.AutoSize = true;
            this.Zoom_Label.Location = new System.Drawing.Point(105, 90);
            this.Zoom_Label.Name = "Zoom_Label";
            this.Zoom_Label.Size = new System.Drawing.Size(66, 13);
            this.Zoom_Label.TabIndex = 0;
            this.Zoom_Label.Text = "Zoom: 600%";
            // 
            // XnbView_Panel
            // 
            this.XnbView_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XnbView_Panel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.XnbView_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XnbView_Panel.Location = new System.Drawing.Point(0, 109);
            this.XnbView_Panel.Name = "XnbView_Panel";
            this.XnbView_Panel.Size = new System.Drawing.Size(709, 552);
            this.XnbView_Panel.TabIndex = 0;
            this.XnbView_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.XnbView_Panel_Paint);
            // 
            // U_Label
            // 
            this.U_Label.AutoSize = true;
            this.U_Label.Location = new System.Drawing.Point(9, 11);
            this.U_Label.Name = "U_Label";
            this.U_Label.Size = new System.Drawing.Size(18, 13);
            this.U_Label.TabIndex = 0;
            this.U_Label.Text = "U:";
            // 
            // V_Label
            // 
            this.V_Label.AutoSize = true;
            this.V_Label.Location = new System.Drawing.Point(10, 37);
            this.V_Label.Name = "V_Label";
            this.V_Label.Size = new System.Drawing.Size(17, 13);
            this.V_Label.TabIndex = 0;
            this.V_Label.Text = "V:";
            // 
            // TextureInfo_Grid
            // 
            this.TextureInfo_Grid.AllowUserToAddRows = false;
            this.TextureInfo_Grid.AllowUserToDeleteRows = false;
            this.TextureInfo_Grid.AllowUserToResizeColumns = false;
            this.TextureInfo_Grid.AllowUserToResizeRows = false;
            this.TextureInfo_Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextureInfo_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TextureInfo_Grid.Location = new System.Drawing.Point(708, 109);
            this.TextureInfo_Grid.Name = "TextureInfo_Grid";
            this.TextureInfo_Grid.ReadOnly = true;
            this.TextureInfo_Grid.RowHeadersVisible = false;
            this.TextureInfo_Grid.Size = new System.Drawing.Size(190, 552);
            this.TextureInfo_Grid.TabIndex = 0;
            // 
            // TextureDetectionSettings_GroupBox
            // 
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.CanvasMargin_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.CanvasMargin_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.SeamGap_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.GapThreshold_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.InitialGapExtendedLimit_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.InitialGapThreshold_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.TileSize_Label);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.SeamGap_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.GapThreshold_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.InitialGapExtendedLimit_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.InitialGapThreshold_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.Controls.Add(this.TileSize_NumericUpDown);
            this.TextureDetectionSettings_GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextureDetectionSettings_GroupBox.Location = new System.Drawing.Point(294, 3);
            this.TextureDetectionSettings_GroupBox.Name = "TextureDetectionSettings_GroupBox";
            this.TextureDetectionSettings_GroupBox.Size = new System.Drawing.Size(389, 101);
            this.TextureDetectionSettings_GroupBox.TabIndex = 0;
            this.TextureDetectionSettings_GroupBox.TabStop = false;
            this.TextureDetectionSettings_GroupBox.Text = "Texture Detection Settings:";
            // 
            // CanvasMargin_Label
            // 
            this.CanvasMargin_Label.AutoSize = true;
            this.CanvasMargin_Label.Location = new System.Drawing.Point(249, 76);
            this.CanvasMargin_Label.Name = "CanvasMargin_Label";
            this.CanvasMargin_Label.Size = new System.Drawing.Size(80, 13);
            this.CanvasMargin_Label.TabIndex = 0;
            this.CanvasMargin_Label.Text = "Canvas margin.";
            // 
            // CanvasMargin_NumericUpDown
            // 
            this.CanvasMargin_NumericUpDown.Location = new System.Drawing.Point(193, 74);
            this.CanvasMargin_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.CanvasMargin_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CanvasMargin_NumericUpDown.Name = "CanvasMargin_NumericUpDown";
            this.CanvasMargin_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.CanvasMargin_NumericUpDown.TabIndex = 13;
            this.CanvasMargin_NumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // SeamGap_Label
            // 
            this.SeamGap_Label.AutoSize = true;
            this.SeamGap_Label.Location = new System.Drawing.Point(249, 43);
            this.SeamGap_Label.Name = "SeamGap_Label";
            this.SeamGap_Label.Size = new System.Drawing.Size(139, 26);
            this.SeamGap_Label.TabIndex = 0;
            this.SeamGap_Label.Text = "Max transparent rows\r\ndefining a seam (split sprite).";
            // 
            // GapThreshold_Label
            // 
            this.GapThreshold_Label.AutoSize = true;
            this.GapThreshold_Label.Location = new System.Drawing.Point(249, 12);
            this.GapThreshold_Label.Name = "GapThreshold_Label";
            this.GapThreshold_Label.Size = new System.Drawing.Size(113, 26);
            this.GapThreshold_Label.TabIndex = 0;
            this.GapThreshold_Label.Text = "Large gap threshold to\r\ndetect new sprites.";
            // 
            // InitialGapExtendedLimit_Label
            // 
            this.InitialGapExtendedLimit_Label.AutoSize = true;
            this.InitialGapExtendedLimit_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitialGapExtendedLimit_Label.Location = new System.Drawing.Point(62, 71);
            this.InitialGapExtendedLimit_Label.Name = "InitialGapExtendedLimit_Label";
            this.InitialGapExtendedLimit_Label.Size = new System.Drawing.Size(105, 26);
            this.InitialGapExtendedLimit_Label.TabIndex = 0;
            this.InitialGapExtendedLimit_Label.Text = "Max rows to search\r\ndeeper for first sprite.";
            // 
            // InitialGapThreshold_Label
            // 
            this.InitialGapThreshold_Label.AutoSize = true;
            this.InitialGapThreshold_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitialGapThreshold_Label.Location = new System.Drawing.Point(62, 38);
            this.InitialGapThreshold_Label.Name = "InitialGapThreshold_Label";
            this.InitialGapThreshold_Label.Size = new System.Drawing.Size(126, 26);
            this.InitialGapThreshold_Label.TabIndex = 0;
            this.InitialGapThreshold_Label.Text = "Expected top transparent\r\nrows before first sprite.";
            // 
            // TileSize_Label
            // 
            this.TileSize_Label.AutoSize = true;
            this.TileSize_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileSize_Label.Location = new System.Drawing.Point(62, 18);
            this.TileSize_Label.Name = "TileSize_Label";
            this.TileSize_Label.Size = new System.Drawing.Size(89, 13);
            this.TileSize_Label.TabIndex = 0;
            this.TileSize_Label.Text = "Size of each box.";
            // 
            // SeamGap_NumericUpDown
            // 
            this.SeamGap_NumericUpDown.Location = new System.Drawing.Point(193, 45);
            this.SeamGap_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.SeamGap_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeamGap_NumericUpDown.Name = "SeamGap_NumericUpDown";
            this.SeamGap_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.SeamGap_NumericUpDown.TabIndex = 12;
            this.SeamGap_NumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GapThreshold_NumericUpDown
            // 
            this.GapThreshold_NumericUpDown.Location = new System.Drawing.Point(193, 16);
            this.GapThreshold_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.GapThreshold_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GapThreshold_NumericUpDown.Name = "GapThreshold_NumericUpDown";
            this.GapThreshold_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.GapThreshold_NumericUpDown.TabIndex = 11;
            this.GapThreshold_NumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // InitialGapExtendedLimit_NumericUpDown
            // 
            this.InitialGapExtendedLimit_NumericUpDown.Location = new System.Drawing.Point(6, 74);
            this.InitialGapExtendedLimit_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.InitialGapExtendedLimit_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InitialGapExtendedLimit_NumericUpDown.Name = "InitialGapExtendedLimit_NumericUpDown";
            this.InitialGapExtendedLimit_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.InitialGapExtendedLimit_NumericUpDown.TabIndex = 10;
            this.InitialGapExtendedLimit_NumericUpDown.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            // 
            // InitialGapThreshold_NumericUpDown
            // 
            this.InitialGapThreshold_NumericUpDown.Location = new System.Drawing.Point(6, 45);
            this.InitialGapThreshold_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.InitialGapThreshold_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InitialGapThreshold_NumericUpDown.Name = "InitialGapThreshold_NumericUpDown";
            this.InitialGapThreshold_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.InitialGapThreshold_NumericUpDown.TabIndex = 9;
            this.InitialGapThreshold_NumericUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // TileSize_NumericUpDown
            // 
            this.TileSize_NumericUpDown.Location = new System.Drawing.Point(6, 16);
            this.TileSize_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.TileSize_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TileSize_NumericUpDown.Name = "TileSize_NumericUpDown";
            this.TileSize_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.TileSize_NumericUpDown.TabIndex = 8;
            this.TileSize_NumericUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // CopyData_Button
            // 
            this.CopyData_Button.Location = new System.Drawing.Point(6, 45);
            this.CopyData_Button.Name = "CopyData_Button";
            this.CopyData_Button.Size = new System.Drawing.Size(70, 23);
            this.CopyData_Button.TabIndex = 15;
            this.CopyData_Button.Text = "Copy Data";
            this.CopyData_Button.UseVisualStyleBackColor = true;
            // 
            // RefreshUI_Button
            // 
            this.RefreshUI_Button.Location = new System.Drawing.Point(6, 16);
            this.RefreshUI_Button.Name = "RefreshUI_Button";
            this.RefreshUI_Button.Size = new System.Drawing.Size(70, 23);
            this.RefreshUI_Button.TabIndex = 14;
            this.RefreshUI_Button.Text = "Refresh UI";
            this.RefreshUI_Button.UseVisualStyleBackColor = true;
            // 
            // DynamicLabeling_CheckBox
            // 
            this.DynamicLabeling_CheckBox.AutoSize = true;
            this.DynamicLabeling_CheckBox.Checked = true;
            this.DynamicLabeling_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DynamicLabeling_CheckBox.Location = new System.Drawing.Point(178, 36);
            this.DynamicLabeling_CheckBox.Name = "DynamicLabeling_CheckBox";
            this.DynamicLabeling_CheckBox.Size = new System.Drawing.Size(110, 17);
            this.DynamicLabeling_CheckBox.TabIndex = 7;
            this.DynamicLabeling_CheckBox.Text = "Dynamic Labeling";
            this.DynamicLabeling_CheckBox.UseVisualStyleBackColor = true;
            // 
            // UOffset_NumericUpDown
            // 
            this.UOffset_NumericUpDown.Enabled = false;
            this.UOffset_NumericUpDown.Location = new System.Drawing.Point(121, 9);
            this.UOffset_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.UOffset_NumericUpDown.Name = "UOffset_NumericUpDown";
            this.UOffset_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.UOffset_NumericUpDown.TabIndex = 5;
            // 
            // VOffset_NumericUpDown
            // 
            this.VOffset_NumericUpDown.Enabled = false;
            this.VOffset_NumericUpDown.Location = new System.Drawing.Point(121, 35);
            this.VOffset_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.VOffset_NumericUpDown.Name = "VOffset_NumericUpDown";
            this.VOffset_NumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.VOffset_NumericUpDown.TabIndex = 6;
            // 
            // VOffset_Label
            // 
            this.VOffset_Label.AutoSize = true;
            this.VOffset_Label.Location = new System.Drawing.Point(83, 37);
            this.VOffset_Label.Name = "VOffset_Label";
            this.VOffset_Label.Size = new System.Drawing.Size(38, 13);
            this.VOffset_Label.TabIndex = 0;
            this.VOffset_Label.Text = "Offset:";
            // 
            // UOffset_Label
            // 
            this.UOffset_Label.AutoSize = true;
            this.UOffset_Label.Location = new System.Drawing.Point(82, 11);
            this.UOffset_Label.Name = "UOffset_Label";
            this.UOffset_Label.Size = new System.Drawing.Size(38, 13);
            this.UOffset_Label.TabIndex = 0;
            this.UOffset_Label.Text = "Offset:";
            // 
            // UVDataSettings_GroupBox
            // 
            this.UVDataSettings_GroupBox.Controls.Add(this.Alerts_CheckBox);
            this.UVDataSettings_GroupBox.Controls.Add(this.DataFormatting_GroupBox);
            this.UVDataSettings_GroupBox.Controls.Add(this.CopyData_Button);
            this.UVDataSettings_GroupBox.Controls.Add(this.RefreshUI_Button);
            this.UVDataSettings_GroupBox.Controls.Add(this.TileCount_GroupBox);
            this.UVDataSettings_GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UVDataSettings_GroupBox.Location = new System.Drawing.Point(689, 3);
            this.UVDataSettings_GroupBox.Name = "UVDataSettings_GroupBox";
            this.UVDataSettings_GroupBox.Size = new System.Drawing.Size(203, 101);
            this.UVDataSettings_GroupBox.TabIndex = 0;
            this.UVDataSettings_GroupBox.TabStop = false;
            this.UVDataSettings_GroupBox.Text = "UV Data Settings:";
            // 
            // Alerts_CheckBox
            // 
            this.Alerts_CheckBox.AutoSize = true;
            this.Alerts_CheckBox.Location = new System.Drawing.Point(8, 74);
            this.Alerts_CheckBox.Name = "Alerts_CheckBox";
            this.Alerts_CheckBox.Size = new System.Drawing.Size(52, 17);
            this.Alerts_CheckBox.TabIndex = 16;
            this.Alerts_CheckBox.Text = "Alerts";
            this.Alerts_CheckBox.UseVisualStyleBackColor = true;
            // 
            // DataFormatting_GroupBox
            // 
            this.DataFormatting_GroupBox.Controls.Add(this.RowSorting_RadioButton);
            this.DataFormatting_GroupBox.Controls.Add(this.ColumnSorting_RadioButton);
            this.DataFormatting_GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DataFormatting_GroupBox.Location = new System.Drawing.Point(82, 13);
            this.DataFormatting_GroupBox.Name = "DataFormatting_GroupBox";
            this.DataFormatting_GroupBox.Size = new System.Drawing.Size(115, 60);
            this.DataFormatting_GroupBox.TabIndex = 0;
            this.DataFormatting_GroupBox.TabStop = false;
            this.DataFormatting_GroupBox.Text = "Data Formatting:";
            // 
            // RowSorting_RadioButton
            // 
            this.RowSorting_RadioButton.AutoSize = true;
            this.RowSorting_RadioButton.Location = new System.Drawing.Point(10, 37);
            this.RowSorting_RadioButton.Name = "RowSorting_RadioButton";
            this.RowSorting_RadioButton.Size = new System.Drawing.Size(89, 17);
            this.RowSorting_RadioButton.TabIndex = 18;
            this.RowSorting_RadioButton.TabStop = true;
            this.RowSorting_RadioButton.Text = "Sort By Rows";
            this.RowSorting_RadioButton.UseVisualStyleBackColor = true;
            // 
            // ColumnSorting_RadioButton
            // 
            this.ColumnSorting_RadioButton.AutoSize = true;
            this.ColumnSorting_RadioButton.Checked = true;
            this.ColumnSorting_RadioButton.Location = new System.Drawing.Point(10, 16);
            this.ColumnSorting_RadioButton.Name = "ColumnSorting_RadioButton";
            this.ColumnSorting_RadioButton.Size = new System.Drawing.Size(102, 17);
            this.ColumnSorting_RadioButton.TabIndex = 17;
            this.ColumnSorting_RadioButton.TabStop = true;
            this.ColumnSorting_RadioButton.Text = "Sort By Columns";
            this.ColumnSorting_RadioButton.UseVisualStyleBackColor = true;
            // 
            // TileCount_GroupBox
            // 
            this.TileCount_GroupBox.Controls.Add(this.TileCount_Label);
            this.TileCount_GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TileCount_GroupBox.Location = new System.Drawing.Point(82, 66);
            this.TileCount_GroupBox.Name = "TileCount_GroupBox";
            this.TileCount_GroupBox.Size = new System.Drawing.Size(115, 29);
            this.TileCount_GroupBox.TabIndex = 0;
            this.TileCount_GroupBox.TabStop = false;
            // 
            // TileCount_Label
            // 
            this.TileCount_Label.AutoSize = true;
            this.TileCount_Label.Location = new System.Drawing.Point(7, 9);
            this.TileCount_Label.Name = "TileCount_Label";
            this.TileCount_Label.Size = new System.Drawing.Size(67, 13);
            this.TileCount_Label.TabIndex = 0;
            this.TileCount_Label.Text = "Tile Count: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(898, 661);
            this.Controls.Add(this.UVDataSettings_GroupBox);
            this.Controls.Add(this.UOffset_NumericUpDown);
            this.Controls.Add(this.VOffset_NumericUpDown);
            this.Controls.Add(this.VOffset_Label);
            this.Controls.Add(this.UOffset_Label);
            this.Controls.Add(this.LoadXnb_Button);
            this.Controls.Add(this.TileU_NumericUpDown);
            this.Controls.Add(this.TileV_NumericUpDown);
            this.Controls.Add(this.DynamicLabeling_CheckBox);
            this.Controls.Add(this.TextureDetectionSettings_GroupBox);
            this.Controls.Add(this.TextureInfo_Grid);
            this.Controls.Add(this.V_Label);
            this.Controls.Add(this.U_Label);
            this.Controls.Add(this.Zoom_Label);
            this.Controls.Add(this.Zoom_TrackBar);
            this.Controls.Add(this.XnbView_Panel);
            this.Name = "MainForm";
            this.Text = "XNB UVExplorer";
            ((System.ComponentModel.ISupportInitialize)(this.TileU_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileV_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom_TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureInfo_Grid)).EndInit();
            this.TextureDetectionSettings_GroupBox.ResumeLayout(false);
            this.TextureDetectionSettings_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasMargin_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeamGap_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GapThreshold_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitialGapExtendedLimit_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitialGapThreshold_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileSize_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOffset_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VOffset_NumericUpDown)).EndInit();
            this.UVDataSettings_GroupBox.ResumeLayout(false);
            this.UVDataSettings_GroupBox.PerformLayout();
            this.DataFormatting_GroupBox.ResumeLayout(false);
            this.DataFormatting_GroupBox.PerformLayout();
            this.TileCount_GroupBox.ResumeLayout(false);
            this.TileCount_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel XnbView_Panel;
        private System.Windows.Forms.Button LoadXnb_Button;
        private System.Windows.Forms.NumericUpDown TileU_NumericUpDown;
        private System.Windows.Forms.NumericUpDown TileV_NumericUpDown;
        private System.Windows.Forms.TrackBar Zoom_TrackBar;
        private System.Windows.Forms.Label Zoom_Label;
        private System.Windows.Forms.Label U_Label;
        private System.Windows.Forms.Label V_Label;
        private System.Windows.Forms.DataGridView TextureInfo_Grid;
        private System.Windows.Forms.GroupBox TextureDetectionSettings_GroupBox;
        private System.Windows.Forms.CheckBox DynamicLabeling_CheckBox;
        private System.Windows.Forms.NumericUpDown UOffset_NumericUpDown;
        private System.Windows.Forms.NumericUpDown VOffset_NumericUpDown;
        private System.Windows.Forms.Label VOffset_Label;
        private System.Windows.Forms.Label UOffset_Label;
        private System.Windows.Forms.NumericUpDown SeamGap_NumericUpDown;
        private System.Windows.Forms.NumericUpDown GapThreshold_NumericUpDown;
        private System.Windows.Forms.NumericUpDown InitialGapExtendedLimit_NumericUpDown;
        private System.Windows.Forms.NumericUpDown InitialGapThreshold_NumericUpDown;
        private System.Windows.Forms.NumericUpDown TileSize_NumericUpDown;
        private System.Windows.Forms.Label TileSize_Label;
        private System.Windows.Forms.Label InitialGapThreshold_Label;
        private System.Windows.Forms.Label InitialGapExtendedLimit_Label;
        private System.Windows.Forms.Label SeamGap_Label;
        private System.Windows.Forms.Label GapThreshold_Label;
        private System.Windows.Forms.Button RefreshUI_Button;
        private System.Windows.Forms.NumericUpDown CanvasMargin_NumericUpDown;
        private System.Windows.Forms.Label CanvasMargin_Label;
        private System.Windows.Forms.Button CopyData_Button;
        private System.Windows.Forms.GroupBox UVDataSettings_GroupBox;
        private System.Windows.Forms.RadioButton RowSorting_RadioButton;
        private System.Windows.Forms.RadioButton ColumnSorting_RadioButton;
        private System.Windows.Forms.GroupBox DataFormatting_GroupBox;
        private System.Windows.Forms.CheckBox Alerts_CheckBox;
        private System.Windows.Forms.GroupBox TileCount_GroupBox;
        private System.Windows.Forms.Label TileCount_Label;
    }
}

