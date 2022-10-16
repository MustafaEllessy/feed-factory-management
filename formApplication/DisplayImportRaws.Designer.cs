namespace formApplication
{
    partial class DisplayImportRaws
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
            this.dgvImportedRaws = new System.Windows.Forms.DataGridView();
            this.colImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedRaws)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportedRaws
            // 
            this.dgvImportedRaws.AllowUserToAddRows = false;
            this.dgvImportedRaws.AllowUserToDeleteRows = false;
            this.dgvImportedRaws.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImportedRaws.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImportedRaws.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImportedRaws.ColumnHeadersHeight = 50;
            this.dgvImportedRaws.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvImportedRaws.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImportDate,
            this.dataGridViewTextBoxColumn2,
            this.colCompanyName,
            this.colGram,
            this.colKilo,
            this.colTon,
            this.colPrice});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImportedRaws.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvImportedRaws.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportedRaws.EnableHeadersVisualStyles = false;
            this.dgvImportedRaws.Location = new System.Drawing.Point(0, 0);
            this.dgvImportedRaws.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvImportedRaws.MultiSelect = false;
            this.dgvImportedRaws.Name = "dgvImportedRaws";
            this.dgvImportedRaws.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImportedRaws.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvImportedRaws.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvImportedRaws.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvImportedRaws.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvImportedRaws.RowTemplate.Height = 60;
            this.dgvImportedRaws.Size = new System.Drawing.Size(1285, 674);
            this.dgvImportedRaws.TabIndex = 17;
            // 
            // colImportDate
            // 
            this.colImportDate.DataPropertyName = "importDate";
            dataGridViewCellStyle2.Format = "D";
            this.colImportDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colImportDate.HeaderText = "تاريخ التوريد";
            this.colImportDate.MinimumWidth = 6;
            this.colImportDate.Name = "colImportDate";
            this.colImportDate.ReadOnly = true;
            this.colImportDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rawName";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "اسم الصنف";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCompanyName
            // 
            this.colCompanyName.DataPropertyName = "companyName";
            this.colCompanyName.HeaderText = "الشركة الموردة";
            this.colCompanyName.MinimumWidth = 6;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.ReadOnly = true;
            this.colCompanyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colGram
            // 
            this.colGram.HeaderText = "جرام";
            this.colGram.MinimumWidth = 6;
            this.colGram.Name = "colGram";
            this.colGram.ReadOnly = true;
            this.colGram.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // colPrice
            // 
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "سعر (الطن)";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // DisplayImportRaws
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 674);
            this.Controls.Add(this.dgvImportedRaws);
            this.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DisplayImportRaws";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "واردات الخامات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRawImportsDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedRaws)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImportedRaws;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}