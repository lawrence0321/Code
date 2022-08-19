namespace View.SearchPage.Rectifier
{
    partial class BasicPage
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBtn_UseDateRange = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.NumUpDown_Limit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RBtn_ALL = new System.Windows.Forms.RadioButton();
            this.NumUpDown_Interval = new System.Windows.Forms.NumericUpDown();
            this.RBtn_Ni = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RBtn_AuSt = new System.Windows.Forms.RadioButton();
            this.RBtn_Au = new System.Windows.Forms.RadioButton();
            this.RBtn_UseLotNo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_LotNo = new System.Windows.Forms.TextBox();
            this.DTPicker_End = new System.Windows.Forms.DateTimePicker();
            this.DTPicker_Start = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Limit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Interval)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.RBtn_UseLotNo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TextBox_LotNo);
            this.panel1.Controls.Add(this.DTPicker_End);
            this.panel1.Controls.Add(this.DTPicker_Start);
            this.panel1.Controls.Add(this.RBtn_UseDateRange);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Location = new System.Drawing.Point(10, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1903, 55);
            this.panel1.TabIndex = 4;
            // 
            // RBtn_UseDateRange
            // 
            this.RBtn_UseDateRange.AutoSize = true;
            this.RBtn_UseDateRange.Checked = true;
            this.RBtn_UseDateRange.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_UseDateRange.Location = new System.Drawing.Point(22, 3);
            this.RBtn_UseDateRange.Name = "RBtn_UseDateRange";
            this.RBtn_UseDateRange.Size = new System.Drawing.Size(163, 44);
            this.RBtn_UseDateRange.TabIndex = 33;
            this.RBtn_UseDateRange.TabStop = true;
            this.RBtn_UseDateRange.Text = "時間區間";
            this.RBtn_UseDateRange.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(1693, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 45);
            this.button2.TabIndex = 9;
            this.button2.Text = "匯出";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Btn_Search
            // 
            this.Btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Search.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Search.Location = new System.Drawing.Point(1509, 3);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(178, 45);
            this.Btn_Search.TabIndex = 8;
            this.Btn_Search.Text = "查詢";
            this.Btn_Search.UseVisualStyleBackColor = false;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.DGV);
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(10, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1903, 790);
            this.panel2.TabIndex = 5;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(1903, 790);
            this.DGV.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.NumUpDown_Limit);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.RBtn_ALL);
            this.panel3.Controls.Add(this.NumUpDown_Interval);
            this.panel3.Controls.Add(this.RBtn_Ni);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.RBtn_AuSt);
            this.panel3.Controls.Add(this.RBtn_Au);
            this.panel3.Location = new System.Drawing.Point(10, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1903, 63);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(807, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 51;
            this.label3.Text = "顯示最大筆數:";
            // 
            // NumUpDown_Limit
            // 
            this.NumUpDown_Limit.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NumUpDown_Limit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumUpDown_Limit.Location = new System.Drawing.Point(976, 12);
            this.NumUpDown_Limit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumUpDown_Limit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_Limit.Name = "NumUpDown_Limit";
            this.NumUpDown_Limit.Size = new System.Drawing.Size(120, 39);
            this.NumUpDown_Limit.TabIndex = 50;
            this.NumUpDown_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_Limit.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(745, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 34);
            this.label2.TabIndex = 49;
            this.label2.Text = "秒";
            // 
            // RBtn_ALL
            // 
            this.RBtn_ALL.AutoSize = true;
            this.RBtn_ALL.Checked = true;
            this.RBtn_ALL.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_ALL.Location = new System.Drawing.Point(22, 13);
            this.RBtn_ALL.Name = "RBtn_ALL";
            this.RBtn_ALL.Size = new System.Drawing.Size(80, 38);
            this.RBtn_ALL.TabIndex = 43;
            this.RBtn_ALL.TabStop = true;
            this.RBtn_ALL.Text = "ALL";
            this.RBtn_ALL.UseVisualStyleBackColor = true;
            this.RBtn_ALL.CheckedChanged += new System.EventHandler(this.RBtn_CheckedChanged);
            // 
            // NumUpDown_Interval
            // 
            this.NumUpDown_Interval.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NumUpDown_Interval.Location = new System.Drawing.Point(619, 11);
            this.NumUpDown_Interval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDown_Interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_Interval.Name = "NumUpDown_Interval";
            this.NumUpDown_Interval.Size = new System.Drawing.Size(120, 43);
            this.NumUpDown_Interval.TabIndex = 48;
            this.NumUpDown_Interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_Interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RBtn_Ni
            // 
            this.RBtn_Ni.AutoSize = true;
            this.RBtn_Ni.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_Ni.Location = new System.Drawing.Point(142, 13);
            this.RBtn_Ni.Name = "RBtn_Ni";
            this.RBtn_Ni.Size = new System.Drawing.Size(62, 38);
            this.RBtn_Ni.TabIndex = 44;
            this.RBtn_Ni.Text = "Ni";
            this.RBtn_Ni.UseVisualStyleBackColor = true;
            this.RBtn_Ni.CheckedChanged += new System.EventHandler(this.RBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(484, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 34);
            this.label1.TabIndex = 47;
            this.label1.Text = "時間間隔:";
            // 
            // RBtn_AuSt
            // 
            this.RBtn_AuSt.AutoSize = true;
            this.RBtn_AuSt.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_AuSt.Location = new System.Drawing.Point(352, 13);
            this.RBtn_AuSt.Name = "RBtn_AuSt";
            this.RBtn_AuSt.Size = new System.Drawing.Size(93, 38);
            this.RBtn_AuSt.TabIndex = 45;
            this.RBtn_AuSt.Text = "AuSt";
            this.RBtn_AuSt.UseVisualStyleBackColor = true;
            this.RBtn_AuSt.CheckedChanged += new System.EventHandler(this.RBtn_CheckedChanged);
            // 
            // RBtn_Au
            // 
            this.RBtn_Au.AutoSize = true;
            this.RBtn_Au.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_Au.Location = new System.Drawing.Point(244, 13);
            this.RBtn_Au.Name = "RBtn_Au";
            this.RBtn_Au.Size = new System.Drawing.Size(68, 38);
            this.RBtn_Au.TabIndex = 46;
            this.RBtn_Au.Text = "Au";
            this.RBtn_Au.UseVisualStyleBackColor = true;
            this.RBtn_Au.CheckedChanged += new System.EventHandler(this.RBtn_CheckedChanged);
            // 
            // RBtn_UseLotNo
            // 
            this.RBtn_UseLotNo.AutoSize = true;
            this.RBtn_UseLotNo.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_UseLotNo.Location = new System.Drawing.Point(796, 4);
            this.RBtn_UseLotNo.Name = "RBtn_UseLotNo";
            this.RBtn_UseLotNo.Size = new System.Drawing.Size(129, 44);
            this.RBtn_UseLotNo.TabIndex = 39;
            this.RBtn_UseLotNo.TabStop = true;
            this.RBtn_UseLotNo.Text = "LotNo";
            this.RBtn_UseLotNo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(460, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 36);
            this.label4.TabIndex = 38;
            this.label4.Text = "-";
            // 
            // TextBox_LotNo
            // 
            this.TextBox_LotNo.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_LotNo.Location = new System.Drawing.Point(931, 5);
            this.TextBox_LotNo.Name = "TextBox_LotNo";
            this.TextBox_LotNo.Size = new System.Drawing.Size(480, 43);
            this.TextBox_LotNo.TabIndex = 37;
            // 
            // DTPicker_End
            // 
            this.DTPicker_End.CustomFormat = "yyyy/MM/dd HH:mm";
            this.DTPicker_End.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DTPicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPicker_End.Location = new System.Drawing.Point(494, 5);
            this.DTPicker_End.Name = "DTPicker_End";
            this.DTPicker_End.Size = new System.Drawing.Size(274, 43);
            this.DTPicker_End.TabIndex = 36;
            this.DTPicker_End.Value = new System.DateTime(2021, 4, 12, 23, 59, 59, 0);
            // 
            // DTPicker_Start
            // 
            this.DTPicker_Start.CustomFormat = "yyyy/MM/dd HH:mm";
            this.DTPicker_Start.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DTPicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPicker_Start.Location = new System.Drawing.Point(191, 5);
            this.DTPicker_Start.Name = "DTPicker_Start";
            this.DTPicker_Start.Size = new System.Drawing.Size(263, 43);
            this.DTPicker_Start.TabIndex = 35;
            this.DTPicker_Start.Value = new System.DateTime(2021, 4, 12, 0, 0, 1, 0);
            // 
            // BasicPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 926);
            this.MinimumSize = new System.Drawing.Size(1920, 926);
            this.Name = "BasicPage";
            this.Size = new System.Drawing.Size(1920, 926);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Limit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Interval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.RadioButton RBtn_UseDateRange;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RBtn_ALL;
        private System.Windows.Forms.NumericUpDown NumUpDown_Interval;
        private System.Windows.Forms.RadioButton RBtn_Ni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBtn_AuSt;
        private System.Windows.Forms.RadioButton RBtn_Au;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumUpDown_Limit;
        private System.Windows.Forms.RadioButton RBtn_UseLotNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_LotNo;
        private System.Windows.Forms.DateTimePicker DTPicker_End;
        private System.Windows.Forms.DateTimePicker DTPicker_Start;
    }
}
