
namespace View.Setting
{
    partial class EditUserPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_PW = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Action = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox_PWAgin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_AccessSetting = new System.Windows.Forms.Button();
            this.Btn_UseCustom = new System.Windows.Forms.Button();
            this.Btn_EditREcipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "無塵衣標號";
            // 
            // TextBox_ID
            // 
            this.TextBox_ID.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_ID.Location = new System.Drawing.Point(18, 45);
            this.TextBox_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_ID.Name = "TextBox_ID";
            this.TextBox_ID.Size = new System.Drawing.Size(444, 40);
            this.TextBox_ID.TabIndex = 0;
            this.TextBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(75, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "編輯配方";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(300, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "單機模式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(75, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "設定訪問";
            // 
            // TextBox_PW
            // 
            this.TextBox_PW.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_PW.Location = new System.Drawing.Point(18, 131);
            this.TextBox_PW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_PW.Name = "TextBox_PW";
            this.TextBox_PW.Size = new System.Drawing.Size(444, 40);
            this.TextBox_PW.TabIndex = 1;
            this.TextBox_PW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "密碼";
            // 
            // Btn_Action
            // 
            this.Btn_Action.BackColor = System.Drawing.Color.PaleGreen;
            this.Btn_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Action.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Action.Location = new System.Drawing.Point(8, 387);
            this.Btn_Action.Name = "Btn_Action";
            this.Btn_Action.Size = new System.Drawing.Size(223, 50);
            this.Btn_Action.TabIndex = 6;
            this.Btn_Action.Text = "新增";
            this.Btn_Action.UseVisualStyleBackColor = false;
            this.Btn_Action.Click += new System.EventHandler(this.Btn_Insert_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.BackColor = System.Drawing.Color.LightCoral;
            this.Btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Delete.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Delete.Location = new System.Drawing.Point(237, 387);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(223, 50);
            this.Btn_Delete.TabIndex = 7;
            this.Btn_Delete.Text = "取消";
            this.Btn_Delete.UseVisualStyleBackColor = false;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(10, -508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 34);
            this.label6.TabIndex = 15;
            this.label6.Text = "設定訪問";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBox_PWAgin
            // 
            this.TextBox_PWAgin.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_PWAgin.Location = new System.Drawing.Point(18, 211);
            this.TextBox_PWAgin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_PWAgin.Name = "TextBox_PWAgin";
            this.TextBox_PWAgin.Size = new System.Drawing.Size(444, 40);
            this.TextBox_PWAgin.TabIndex = 2;
            this.TextBox_PWAgin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(7, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 27);
            this.label7.TabIndex = 18;
            this.label7.Text = "再次輸入密碼";
            // 
            // Btn_AccessSetting
            // 
            this.Btn_AccessSetting.BackgroundImage = global::View.Properties.Resources.iconfinder_sign_check_299110;
            this.Btn_AccessSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_AccessSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_AccessSetting.Location = new System.Drawing.Point(12, 319);
            this.Btn_AccessSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_AccessSetting.Name = "Btn_AccessSetting";
            this.Btn_AccessSetting.Size = new System.Drawing.Size(46, 41);
            this.Btn_AccessSetting.TabIndex = 5;
            this.Btn_AccessSetting.UseVisualStyleBackColor = true;
            this.Btn_AccessSetting.Click += new System.EventHandler(this.Btn_AccessSetting_Click);
            // 
            // Btn_UseCustom
            // 
            this.Btn_UseCustom.BackgroundImage = global::View.Properties.Resources.iconfinder_sign_check_299110;
            this.Btn_UseCustom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_UseCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_UseCustom.Location = new System.Drawing.Point(237, 265);
            this.Btn_UseCustom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_UseCustom.Name = "Btn_UseCustom";
            this.Btn_UseCustom.Size = new System.Drawing.Size(46, 41);
            this.Btn_UseCustom.TabIndex = 4;
            this.Btn_UseCustom.UseVisualStyleBackColor = true;
            this.Btn_UseCustom.Click += new System.EventHandler(this.Btn_UseCustom_Click);
            // 
            // Btn_EditREcipe
            // 
            this.Btn_EditREcipe.BackgroundImage = global::View.Properties.Resources.iconfinder_sign_check_299110;
            this.Btn_EditREcipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_EditREcipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_EditREcipe.Location = new System.Drawing.Point(12, 265);
            this.Btn_EditREcipe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_EditREcipe.Name = "Btn_EditREcipe";
            this.Btn_EditREcipe.Size = new System.Drawing.Size(46, 41);
            this.Btn_EditREcipe.TabIndex = 3;
            this.Btn_EditREcipe.UseVisualStyleBackColor = true;
            this.Btn_EditREcipe.Click += new System.EventHandler(this.Btn_EditREcipe_Click);
            // 
            // EditUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(468, 446);
            this.Controls.Add(this.TextBox_PWAgin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Btn_Action);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBox_PW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_AccessSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_UseCustom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_EditREcipe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_ID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(484, 485);
            this.MinimumSize = new System.Drawing.Size(484, 485);
            this.Name = "EditUserPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_EditREcipe;
        private System.Windows.Forms.Button Btn_UseCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_AccessSetting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_PW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Action;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_PWAgin;
        private System.Windows.Forms.Label label7;
    }
}