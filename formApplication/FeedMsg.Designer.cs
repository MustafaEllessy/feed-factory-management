namespace formApplication
{
    partial class FeedMsg
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
            this.lblSuccessTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSuccessTitle
            // 
            this.lblSuccessTitle.AutoSize = true;
            this.lblSuccessTitle.Font = new System.Drawing.Font("Times New Roman", 58F);
            this.lblSuccessTitle.ForeColor = System.Drawing.Color.White;
            this.lblSuccessTitle.Location = new System.Drawing.Point(70, 248);
            this.lblSuccessTitle.Name = "lblSuccessTitle";
            this.lblSuccessTitle.Size = new System.Drawing.Size(1193, 110);
            this.lblSuccessTitle.TabIndex = 0;
            this.lblSuccessTitle.Text = "تم عمل المنتج بنجاح بالكميات المعطاة";
            // 
            // FeedMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(1285, 674);
            this.Controls.Add(this.lblSuccessTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "FeedMsg";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نجاح إنتاج العلف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFeedProducedSuccessfully_Load);
            this.Resize += new System.EventHandler(this.FeedMsg_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSuccessTitle;
    }
}