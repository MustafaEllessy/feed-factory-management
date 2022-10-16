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
    public partial class DisplaySoledFeeds : Form
    {
        public DisplaySoledFeeds()
        {
            InitializeComponent();
        }

        private void DisplaySoledFeeds_Load(object sender, EventArgs e)
        {
            try
            {
                dtSoledFeeds = DB.Data("select * from soledFeeds");
                dgvSoledFeeds.DataSource = dtSoledFeeds;
                dgvSoledFeeds.Columns["ID"].Visible = false;
                dgvSoledFeeds.Columns["quantity"].Visible = false;
                dgvSoledFeeds.Columns["unit"].Visible = false;

                for (int i = 0; i < dtSoledFeeds.Rows.Count; i++)
                {
                    decimal gram = Convert.ToDecimal(dtSoledFeeds.Rows[i][4].ToString());
                    decimal[] unitParts = convertFromGramToTonAndKiloAndGram(gram);
                    dgvSoledFeeds.Rows[i].Cells["colKilo"].Value = unitParts[1];
                    dgvSoledFeeds.Rows[i].Cells["colTon"].Value = unitParts[2];
                }
                dgvSoledFeeds.ClearSelection();
        //        dgvSoledFeeds.Sort(dgvSoledFeeds.Columns["colSaleDate"], ListSortDirection.Ascending);

            }

            catch (Exception ex)
            {
                MessageBox.Show("لم ينجح العرض");
                MessageBox.Show(ex.Message);
            }
        }
        DataTable dtSoledFeeds;
   
        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }

    }
}
