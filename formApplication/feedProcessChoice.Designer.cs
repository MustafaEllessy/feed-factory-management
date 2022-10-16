namespace formApplication
{
    partial class feedProcessChoice
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
            this.btnMakeMixture = new System.Windows.Forms.Button();
            this.btnChooseMixture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMakeMixture
            // 
            this.btnMakeMixture.Enabled = false;
            this.btnMakeMixture.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold);
            this.btnMakeMixture.Location = new System.Drawing.Point(734, 233);
            this.btnMakeMixture.Margin = new System.Windows.Forms.Padding(6);
            this.btnMakeMixture.Name = "btnMakeMixture";
            this.btnMakeMixture.Size = new System.Drawing.Size(339, 176);
            this.btnMakeMixture.TabIndex = 0;
            this.btnMakeMixture.Text = "تصنيع خلطة";
            this.btnMakeMixture.UseVisualStyleBackColor = true;
            this.btnMakeMixture.Click += new System.EventHandler(this.btnMakeMixture_Click);
            // 
            // btnChooseMixture
            // 
            this.btnChooseMixture.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseMixture.Location = new System.Drawing.Point(268, 233);
            this.btnChooseMixture.Margin = new System.Windows.Forms.Padding(6);
            this.btnChooseMixture.Name = "btnChooseMixture";
            this.btnChooseMixture.Size = new System.Drawing.Size(339, 176);
            this.btnChooseMixture.TabIndex = 0;
            this.btnChooseMixture.Text = "اختيار خلطة";
            this.btnChooseMixture.UseVisualStyleBackColor = true;
            this.btnChooseMixture.Click += new System.EventHandler(this.btnChooseMixture_Click);
            // 
            // feedProcessChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1285, 674);
            this.Controls.Add(this.btnChooseMixture);
            this.Controls.Add(this.btnMakeMixture);
            this.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "feedProcessChoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تصنيع الأعلاف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.feedProcessChoice_Load);
            this.Resize += new System.EventHandler(this.feedProcessChoice_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMakeMixture;
        private System.Windows.Forms.Button btnChooseMixture;
    }
}