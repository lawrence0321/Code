
namespace View.ExForm
{
    partial class MessagePage
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
            this.label_TitleTxt = new System.Windows.Forms.Label();
            this.TextBox_MessageTxt = new System.Windows.Forms.TextBox();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TitleTxt
            // 
            this.label_TitleTxt.AutoSize = true;
            this.label_TitleTxt.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_TitleTxt.Location = new System.Drawing.Point(12, 9);
            this.label_TitleTxt.Name = "label_TitleTxt";
            this.label_TitleTxt.Size = new System.Drawing.Size(127, 40);
            this.label_TitleTxt.TabIndex = 0;
            this.label_TitleTxt.Text = "TitleTxt";
            // 
            // TextBox_MessageTxt
            // 
            this.TextBox_MessageTxt.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_MessageTxt.Location = new System.Drawing.Point(18, 65);
            this.TextBox_MessageTxt.Multiline = true;
            this.TextBox_MessageTxt.Name = "TextBox_MessageTxt";
            this.TextBox_MessageTxt.ReadOnly = true;
            this.TextBox_MessageTxt.Size = new System.Drawing.Size(884, 226);
            this.TextBox_MessageTxt.TabIndex = 1;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Close.BackgroundImage = global::View.Properties.Resources.Cancel_48;
            this.Btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Close.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Location = new System.Drawing.Point(842, -1);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(60, 60);
            this.Btn_Close.TabIndex = 2;
            this.Btn_Close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Close.UseVisualStyleBackColor = false;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // MessagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 303);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.TextBox_MessageTxt);
            this.Controls.Add(this.label_TitleTxt);
            this.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Name = "MessagePage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TitleTxt;
        private System.Windows.Forms.TextBox TextBox_MessageTxt;
        private System.Windows.Forms.Button Btn_Close;
    }
}