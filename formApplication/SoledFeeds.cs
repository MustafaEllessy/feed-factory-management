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
    public partial class SoledFeeds : Form
    {
        public SoledFeeds()
        {
            InitializeComponent();
        }
        private void SoledFeeds_Load(object sender, EventArgs e)
        {
            loadFeedStore();
        }
        private void loadFeedStore()
        {
            dtFeedStore = DB.Data("select * from feedStore");


            for (int i = 0; i < dtFeedStore.Rows.Count; i++)
            {
                DataRow dr = dtFeedStore.Rows[i];
                string lastUpdate = dr[1].ToString();
                string feedName = dr[2].ToString();
                decimal quantity = Convert.ToDecimal(dr[3].ToString());
                string Unit = dr[4].ToString();
                //string price = dr[5].ToString();
                // if (Unit == "جرام")fdeg  
                //  {
                decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                dgvFeedStore.Rows.Add(new object[] { i + 1, feedName,unitsValues[1], unitsValues[2] });
                dgvSellFeeds.Rows.Add(new object[] { i + 1, feedName, 0, 0 });
                // }
            }
        }
        List<int> rowIndex = new List<int>();
        DataTable dtFeedStore;
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();


   
        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }

        private void dgvExportedFeeds_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIndex = ((DataGridView)sender).CurrentCell.ColumnIndex;
            if (colIndex == 3) return;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
            }

        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvExportedFeeds_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            int takenValue =  (Convert.ToInt32(dgvSellFeeds.Rows[e.RowIndex].Cells[2].Value.ToString()) * 1000) + (Convert.ToInt32(dgvSellFeeds.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000000);
            if (takenValue > 0)
            {
                int storedValue = takenValue  + (Convert.ToInt32(dgvFeedStore.Rows[e.RowIndex].Cells[2].Value) * 1000) + (Convert.ToInt32(dgvFeedStore.Rows[e.RowIndex].Cells[3].Value) * 1000000);
                decimal[] storedValueParts = convertFromGramToTonAndKiloAndGram(storedValue);
                dgvFeedStore.Rows[e.RowIndex].Cells[2].Value = storedValueParts[1];
                dgvFeedStore.Rows[e.RowIndex].Cells[3].Value = storedValueParts[2];
            }
        }

        private void dgvExportedFeeds_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int storeValue = (Convert.ToInt32(dgvFeedStore.Rows[e.RowIndex].Cells[2].Value.ToString()) * 1000) + (Convert.ToInt32(dgvFeedStore.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000000);
                int takenValue = (Convert.ToInt32(dgvSellFeeds.Rows[e.RowIndex].Cells[2].Value.ToString()) * 1000) + (Convert.ToInt32(dgvSellFeeds.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000000);
                if (takenValue < 0)
                {
                    dgvSellFeeds.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
                if (takenValue > storeValue)
                {
                    MessageBox.Show("لا يوجد رصيد بالمخزن");
                    dgvSellFeeds.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
                else
                {
                    int storeGrams = storeValue - takenValue;
                    decimal[] storeValueParts = convertFromGramToTonAndKiloAndGram(storeGrams);
                    dgvFeedStore.Rows[e.RowIndex].Cells[2].Value = storeValueParts[1];
                    dgvFeedStore.Rows[e.RowIndex].Cells[3].Value = storeValueParts[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex.Add(e.RowIndex);
        }

        private void dgvExportedFeeds_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
            }
        }
        public void addSoledFeed(DataGridViewRow dr)
        {
            string sellDate = dtSellDate.Value.ToString("dd/MM/yyyy");
            string feedName = dr.Cells[1].Value.ToString();
            string seller=txtSeller.Text; 
            string kiloQ = dr.Cells[2].Value.ToString();
            string tonnQ = dr.Cells[3].Value.ToString();
            decimal gram = 0;
            if ( (kiloQ == null || (kiloQ == "") || (kiloQ == "0")) &&
                (tonnQ == null || (tonnQ == "") || (tonnQ == "0")))
                return;
           
            if (kiloQ != null && kiloQ != "" && kiloQ != "0")
            {
                gram += (Convert.ToDecimal(kiloQ) * 1000);
            }
            if (tonnQ != null && tonnQ != "" && tonnQ != "0")
            {
                gram += (Convert.ToDecimal(tonnQ) * 1000000);
            }

            object[] rawData = new object[] { sellDate,seller, feedName, gram, "جرام"};
            DB.insertToDB("soledFeeds", new string[] { "sellDate","seller", "feedName", "quantity", "unit"}, rawData);
        }
        public void updateFeedStore(DataGridViewRow dr)
        {
            string exportDate = dtSellDate.Value.ToString("dd/MM/yyyy");
            string feedName = dr.Cells[1].Value.ToString();
            string kiloQ = dr.Cells[2].Value.ToString();
            string tonnQ = dr.Cells[3].Value.ToString();
            decimal gram = 0;
          
            if (kiloQ != null && kiloQ != "" && kiloQ != "0")
            {
                gram += (Convert.ToDecimal(kiloQ) * 1000);
            }
            if (tonnQ != null && tonnQ != "" && tonnQ != "0")
            {
                gram += (Convert.ToDecimal(tonnQ) * 1000000);
            }
            DB.affectBuild("update feedStore set lastUpdate='" + exportDate + "', quantity=" + gram + " ,unit='جرام' " + "where producedFeed='" + feedName + "';");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                List<int> row = rowIndex.Distinct().ToList();
                for (int i = 0; i < row.Count; i++)
                {
                    DataGridViewRow dr = dgvSellFeeds.Rows[row[i]];
                    DataGridViewRow dr2 = dgvFeedStore.Rows[row[i]];
                    addSoledFeed(dr);
                    updateFeedStore(dr2);
                }

                if (row.Count == 0)
                {
                    MessageBox.Show("لم يتم ادخال بيانات");
                    return;
                }
                MessageBox.Show("تم الحفظ");
                Close();
                /* for (int i = 0; i < row.Count; i++)
                {
                    dgvSellFeeds.Rows[row[i]].Cells[2].Value = 0;
                    dgvSellFeeds.Rows[row[i]].Cells[3].Value = 0;
                    dgvSellFeeds.Rows[row[i]].Cells[4].Value = 0;
                }
                row.Clear();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد مشكلة كالاًتى: " + ex.Message);
            }
        }
        bool firstLoad = true;
        private void ExportFeeds_Resize(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                formApplication.ResizeForm.initialFormHeight = 757;
                formApplication.ResizeForm.initialFormWidth = 1303;
                formApplication.ResizeForm.setContolDetails(this, controlsDetails);
                formApplication.ResizeForm.setControlResult(controlsDetails, controlsResult);
                firstLoad = false;
            }
            ResizeForm.changeControls(this, controlsResult);
        }
    }
}
