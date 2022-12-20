namespace View
{
    partial class MainFormApp
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitContainerItem = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Btn_Recipe = new System.Windows.Forms.Button();
            this.Btn_LogIn = new System.Windows.Forms.Button();
            this.TextBox_UID = new System.Windows.Forms.TextBox();
            this.Label_MES_IsConnect = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label_ViewTime = new System.Windows.Forms.Label();
            this.Btn_SearchLog = new System.Windows.Forms.Button();
            this.Btn_Setting = new System.Windows.Forms.Button();
            this.Btn_SendEDC = new System.Windows.Forms.Button();
            this.Label_PLC2_IsConnect = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Label_PLC1_IsConnect = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_LotLog = new System.Windows.Forms.Button();
            this.Btn_LoadPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerItem)).BeginInit();
            this.SplitContainerItem.Panel1.SuspendLayout();
            this.SplitContainerItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainerItem
            // 
            this.SplitContainerItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerItem.IsSplitterFixed = true;
            this.SplitContainerItem.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerItem.Name = "SplitContainerItem";
            this.SplitContainerItem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerItem.Panel1
            // 
            this.SplitContainerItem.Panel1.Controls.Add(this.label2);
            this.SplitContainerItem.Panel1.Controls.Add(this.button2);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_Recipe);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_LogIn);
            this.SplitContainerItem.Panel1.Controls.Add(this.TextBox_UID);
            this.SplitContainerItem.Panel1.Controls.Add(this.Label_MES_IsConnect);
            this.SplitContainerItem.Panel1.Controls.Add(this.label4);
            this.SplitContainerItem.Panel1.Controls.Add(this.Label_ViewTime);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_SearchLog);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_Setting);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_SendEDC);
            this.SplitContainerItem.Panel1.Controls.Add(this.Label_PLC2_IsConnect);
            this.SplitContainerItem.Panel1.Controls.Add(this.label3);
            this.SplitContainerItem.Panel1.Controls.Add(this.Label_PLC1_IsConnect);
            this.SplitContainerItem.Panel1.Controls.Add(this.label1);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_LotLog);
            this.SplitContainerItem.Panel1.Controls.Add(this.Btn_LoadPage);
            this.SplitContainerItem.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainerItem_Panel1_Paint);
            // 
            // SplitContainerItem.Panel2
            // 
            this.SplitContainerItem.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainerItem.Size = new System.Drawing.Size(1918, 1038);
            this.SplitContainerItem.SplitterDistance = 48;
            this.SplitContainerItem.SplitterWidth = 1;
            this.SplitContainerItem.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1252, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ver 3.3.16";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(899, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 42);
            this.button2.TabIndex = 37;
            this.button2.Text = "ADC";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Btn_Recipe
            // 
            this.Btn_Recipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_Recipe.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_Recipe.FlatAppearance.BorderSize = 0;
            this.Btn_Recipe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_Recipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_Recipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Recipe.Font = new System.Drawing.Font("微軟正黑體", 15.75F);
            this.Btn_Recipe.ForeColor = System.Drawing.Color.White;
            this.Btn_Recipe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Recipe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_Recipe.Location = new System.Drawing.Point(698, 2);
            this.Btn_Recipe.Name = "Btn_Recipe";
            this.Btn_Recipe.Size = new System.Drawing.Size(120, 42);
            this.Btn_Recipe.TabIndex = 36;
            this.Btn_Recipe.Text = "Recipe";
            this.Btn_Recipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Recipe.UseVisualStyleBackColor = false;
            this.Btn_Recipe.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // Btn_LogIn
            // 
            this.Btn_LogIn.BackColor = System.Drawing.Color.Honeydew;
            this.Btn_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LogIn.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_LogIn.Location = new System.Drawing.Point(1697, 3);
            this.Btn_LogIn.Name = "Btn_LogIn";
            this.Btn_LogIn.Size = new System.Drawing.Size(67, 40);
            this.Btn_LogIn.TabIndex = 35;
            this.Btn_LogIn.Text = "登入";
            this.Btn_LogIn.UseVisualStyleBackColor = false;
            this.Btn_LogIn.Click += new System.EventHandler(this.Btn_LogIn_Click);
            // 
            // TextBox_UID
            // 
            this.TextBox_UID.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_UID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TextBox_UID.Location = new System.Drawing.Point(1356, 4);
            this.TextBox_UID.Name = "TextBox_UID";
            this.TextBox_UID.Size = new System.Drawing.Size(335, 39);
            this.TextBox_UID.TabIndex = 34;
            this.TextBox_UID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_UID_KeyPress);
            // 
            // Label_MES_IsConnect
            // 
            this.Label_MES_IsConnect.AutoSize = true;
            this.Label_MES_IsConnect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_MES_IsConnect.Location = new System.Drawing.Point(1283, 4);
            this.Label_MES_IsConnect.Name = "Label_MES_IsConnect";
            this.Label_MES_IsConnect.Size = new System.Drawing.Size(67, 24);
            this.Label_MES_IsConnect.TabIndex = 16;
            this.Label_MES_IsConnect.Text = "未連線";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(1214, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "MES : ";
            // 
            // Label_ViewTime
            // 
            this.Label_ViewTime.AutoSize = true;
            this.Label_ViewTime.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_ViewTime.Location = new System.Drawing.Point(1770, 3);
            this.Label_ViewTime.Name = "Label_ViewTime";
            this.Label_ViewTime.Size = new System.Drawing.Size(145, 40);
            this.Label_ViewTime.TabIndex = 14;
            this.Label_ViewTime.Text = "00:00:00";
            // 
            // Btn_SearchLog
            // 
            this.Btn_SearchLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_SearchLog.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_SearchLog.FlatAppearance.BorderSize = 0;
            this.Btn_SearchLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_SearchLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_SearchLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SearchLog.Font = new System.Drawing.Font("微軟正黑體", 15.75F);
            this.Btn_SearchLog.ForeColor = System.Drawing.Color.White;
            this.Btn_SearchLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_SearchLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_SearchLog.Location = new System.Drawing.Point(281, 2);
            this.Btn_SearchLog.Name = "Btn_SearchLog";
            this.Btn_SearchLog.Size = new System.Drawing.Size(120, 42);
            this.Btn_SearchLog.TabIndex = 13;
            this.Btn_SearchLog.Text = "EquiLog";
            this.Btn_SearchLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_SearchLog.UseVisualStyleBackColor = false;
            this.Btn_SearchLog.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_Setting.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_Setting.FlatAppearance.BorderSize = 0;
            this.Btn_Setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_Setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Setting.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Setting.ForeColor = System.Drawing.Color.White;
            this.Btn_Setting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Setting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_Setting.Location = new System.Drawing.Point(420, 2);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.Size = new System.Drawing.Size(120, 42);
            this.Btn_Setting.TabIndex = 11;
            this.Btn_Setting.Text = "Setting";
            this.Btn_Setting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Setting.UseVisualStyleBackColor = false;
            this.Btn_Setting.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // Btn_SendEDC
            // 
            this.Btn_SendEDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_SendEDC.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_SendEDC.FlatAppearance.BorderSize = 0;
            this.Btn_SendEDC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_SendEDC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_SendEDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SendEDC.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_SendEDC.ForeColor = System.Drawing.Color.White;
            this.Btn_SendEDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_SendEDC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_SendEDC.Location = new System.Drawing.Point(559, 2);
            this.Btn_SendEDC.Name = "Btn_SendEDC";
            this.Btn_SendEDC.Size = new System.Drawing.Size(120, 42);
            this.Btn_SendEDC.TabIndex = 12;
            this.Btn_SendEDC.Text = "EDC";
            this.Btn_SendEDC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_SendEDC.UseVisualStyleBackColor = false;
            this.Btn_SendEDC.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // Label_PLC2_IsConnect
            // 
            this.Label_PLC2_IsConnect.AutoSize = true;
            this.Label_PLC2_IsConnect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_PLC2_IsConnect.Location = new System.Drawing.Point(1130, 24);
            this.Label_PLC2_IsConnect.Name = "Label_PLC2_IsConnect";
            this.Label_PLC2_IsConnect.Size = new System.Drawing.Size(67, 24);
            this.Label_PLC2_IsConnect.TabIndex = 9;
            this.Label_PLC2_IsConnect.Text = "未連線";
            this.Label_PLC2_IsConnect.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1065, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "PLC2 : ";
            this.label3.Visible = false;
            // 
            // Label_PLC1_IsConnect
            // 
            this.Label_PLC1_IsConnect.AutoSize = true;
            this.Label_PLC1_IsConnect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_PLC1_IsConnect.Location = new System.Drawing.Point(1130, 3);
            this.Label_PLC1_IsConnect.Name = "Label_PLC1_IsConnect";
            this.Label_PLC1_IsConnect.Size = new System.Drawing.Size(67, 24);
            this.Label_PLC1_IsConnect.TabIndex = 7;
            this.Label_PLC1_IsConnect.Text = "未連線";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(1065, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "PLC1 : ";
            // 
            // Btn_LotLog
            // 
            this.Btn_LotLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_LotLog.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_LotLog.FlatAppearance.BorderSize = 0;
            this.Btn_LotLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_LotLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_LotLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LotLog.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_LotLog.ForeColor = System.Drawing.Color.White;
            this.Btn_LotLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_LotLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_LotLog.Location = new System.Drawing.Point(142, 2);
            this.Btn_LotLog.Name = "Btn_LotLog";
            this.Btn_LotLog.Size = new System.Drawing.Size(120, 42);
            this.Btn_LotLog.TabIndex = 2;
            this.Btn_LotLog.Text = "LotLog";
            this.Btn_LotLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_LotLog.UseVisualStyleBackColor = false;
            this.Btn_LotLog.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // Btn_LoadPage
            // 
            this.Btn_LoadPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.Btn_LoadPage.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_LoadPage.FlatAppearance.BorderSize = 0;
            this.Btn_LoadPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_LoadPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Btn_LoadPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LoadPage.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_LoadPage.ForeColor = System.Drawing.Color.White;
            this.Btn_LoadPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_LoadPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_LoadPage.Location = new System.Drawing.Point(3, 2);
            this.Btn_LoadPage.Name = "Btn_LoadPage";
            this.Btn_LoadPage.Size = new System.Drawing.Size(120, 42);
            this.Btn_LoadPage.TabIndex = 1;
            this.Btn_LoadPage.Text = "Load";
            this.Btn_LoadPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_LoadPage.UseVisualStyleBackColor = false;
            this.Btn_LoadPage.Click += new System.EventHandler(this.PageBtn_Click);
            // 
            // MainFormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1918, 1038);
            this.Controls.Add(this.SplitContainerItem);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.MinimumSize = new System.Drawing.Size(1918, 1038);
            this.Name = "MainFormApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SplitContainerItem.Panel1.ResumeLayout(false);
            this.SplitContainerItem.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerItem)).EndInit();
            this.SplitContainerItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainerItem;
        private System.Windows.Forms.Button Btn_LotLog;
        private System.Windows.Forms.Label Label_PLC1_IsConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label_PLC2_IsConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Setting;
        public System.Windows.Forms.Button Btn_LoadPage;
        private System.Windows.Forms.Button Btn_SendEDC;
        private System.Windows.Forms.Button Btn_SearchLog;
        private System.Windows.Forms.Label Label_ViewTime;
        private System.Windows.Forms.Label Label_MES_IsConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_LogIn;
        private System.Windows.Forms.TextBox TextBox_UID;
        private System.Windows.Forms.Button Btn_Recipe;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}

