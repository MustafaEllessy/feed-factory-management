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
    public partial class DisplayExportFeeds : Form
    {
        public DisplayExportFeeds()
        {
            InitializeComponent();
        }
        DataTable dtExportedFeed;
        private void frmExportedFeedDisplay_Load(object sender, EventArgs e)
        {
            dtExportedFeed = DB.Data("select * from exportedFeed");
            dgvExportedFeeds.DataSource = dtExportedFeed;
            dgvExportedFeeds.Columns["ID"].Visible = false;
            dgvExportedFeeds.Columns["unit"].Visible = false;
            dgvExportedFeeds.Columns["quantity"].Visible = false;
            for (int i = 0; i < dgvExportedFeeds.Rows.Count; i++)
            {
                dgvExportedFeeds.Rows[i].Cells["colQuantity"].Value = Convert.ToDecimal(Convert.ToDecimal(dtExportedFeed.Rows[i][3].ToString()) / 1000000);
                dgvExportedFeeds.Rows[i].Cells["colUnit"].Value = "طن";
            }
            dgvExportedFeeds.Columns["colExportDate"].DisplayIndex = 0;
            dgvExportedFeeds.Columns["colStationName"].DisplayIndex = 1;
            dgvExportedFeeds.Columns["colStationType"].DisplayIndex = 2;
            dgvExportedFeeds.Columns["colFeedName"].DisplayIndex = 3;
            dgvExportedFeeds.Columns["colUnit"].DisplayIndex = 4;
            dgvExportedFeeds.Columns["colQuantity"].DisplayIndex = 5;
            dgvExportedFeeds.ClearSelection();
         //   dgvExportedFeeds.Sort(dgvExportedFeeds.Columns["colExportDate"], ListSortDirection.Ascending);
        }
    }
}
