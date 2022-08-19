
namespace View.Load
{
    partial class CommunicationLogForm
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
            this.TextBox_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox_Log
            // 
            this.TextBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Log.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_Log.Location = new System.Drawing.Point(0, 0);
            this.TextBox_Log.Multiline = true;
            this.TextBox_Log.Name = "TextBox_Log";
            this.TextBox_Log.ReadOnly = true;
            this.TextBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox_Log.Size = new System.Drawing.Size(623, 750);
            this.TextBox_Log.TabIndex = 0;
            // 
            // CommunicationLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 750);
            this.Controls.Add(this.TextBox_Log);
            this.MaximumSize = new System.Drawing.Size(639, 789);
            this.MinimumSize = new System.Drawing.Size(639, 789);
            this.Name = "CommunicationLogForm";
            this.Text = "Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Log;
    }
}