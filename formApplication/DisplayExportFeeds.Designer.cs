namespace formApplication
{
    partial class DisplayExportFeeds
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
            this.dgvExportedFeeds = new System.Windows.Forms.DataGridView();
            this.colExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportedFeeds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExportedFeeds
            // 
            this.dgvExportedFeeds.AllowUserToAddRows = false;
            this.dgvExportedFeeds.AllowUserToDeleteRows = false;
            this.dgvExportedFeeds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExportedFeeds.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExportedFeeds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExportedFeeds.ColumnHeadersHeight = 50;
            this.dgvExportedFeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExportedFeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExportDate,
            this.colStationName,
            this.colStationType,
            this.colFeedName,
            this.colUnit,
            this.colQuantity});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExportedFeeds.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExportedFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExportedFeeds.EnableHeadersVisualStyles = false;
            this.dgvExportedFeeds.Location = new System.Drawing.Point(0, 0);
            this.dgvExportedFeeds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvExportedFeeds.MultiSelect = false;
            this.dgvExportedFeeds.Name = "dgvExportedFeeds";
            this.dgvExportedFeeds.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExportedFeeds.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExportedFeeds.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExportedFeeds.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExportedFeeds.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvExportedFeeds.RowTemplate.Height = 60;
            this.dgvExportedFeeds.Size = new System.Drawing.Size(1285, 674);
            this.dgvExportedFeeds.TabIndex = 7;
            // 
            // colExportDate
            // 
            this.colExportDate.DataPropertyName = "exportDate";
            dataGridViewCellStyle2.Format = "D";
            this.colExportDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colExportDate.HeaderText = "تاريخ التصدير";
            this.colExportDate.MinimumWidth = 6;
            this.colExportDate.Name = "colExportDate";
            this.colExportDate.ReadOnly = true;
            this.colExportDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExportDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStationName
            // 
            this.colStationName.DataPropertyName = "stationName";
            this.colStationName.FillWeight = 90F;
            this.colStationName.HeaderText = "اسم المحطة";
            this.colStationName.MinimumWidth = 6;
            this.colStationName.Name = "colStationName";
            this.colStationName.ReadOnly = true;
            this.colStationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStationType
            // 
            this.colStationType.DataPropertyName = "stationType";
            this.colStationType.FillWeight = 90F;
            this.colStationType.HeaderText = "نوع المحطة";
            this.colStationType.MinimumWidth = 6;
            this.colStationType.Name = "colStationType";
            this.colStationType.ReadOnly = true;
            this.colStationType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStationType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFeedName
            // 
            this.colFeedName.DataPropertyName = "producedFeed";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFeedName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFeedName.FillWeight = 90F;
            this.colFeedName.HeaderText = "اسم الصنف";
            this.colFeedName.MinimumWidth = 6;
            this.colFeedName.Name = "colFeedName";
            this.colFeedName.ReadOnly = true;
            this.colFeedName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeedName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUnit
            // 
            this.colUnit.FillWeight = 90F;
            this.colUnit.HeaderText = "الوحدة";
            this.colUnit.MinimumWidth = 6;
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQuantity
            // 
            this.colQuantity.FillWeight = 90F;
            this.colQuantity.HeaderText = "الكمية";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DisplayExportFeeds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 674);
            this.Controls.Add(this.dgvExportedFeeds);
            this.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DisplayExportFeeds";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "عرض صادرات الأعلاف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExportedFeedDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportedFeeds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExportedFeeds;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
    }
}