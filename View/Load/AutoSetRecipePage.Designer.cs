
namespace View.Load
{
    partial class AutoSetRecipePage
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.NumUpDown_CarQuantity = new System.Windows.Forms.NumericUpDown();
            this.Label_CarQuantity = new System.Windows.Forms.Label();
            this.CheckBox_RockOnly = new System.Windows.Forms.CheckBox();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.CheckBox_SpecialCrane = new System.Windows.Forms.CheckBox();
            this.Btn_AutoEnter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBox_LotNo = new System.Windows.Forms.TextBox();
            this.NumUpDown_TotalQuantity = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.Label_ShowMod = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_CarQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TotalQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.Label_ShowMod);
            this.panel5.Controls.Add(this.NumUpDown_CarQuantity);
            this.panel5.Controls.Add(this.Label_CarQuantity);
            this.panel5.Controls.Add(this.CheckBox_RockOnly);
            this.panel5.Controls.Add(this.Btn_Close);
            this.panel5.Controls.Add(this.CheckBox_SpecialCrane);
            this.panel5.Controls.Add(this.Btn_AutoEnter);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.TextBox_LotNo);
            this.panel5.Controls.Add(this.NumUpDown_TotalQuantity);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Location = new System.Drawing.Point(12, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(660, 314);
            this.panel5.TabIndex = 7;
            // 
            // NumUpDown_CarQuantity
            // 
            this.NumUpDown_CarQuantity.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NumUpDown_CarQuantity.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumUpDown_CarQuantity.Location = new System.Drawing.Point(515, 132);
            this.NumUpDown_CarQuantity.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.NumUpDown_CarQuantity.Name = "NumUpDown_CarQuantity";
            this.NumUpDown_CarQuantity.Size = new System.Drawing.Size(126, 43);
            this.NumUpDown_CarQuantity.TabIndex = 44;
            this.NumUpDown_CarQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_CarQuantity
            // 
            this.Label_CarQuantity.AutoSize = true;
            this.Label_CarQuantity.Font = new System.Drawing.Font("微軟正黑體", 20.25F);
            this.Label_CarQuantity.Location = new System.Drawing.Point(417, 136);
            this.Label_CarQuantity.Name = "Label_CarQuantity";
            this.Label_CarQuantity.Size = new System.Drawing.Size(96, 34);
            this.Label_CarQuantity.TabIndex = 43;
            this.Label_CarQuantity.Text = "總車數";
            // 
            // CheckBox_RockOnly
            // 
            this.CheckBox_RockOnly.AutoSize = true;
            this.CheckBox_RockOnly.Checked = true;
            this.CheckBox_RockOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_RockOnly.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CheckBox_RockOnly.Location = new System.Drawing.Point(344, 136);
            this.CheckBox_RockOnly.Name = "CheckBox_RockOnly";
            this.CheckBox_RockOnly.Size = new System.Drawing.Size(88, 38);
            this.CheckBox_RockOnly.TabIndex = 42;
            this.CheckBox_RockOnly.Text = "空掛";
            this.CheckBox_RockOnly.UseVisualStyleBackColor = true;
            this.CheckBox_RockOnly.CheckedChanged += new System.EventHandler(this.CheckBox_RockOnly_CheckedChanged);
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Close.BackgroundImage = global::View.Properties.Resources.Cancel_48;
            this.Btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Close.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Location = new System.Drawing.Point(600, 0);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(60, 60);
            this.Btn_Close.TabIndex = 8;
            this.Btn_Close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Close.UseVisualStyleBackColor = false;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // CheckBox_SpecialCrane
            // 
            this.CheckBox_SpecialCrane.AutoSize = true;
            this.CheckBox_SpecialCrane.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CheckBox_SpecialCrane.Location = new System.Drawing.Point(23, 185);
            this.CheckBox_SpecialCrane.Name = "CheckBox_SpecialCrane";
            this.CheckBox_SpecialCrane.Size = new System.Drawing.Size(577, 31);
            this.CheckBox_SpecialCrane.TabIndex = 41;
            this.CheckBox_SpecialCrane.Text = "使用特殊車樣，僅放置在外掛側掛架上，內側掛架維持零片";
            this.CheckBox_SpecialCrane.UseVisualStyleBackColor = true;
            // 
            // Btn_AutoEnter
            // 
            this.Btn_AutoEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_AutoEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_AutoEnter.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_AutoEnter.Location = new System.Drawing.Point(17, 222);
            this.Btn_AutoEnter.Name = "Btn_AutoEnter";
            this.Btn_AutoEnter.Size = new System.Drawing.Size(624, 72);
            this.Btn_AutoEnter.TabIndex = 8;
            this.Btn_AutoEnter.Text = "確認";
            this.Btn_AutoEnter.UseVisualStyleBackColor = false;
            this.Btn_AutoEnter.Click += new System.EventHandler(this.Btn_AutoEnter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(17, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 34);
            this.label8.TabIndex = 33;
            this.label8.Text = "Lot No";
            // 
            // TextBox_LotNo
            // 
            this.TextBox_LotNo.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_LotNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TextBox_LotNo.Location = new System.Drawing.Point(23, 70);
            this.TextBox_LotNo.Name = "TextBox_LotNo";
            this.TextBox_LotNo.Size = new System.Drawing.Size(618, 43);
            this.TextBox_LotNo.TabIndex = 34;
            // 
            // NumUpDown_TotalQuantity
            // 
            this.NumUpDown_TotalQuantity.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NumUpDown_TotalQuantity.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumUpDown_TotalQuantity.Location = new System.Drawing.Point(122, 132);
            this.NumUpDown_TotalQuantity.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.NumUpDown_TotalQuantity.Name = "NumUpDown_TotalQuantity";
            this.NumUpDown_TotalQuantity.Size = new System.Drawing.Size(183, 43);
            this.NumUpDown_TotalQuantity.TabIndex = 6;
            this.NumUpDown_TotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label27.Location = new System.Drawing.Point(21, 136);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 34);
            this.label27.TabIndex = 5;
            this.label27.Text = "總片數";
            // 
            // Label_ShowMod
            // 
            this.Label_ShowMod.AutoSize = true;
            this.Label_ShowMod.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_ShowMod.Location = new System.Drawing.Point(287, 0);
            this.Label_ShowMod.Name = "Label_ShowMod";
            this.Label_ShowMod.Size = new System.Drawing.Size(81, 30);
            this.Label_ShowMod.TabIndex = 45;
            this.Label_ShowMod.Text = "label1";
            // 
            // AutoSetRecipePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 337);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AutoSetRecipePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_CarQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TotalQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown NumUpDown_TotalQuantity;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBox_LotNo;
        private System.Windows.Forms.Button Btn_AutoEnter;
        private System.Windows.Forms.CheckBox CheckBox_SpecialCrane;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.NumericUpDown NumUpDown_CarQuantity;
        private System.Windows.Forms.Label Label_CarQuantity;
        private System.Windows.Forms.CheckBox CheckBox_RockOnly;
        private System.Windows.Forms.Label Label_ShowMod;
    }
}