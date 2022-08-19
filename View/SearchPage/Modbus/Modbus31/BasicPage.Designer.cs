namespace View.SearchPage.Modbus31
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumUpDown_Limit = new System.Windows.Forms.NumericUpDown();
            this.RBtn_UseDateRange = new System.Windows.Forms.RadioButton();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPicker_End = new System.Windows.Forms.DateTimePicker();
            this.DTPicker_Start = new System.Windows.Forms.DateTimePicker();
            this.RBtn_UseLotNo = new System.Windows.Forms.RadioButton();
            this.TextBox_LotNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Limit)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.DGV.Size = new System.Drawing.Size(1903, 822);
            this.DGV.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DTPicker_End);
            this.panel1.Controls.Add(this.DTPicker_Start);
            this.panel1.Controls.Add(this.RBtn_UseLotNo);
            this.panel1.Controls.Add(this.TextBox_LotNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NumUpDown_Limit);
            this.panel1.Controls.Add(this.RBtn_UseDateRange);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Location = new System.Drawing.Point(9, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1903, 97);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 40;
            this.label1.Text = "顯示最大筆數:";
            // 
            // NumUpDown_Limit
            // 
            this.NumUpDown_Limit.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NumUpDown_Limit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumUpDown_Limit.Location = new System.Drawing.Point(191, 53);
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
            this.NumUpDown_Limit.TabIndex = 39;
            this.NumUpDown_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_Limit.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // RBtn_UseDateRange
            // 
            this.RBtn_UseDateRange.AutoSize = true;
            this.RBtn_UseDateRange.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_UseDateRange.Location = new System.Drawing.Point(22, 3);
            this.RBtn_UseDateRange.Name = "RBtn_UseDateRange";
            this.RBtn_UseDateRange.Size = new System.Drawing.Size(163, 44);
            this.RBtn_UseDateRange.TabIndex = 33;
            this.RBtn_UseDateRange.TabStop = true;
            this.RBtn_UseDateRange.Text = "時間區間";
            this.RBtn_UseDateRange.UseVisualStyleBackColor = true;
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
            this.panel2.Location = new System.Drawing.Point(9, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1903, 822);
            this.panel2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(458, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 36);
            this.label4.TabIndex = 48;
            this.label4.Text = "-";
            // 
            // DTPicker_End
            // 
            this.DTPicker_End.CustomFormat = "yyyy:MM:dd HH:mm";
            this.DTPicker_End.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DTPicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPicker_End.Location = new System.Drawing.Point(492, 6);
            this.DTPicker_End.Name = "DTPicker_End";
            this.DTPicker_End.Size = new System.Drawing.Size(262, 43);
            this.DTPicker_End.TabIndex = 47;
            this.DTPicker_End.Value = new System.DateTime(2021, 4, 12, 23, 59, 59, 0);
            // 
            // DTPicker_Start
            // 
            this.DTPicker_Start.CustomFormat = "yyyy:MM:dd HH:mm";
            this.DTPicker_Start.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DTPicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPicker_Start.Location = new System.Drawing.Point(191, 5);
            this.DTPicker_Start.Name = "DTPicker_Start";
            this.DTPicker_Start.Size = new System.Drawing.Size(261, 43);
            this.DTPicker_Start.TabIndex = 46;
            this.DTPicker_Start.Value = new System.DateTime(2021, 4, 12, 0, 0, 1, 0);
            // 
            // RBtn_UseLotNo
            // 
            this.RBtn_UseLotNo.AutoSize = true;
            this.RBtn_UseLotNo.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RBtn_UseLotNo.Location = new System.Drawing.Point(779, 3);
            this.RBtn_UseLotNo.Name = "RBtn_UseLotNo";
            this.RBtn_UseLotNo.Size = new System.Drawing.Size(129, 44);
            this.RBtn_UseLotNo.TabIndex = 45;
            this.RBtn_UseLotNo.TabStop = true;
            this.RBtn_UseLotNo.Text = "LotNo";
            this.RBtn_UseLotNo.UseVisualStyleBackColor = true;
            // 
            // TextBox_LotNo
            // 
            this.TextBox_LotNo.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_LotNo.Location = new System.Drawing.Point(914, 4);
            this.TextBox_LotNo.Name = "TextBox_LotNo";
            this.TextBox_LotNo.Size = new System.Drawing.Size(480, 43);
            this.TextBox_LotNo.TabIndex = 44;
            // 
            // BasicPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 926);
            this.MinimumSize = new System.Drawing.Size(1920, 926);
            this.Name = "BasicPage";
            this.Size = new System.Drawing.Size(1920, 926);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Limit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumUpDown_Limit;
        private System.Windows.Forms.RadioButton RBtn_UseDateRange;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPicker_End;
        private System.Windows.Forms.DateTimePicker DTPicker_Start;
        private System.Windows.Forms.RadioButton RBtn_UseLotNo;
        private System.Windows.Forms.TextBox TextBox_LotNo;
    }
}
