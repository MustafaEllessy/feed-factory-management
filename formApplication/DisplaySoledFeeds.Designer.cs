namespace formApplication
{
    partial class DisplaySoledFeeds
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSoledFeeds = new System.Windows.Forms.DataGridView();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoledFeeds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSoledFeeds
            // 
            this.dgvSoledFeeds.AllowUserToAddRows = false;
            this.dgvSoledFeeds.AllowUserToDeleteRows = false;
            this.dgvSoledFeeds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoledFeeds.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoledFeeds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoledFeeds.ColumnHeadersHeight = 50;
            this.dgvSoledFeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSoledFeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSaleDate,
            this.dataGridViewTextBoxColumn2,
            this.colKilo,
            this.colTon,
            this.colSeller});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoledFeeds.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSoledFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSoledFeeds.EnableHeadersVisualStyles = false;
            this.dgvSoledFeeds.Location = new System.Drawing.Point(0, 0);
            this.dgvSoledFeeds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSoledFeeds.MultiSelect = false;
            this.dgvSoledFeeds.Name = "dgvSoledFeeds";
            this.dgvSoledFeeds.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoledFeeds.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSoledFeeds.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSoledFeeds.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSoledFeeds.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSoledFeeds.RowTemplate.Height = 60;
            this.dgvSoledFeeds.Size = new System.Drawing.Size(1285, 674);
            this.dgvSoledFeeds.TabIndex = 18;
            // 
            // colSaleDate
            // 
            this.colSaleDate.DataPropertyName = "sellDate";
            dataGridViewCellStyle2.Format = "D";
            this.colSaleDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSaleDate.HeaderText = "تاريخ البيع";
            this.colSaleDate.MinimumWidth = 6;
            this.colSaleDate.Name = "colSaleDate";
            this.colSaleDate.ReadOnly = true;
            this.colSaleDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "feedName";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "اسم الصنف";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colKilo
            // 
            this.colKilo.HeaderText = "كيلو";
            this.colKilo.MinimumWidth = 6;
            this.colKilo.Name = "colKilo";
            this.colKilo.ReadOnly = true;
            this.colKilo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKilo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTon
            // 
            this.colTon.HeaderText = "طــن";
            this.colTon.MinimumWidth = 6;
            this.colTon.Name = "colTon";
            this.colTon.ReadOnly = true;
            this.colTon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSeller
            // 
            this.colSeller.DataPropertyName = "seller";
            this.colSeller.HeaderText = "البائع";
            this.colSeller.MinimumWidth = 6;
            this.colSeller.Name = "colSeller";
            this.colSeller.ReadOnly = true;
            // 
            // DisplaySoledFeeds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1285, 674);
            this.Controls.Add(this.dgvSoledFeeds);
            this.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DisplaySoledFeeds";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض الأعلاف المباعة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DisplaySoledFeeds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoledFeeds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSoledFeeds;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeller;
    }
}