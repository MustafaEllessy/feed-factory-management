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
    public partial class FeedStore : Form
    {
        public FeedStore()
        {
            InitializeComponent();
        }
        DataTable dtFeedStore;
        private void frmFeedStore_Load(object sender, EventArgs e)
        {
            loadFeedStore();
            dgvFeedStore.ClearSelection();
        }

        private void loadFeedStore()
        {
            dtFeedStore = DB.Data("select * from feedStore");


            for (int i = 0; i < dtFeedStore.Rows.Count; i++)
            {
                DataRow dr = dtFeedStore.Rows[i];
                string lastUpdate = ((DateTime)dr[1]).ToString("yyyy/MM/dd");
                string feedName = dr[2].ToString();
                decimal quantity = Convert.ToDecimal(dr[3].ToString());
                string Unit = dr[4].ToString();
                // if (Unit == "جرام")
                //  {
                decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                dgvFeedStore.Rows.Add(new object[] { i + 1, lastUpdate, feedName,  unitsValues[0], unitsValues[1], unitsValues[2] });
                // }
            }
        }
        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }







    }
}
