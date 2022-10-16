using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formApplication
{
    public partial class DisplayImportRaws : Form
    {
        DataTable dtImportedRaws;
        public DisplayImportRaws()
        {
            InitializeComponent();
        }

        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }

        private void frmRawImportsDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                dtImportedRaws = DB.Data("select * from importedRaws");              
                dgvImportedRaws.DataSource = dtImportedRaws;
                dgvImportedRaws.Columns["ID"].Visible = false;
                dgvImportedRaws.Columns["quantity"].Visible = false;
                dgvImportedRaws.Columns["unit"].Visible = false;

                for (int i = 0; i < dtImportedRaws.Rows.Count; i++)
                {  
                    decimal gram = Convert.ToDecimal(dtImportedRaws.Rows[i][3].ToString());
                    decimal[] unitParts = convertFromGramToTonAndKiloAndGram(gram);
                    dgvImportedRaws.Rows[i].Cells["colGram"].Value = unitParts[0];
                    dgvImportedRaws.Rows[i].Cells["colKilo"].Value = unitParts[1];
                    dgvImportedRaws.Rows[i].Cells["colTon"].Value = unitParts[2];
                }
                dgvImportedRaws.ClearSelection();
               // dgvImportedRaws.Sort(dgvImportedRaws.Columns["colImportDate"], ListSortDirection.Ascending);
            }

            catch (Exception ex)                                                                                                                                    
            {
                MessageBox.Show("لم ينجح العرض");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
