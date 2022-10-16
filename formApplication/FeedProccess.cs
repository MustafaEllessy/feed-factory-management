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
    public partial class FeedProccess : Form
    {
        public static  List< DataGridViewRow> feedFactoryUpdateRows = new List<DataGridViewRow>();
        public static List<DataGridViewRow> feedFactoryInsertRows = new List<DataGridViewRow>();

        public FeedProccess()
        {
            InitializeComponent();
        }

        static public string produceDate = "";
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        DataTable dtFeedMixtures;
        private void frmFeedFactory_Load(object sender, EventArgs e)
        {
            DB.open();
            loadRawStore();
            if(feedProcessChoice.feedReady)
            {
                pnlReadyFeed.Visible = true;
              //  updateMixtures();
            }
         else if (!feedProcessChoice.feedReady)
            {
                pnlReadyFeed.Visible = false;
            }
            string cmd1 = "select ID,producedFeed from feedStore";
            dtFeedMixtures = DB.Data( cmd1);
            cbxMixName.DataSource = dtFeedMixtures;
             cbxMixName.DisplayMember = "producedFeed";
            cbxMixName.ValueMember = "ID";
            cbxMixName.SelectedIndex = -1;
            formLoaded = true;
        }
        DataTable mixtureInfo;
        private void updateMixtures()
        {
            DataTable dt = DB.Data("select * from mixturesName");
            cbxMixName.DataSource = dt;
            cbxMixName.DisplayMember = "feedName";
     
        }

        DataTable dtRawStore;
        List<int> rowIndex1 = new List<int>();
        List<int> rowIndex2 = new List<int>();
        List<int> rowIndex3 = new List<int>();
        public bool nextOnce = false;
        public bool prevOnce = false;
        private void loadRawStore()
        {
            dtRawStore = DB.Data("select * from rawsStore");
            if(dtRawStore.Rows.Count==1)
            {
                DataRow dr = dtRawStore.Rows[0];
                string rawName = dr[2].ToString();
                decimal quantity = Convert.ToDecimal(dr[3].ToString());
                string Unit = dr[4].ToString();
                //    if (Unit == "جرام")
                //    {
                decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                dgvStore1.Rows.Add(new object[] { 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                dgvRaw1.Rows.Add(new object[] {  1, rawName, 0, 0, 0 });
            }
            if (dtRawStore.Rows.Count > 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
                    //    if (Unit == "جرام")
                    //    {
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                    dgvStore1.Rows.Add(new object[] { i + 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                    dgvRaw1.Rows.Add(new object[] { i + 1, rawName, 0, 0, 0 });
                    //   }
                }
                for (int i = 9; i < 18; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[ 4].ToString();
                    // if (Unit == "جرام")
                    //  {
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                    dgvStore2.Rows.Add(new object[] { i + 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                    dgvRaw2.Rows.Add(new object[] { i + 1, rawName, 0, 0, 0 });
                    //   }
                }
                for (int i = 18; i < dtRawStore.Rows.Count; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
                    //  if (Unit == "جرام")
                    //{
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                    dgvStore3.Rows.Add(new object[] { i + 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                    dgvRaw3.Rows.Add(new object[] { i + 1, rawName, 0, 0, 0 });
                    // }
                }
                dgvStore1.ClearSelection();
                dgvStore2.ClearSelection();
                dgvStore3.ClearSelection();
                dgvRaw1.ClearSelection();
                dgvRaw2.ClearSelection();
                dgvRaw3.ClearSelection();
            }

        }
        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }
        private void btnPrev1_Click(object sender, EventArgs e)
        {

            if (dgvStore3.Visible)
            {
                dgvStore3.Visible = false;
                dgvStore2.Visible = true;
                dgvStore1.Visible = false;
            }
            else if (dgvStore2.Visible)
            {
                dgvStore3.Visible = false;
                dgvStore1.Visible = true;
                dgvStore2.Visible = false;
            }
            if (prevOnce)
            {
                prevOnce = false;
            }
            else
            {
                prevOnce = true;
                btnPrev2.PerformClick();
            }

        } 
        private void btnNext1_Click(object sender, EventArgs e)
        {

            if (dgvStore1.Visible)
            {
                dgvStore3.Visible = false;
                dgvStore2.Visible = true;
                dgvStore1.Visible = false;
            }
            else if (dgvStore2.Visible)
            {
                dgvStore1.Visible = false;
                dgvStore3.Visible = true;
                dgvStore2.Visible = false;
            }
            if (nextOnce)
            {
                nextOnce = false;
            }
            else
            {
                nextOnce = true;
                btnNext2.PerformClick();
            }
        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            if (dgvRaw1.Visible)
            {
                dgvRaw1.Visible = false;
                dgvRaw2.Visible = true;
                dgvRaw3.Visible = false;
            }
            else if (dgvRaw2.Visible)
            {
                dgvRaw1.Visible = false;
                dgvRaw3.Visible = true;
                dgvRaw2.Visible = false;
            }
            if (nextOnce)
            {
                nextOnce = false;
            }
            else
            {
                nextOnce = true;
                btnNext1.PerformClick();
            }

        }
        private void btnPrev2_Click(object sender, EventArgs e)
        {

            if (dgvRaw3.Visible)
            {
                dgvRaw1.Visible = false;
                dgvRaw2.Visible = true;
                dgvRaw3.Visible = false;
            }
            else if (dgvRaw2.Visible)
            {
                dgvRaw2.Visible = false;
                dgvRaw1.Visible = true;
                dgvRaw3.Visible = false;
            }
            if (prevOnce)
            {
                prevOnce = false;
            }
            else
            {
                prevOnce = true;
                btnPrev1.PerformClick();
            }
        }
        private void dgvImport2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
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
        private void dgvImport1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int takenValue = Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
            if (takenValue > 0)
            {
                int storedValue = takenValue + (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[2].Value) + (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[3].Value) * 1000) + (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[4].Value) * 1000000));
                decimal[] storedValueParts = convertFromGramToTonAndKiloAndGram(storedValue);
                dgvStore1.Rows[e.RowIndex].Cells[2].Value = storedValueParts[0];
                dgvStore1.Rows[e.RowIndex].Cells[3].Value = storedValueParts[1];
                dgvStore1.Rows[e.RowIndex].Cells[4].Value = storedValueParts[2];
            }
        }
        private void dgvImport1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int storeValue = Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[3].Value.ToString()) *1000)+(Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[4].Value.ToString())*1000000);
                int takenValue = Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw1.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
                if (takenValue < 0)
                {
                    dgvRaw1.Rows[e.RowIndex].Cells[1].Value = 0;
                    return;
                }
                if (takenValue > storeValue)
                {
                    MessageBox.Show("لا يوجد رصيد بالمخزن");
                    dgvRaw1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
                else
                {
                    int storeGrams = storeValue - takenValue;
                    decimal[] storeValueParts = convertFromGramToTonAndKiloAndGram(storeGrams);
                    dgvStore1.Rows[e.RowIndex].Cells[2].Value = storeValueParts[0];
                    dgvStore1.Rows[e.RowIndex].Cells[3].Value = storeValueParts[1];
                    dgvStore1.Rows[e.RowIndex].Cells[4].Value = storeValueParts[2];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex1.Add(e.RowIndex);
        }
        private void dgvImport2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int takenValue = Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
            if (takenValue > 0)
            {
                int storedValue = takenValue + (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[2].Value) + (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[3].Value) * 1000) + (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[4].Value) * 1000000));
                decimal[] storedValueParts = convertFromGramToTonAndKiloAndGram(storedValue);
                dgvStore2.Rows[e.RowIndex].Cells[2].Value = storedValueParts[0];
                dgvStore2.Rows[e.RowIndex].Cells[3].Value = storedValueParts[1];
                dgvStore2.Rows[e.RowIndex].Cells[4].Value = storedValueParts[2];
            }
        }
        private void dgvImport2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int storeValue = Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
                int takenValue = Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw2.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
                if (takenValue < 0)
                {
                    dgvRaw2.Rows[e.RowIndex].Cells[1].Value = 0;
                    return;
                }
                if (takenValue > storeValue)
                {
                    MessageBox.Show("لا يوجد رصيد بالمخزن");
                    dgvRaw2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
                else
                {
                    int storeGrams = storeValue - takenValue;
                    decimal[] storeValueParts = convertFromGramToTonAndKiloAndGram(storeGrams);
                    dgvStore2.Rows[e.RowIndex].Cells[2].Value = storeValueParts[0];
                    dgvStore2.Rows[e.RowIndex].Cells[3].Value = storeValueParts[1];
                    dgvStore2.Rows[e.RowIndex].Cells[4].Value = storeValueParts[2];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex2.Add(e.RowIndex);

        }
        private void dgvImport3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int takenValue = Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
            if (takenValue > 0)
            {
                int storedValue = takenValue + (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[2].Value) + (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[3].Value) * 1000) + (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[4].Value) * 1000000));
                decimal[] storedValueParts = convertFromGramToTonAndKiloAndGram(storedValue);
                dgvStore3.Rows[e.RowIndex].Cells[2].Value = storedValueParts[0];
                dgvStore3.Rows[e.RowIndex].Cells[3].Value = storedValueParts[1];
                dgvStore3.Rows[e.RowIndex].Cells[4].Value = storedValueParts[2];
            }
        }
        private void dgvImport3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int storeValue = Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
                int takenValue = Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[2].Value.ToString()) + (Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[3].Value.ToString()) * 1000) + (Convert.ToInt32(dgvRaw3.Rows[e.RowIndex].Cells[4].Value.ToString()) * 1000000);
                if (takenValue < 0)
                {
                    dgvRaw3.Rows[e.RowIndex].Cells[1].Value = 0;
                    return;
                }
                if (takenValue > storeValue)
                {
                    MessageBox.Show("لا يوجد رصيد بالمخزن");
                    dgvRaw3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
                else
                {
                    int storeGrams = storeValue - takenValue;
                    decimal[] storeValueParts = convertFromGramToTonAndKiloAndGram(storeGrams);
                    dgvStore3.Rows[e.RowIndex].Cells[2].Value = storeValueParts[0];
                    dgvStore3.Rows[e.RowIndex].Cells[3].Value = storeValueParts[1];
                    dgvStore3.Rows[e.RowIndex].Cells[4].Value = storeValueParts[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex3.Add(e.RowIndex);
        }
        public void addImportedRow(DataGridViewRow dr)
        {
            string rawName = dr.Cells[1].Value.ToString();
            string gramQ = dr.Cells[2].Value.ToString();
            string kiloQ = dr.Cells[3].Value.ToString();
            string tonnQ = dr.Cells[4].Value.ToString();
            decimal gram = 0;
         
            if (gramQ != null && gramQ != "" && gramQ != "0")
            {
                gram = Convert.ToDecimal(gramQ);
            }
            if (kiloQ != null && kiloQ != "" && kiloQ != "0")
            {
                gram += (Convert.ToDecimal(kiloQ) * 1000);
            }
            if (tonnQ != null && tonnQ != "" && tonnQ != "0")
            {
                gram += (Convert.ToDecimal(tonnQ) * 1000000);
            }

           
            object[] rawData = new object[] {  rawName, gram, "جرام", productID };
            DB.insertToDB("exportedRaws", new string[] {  "rawName", "quantity", "unit", "productID" }, rawData);
        }
        public void updateRawStore(DataGridViewRow dr)
        {
            string rawName = dr.Cells[1].Value.ToString();
            string gramQ = dr.Cells[2].Value.ToString();
            string kiloQ = dr.Cells[3].Value.ToString();
            string tonnQ = dr.Cells[4].Value.ToString();
            string rawdateTime = dtProduceTime.Value.ToString("yyyy/MM/dd");
            decimal gram = 0;
  
            if (gramQ != null && gramQ != "" && gramQ != "0")
            {
                gram = Convert.ToDecimal(gramQ);
            }
            if (kiloQ != null && kiloQ != "" && kiloQ != "0")
            {
                gram += (Convert.ToDecimal(kiloQ) * 1000);
            }
            if (tonnQ != null && tonnQ != "" && tonnQ != "0")
            {
                gram += (Convert.ToDecimal(tonnQ) * 1000000);
            }

            DB.affectBuild("update rawsStore set lastUpdate='" + DateTime.Now.ToString("yyyy/MM/dd") + "', quantity=" + gram + " ,unit='جرام' " + "where rawName='" + rawName + "';");
        }
        int productID = -1;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((rw1.Count + rw2.Count + rw3.Count) == 0)
                {
                    MessageBox.Show("لم يتم ادخال بيانات");
                    return;
                }

                produceDate = dtProduceTime.Value.ToString("dd/MM/yyyy");
                string producedFeed = cbxMixName.GetItemText(cbxMixName.SelectedItem);

                if (feedProcessChoice.feedReady)
                {
                    //add product first
                    DB.insertToDB("feedFactory", new string[] { "produceDate", "produceFeed", "quantity", "unit" }, new object[] { produceDate, producedFeed, 1000000, "جرام" });
                    //add raws
                    productID = Convert.ToInt32(DB.Data("select * from feedLastID").Rows[0][0].ToString());
                    for (int i = 0; i < rw1.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw1.Rows[rw1[i]];
                        DataGridViewRow dr2 = dgvStore1.Rows[rw1[i]];
                        updateRawStore(dr2);
                        addImportedRow(dr1);
                    }
                    for (int i = 0; i < rw2.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw2.Rows[rw2[i]];
                        DataGridViewRow dr2 = dgvStore2.Rows[rw2[i]];
                        updateRawStore(dr2);
                        addImportedRow(dr1);
                    }
                    for (int i = 0; i < rw3.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw3.Rows[rw3[i]];
                        DataGridViewRow dr2 = dgvStore3.Rows[rw3[i]];
                        updateRawStore(dr2);
                        addImportedRow(dr1);
                    }
                 
                    //add produced quantity to feed store
                    string feedNO = cbxMixName.SelectedValue.ToString();
                    decimal quint =Convert.ToDecimal( DB.Data("select quantity from feedStore where ID=" + feedNO).Rows[0][0].ToString());
                    quint += 1000000;
                    int qu = Convert.ToInt32(quint);
                    DB.affectBuild("update  feedStore set quantity=" + qu + " where ID=" + feedNO);
                    MessageBox.Show("تم تصنيع العلف بنجاح");
                    Close();
                }
                else
                   { 
               
                    List<int> row1 = rowIndex1.Distinct().ToList();
                    List<int> row2 = rowIndex2.Distinct().ToList();
                    List<int> row3 = rowIndex3.Distinct().ToList();
                    for (int i = 0; i < row1.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw1.Rows[row1[i]];
                        DataGridViewRow dr2 = dgvStore1.Rows[row1[i]];
                        feedFactoryInsertRows.Add(dr1);
                        feedFactoryUpdateRows.Add(dr2);
                    }
                    for (int i = 0; i < row2.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw2.Rows[row2[i]];
                        DataGridViewRow dr2 = dgvStore2.Rows[row2[i]];
                        feedFactoryInsertRows.Add(dr1);
                        feedFactoryUpdateRows.Add(dr2);
                    }

                    for (int i = 0; i < row3.Count; i++)
                    {
                        DataGridViewRow dr1 = dgvRaw3.Rows[row3[i]];
                        DataGridViewRow dr2 = dgvStore3.Rows[row3[i]];
                        feedFactoryInsertRows.Add(dr1);
                        feedFactoryUpdateRows.Add(dr2);
                    }
                    if ((row1.Count + row2.Count + row3.Count) == 0)
                    {
                        MessageBox.Show("لم يتم ادخال بيانات");
                        return;
                    }

                    DialogResult dr = MessageBox.Show("تابع");
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        ProducedFeed frm = new ProducedFeed();
                        frm.ShowDialog();
                    }

                }
              

            }
              catch (Exception ex)
            {
                MessageBox.Show("يوجد مشكلة كالاًتى: " + ex.Message);
            }
        }

        private void dgvImport2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
            }
        }
        bool firstLoad = true;
        private void FeedProccess_Resize(object sender, EventArgs e)
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

        private void dgvRaw2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool formLoaded = false;
        List<int> rw1 = new List<int>();
        List<int> rw2 = new List<int>();
        List<int> rw3 = new List<int>();
        private void cbxMixName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxMixName.SelectedIndex != -1 && formLoaded)
            {
                /*
                mixtureInfo = DB.Data("select rawName,quantityPercent where feedName='"+cbxMixName.SelectedItem.ToString()+"'");
                bool rslt = rawsInstore();
                if(!rslt)
                {
                    MessageBox.Show("لا تتوفر الخامات اللازمة بالمخزن");
                    cbxMixName.SelectedIndex = -1;
                }
                else
                {
                    //continue later
                }
                */
                clearFromGrid();
           
                string feedNO = cbxMixName.SelectedValue.ToString();
                string cmd1 = "select rawNO, Quantity from feedMixtures where feedNO="+feedNO;
                DataTable dtMix = DB.Data(cmd1);
                string inCMDPart = "IN (";
                int rawsCounter = 0;
                foreach (DataRow dr in dtMix.Rows)
                {
                    string rawsNO = dr[0].ToString();
                    if (rawsCounter==dtMix.Rows.Count-1)
                    {
                        inCMDPart += rawsNO+" )";
                        continue;
                    }
                  
                    inCMDPart += rawsNO+" ,";
                    rawsCounter++;
                }
                string cmd2 = " SELECT rawsStore.rawName, feedMixtures.Quantity*1000, rawsStore.quantity FROM rawsStore INNER JOIN feedMixtures ON rawsStore.ID = feedMixtures.rawNO where feedMixtures.feedNO = " + feedNO;
                DataTable dtRawsInfo = DB.Data(cmd2);
                /*   string msg = "mix Info\n";
                   msg +=cbxMixName.GetItemText(cbxMixName.SelectedItem) + "\n";
                   MessageBox.Show(msg);
                   msg = "";
                   for (int i = 0; i < dtRawsInfo.Rows.Count; i++)
                   {
                       msg += "raw name is: " + dtRawsInfo.Rows[i][0].ToString()+"\n";
                       msg += "mix raw quantity is: " + dtRawsInfo.Rows[i][1].ToString() + "\n";
                   }
                   MessageBox.Show(msg);*/
                //check availibilty
                for (int i = 0; i < dtRawsInfo.Rows.Count; i++)
                {
                    decimal storedQ = Convert.ToDecimal(dtRawsInfo.Rows[i][2]+"");
                    decimal mixQ = Convert.ToDecimal(dtRawsInfo.Rows[i][1] + "");
                    if(mixQ>storedQ)
                    {
                        MessageBox.Show("لا تتوفر الخامات اللازمة بالمخزن");
                        cbxMixName.SelectedIndex = -1;
                        return;
                    }
                }
         
                //reduce stored Q
                //1
                for (int i = 0; i < dgvStore1.Rows.Count; i++)
                {
                    string rName = dgvStore1.Rows[i].Cells[1].Value + "";
                    for (int k = 0; k < dtRawsInfo.Rows.Count; k++)
                    {
                        string mixRaw = dtRawsInfo.Rows[k][0] + "";
                        if(mixRaw==rName)
                        {
                            decimal mixQ = Convert.ToDecimal(dtRawsInfo.Rows[k][1] + "");
                            if(mixQ>0)
                            {
                                decimal storedQ = Convert.ToDecimal(dtRawsInfo.Rows[k][2] + "");
                                decimal remainQ = storedQ - mixQ;
                                decimal[] qValues=convertFromGramToTonAndKiloAndGram(remainQ);
                                dgvStore1.Rows[i].Cells[2].Value =Convert.ToInt32( qValues[0])+"";
                                dgvStore1.Rows[i].Cells[3].Value = Convert.ToInt32(qValues[1]) + "";
                                dgvStore1.Rows[i].Cells[4].Value = Convert.ToInt32(qValues[2]) + "";
                                decimal[] qValuesMix = convertFromGramToTonAndKiloAndGram(mixQ);
                                dgvRaw1.Rows[i].Cells[2].Value = Convert.ToInt32(qValuesMix[0]) + "";
                                dgvRaw1.Rows[i].Cells[3].Value = Convert.ToInt32(qValuesMix[1]) + "";
                                dgvRaw1.Rows[i].Cells[4].Value = Convert.ToInt32(qValuesMix[2] )+ "";
                                rw1.Add(i);
                            }
                        }
                    }
                }
                //2
                for (int i = 0; i < dgvStore2.Rows.Count; i++)
                {
                    string rName = dgvStore2.Rows[i].Cells[1].Value + "";
                    for (int k = 0; k < dtRawsInfo.Rows.Count; k++)
                    {
                        string mixRaw = dtRawsInfo.Rows[k][0] + "";
                        if (mixRaw == rName)
                        {
                            decimal mixQ = Convert.ToDecimal(dtRawsInfo.Rows[k][1] + "");
                            if (mixQ > 0)
                            {
                                decimal storedQ = Convert.ToDecimal(dtRawsInfo.Rows[k][2] + "");
                                decimal remainQ = storedQ - mixQ;
                                decimal[] qValues = convertFromGramToTonAndKiloAndGram(remainQ);
                                dgvStore2.Rows[i].Cells[2].Value = Convert.ToInt32(qValues[0]) + "";
                                dgvStore2.Rows[i].Cells[3].Value = Convert.ToInt32(qValues[1]) + "";
                                dgvStore2.Rows[i].Cells[4].Value = Convert.ToInt32(qValues[2]) + "";
                                decimal[] qValuesMix = convertFromGramToTonAndKiloAndGram(mixQ);
                                dgvRaw2.Rows[i].Cells[2].Value = Convert.ToInt32(qValuesMix[0]) + "";
                                dgvRaw2.Rows[i].Cells[3].Value = Convert.ToInt32(qValuesMix[1]) + "";
                                dgvRaw2.Rows[i].Cells[4].Value = Convert.ToInt32(qValuesMix[2]) + "";
                                rw2.Add(i);
                            }
                        }
                    }
                }
                //3
                for (int i = 0; i < dgvStore3.Rows.Count; i++)
                {
                    string rName = dgvStore3.Rows[i].Cells[1].Value + "";
                    for (int k = 0; k < dtRawsInfo.Rows.Count; k++)
                    {
                        string mixRaw = dtRawsInfo.Rows[k][0] + "";
                        if (mixRaw == rName)
                        {
                            decimal mixQ = Convert.ToDecimal(dtRawsInfo.Rows[k][1] + "");
                            if (mixQ > 0)
                            {
                                decimal storedQ = Convert.ToDecimal(dtRawsInfo.Rows[k][2] + "");
                                decimal remainQ = storedQ - mixQ;
                                decimal[] qValues = convertFromGramToTonAndKiloAndGram(remainQ);
                                dgvStore3.Rows[i].Cells[2].Value = Convert.ToInt32(qValues[0]) + "";
                                dgvStore3.Rows[i].Cells[3].Value = Convert.ToInt32(qValues[1]) + "";
                                dgvStore3.Rows[i].Cells[4].Value = Convert.ToInt32(qValues[2]) + "";
                                decimal[] qValuesMix = convertFromGramToTonAndKiloAndGram(mixQ);
                                dgvRaw3.Rows[i].Cells[2].Value = Convert.ToInt32(qValuesMix[0]) + "";
                                dgvRaw3.Rows[i].Cells[3].Value = Convert.ToInt32(qValuesMix[1]) + "";
                                dgvRaw3.Rows[i].Cells[4].Value = Convert.ToInt32(qValuesMix[2]) + "";
                                rw3.Add(i);
                            }
                        }
                    }
                }


            }
        }

        private void clearFromGrid()
        {
      
            //1
            for (int i = 0; i < rw1.Count; i++)
            {
                int tonInLeft =Convert.ToInt32( dgvRaw1.Rows[rw1[i]].Cells[4].Value + "");
                int kiloInLeft = Convert.ToInt32(dgvRaw1.Rows[rw1[i]].Cells[3].Value + "");
                int gramInLeft = Convert.ToInt32(dgvRaw1.Rows[rw1[i]].Cells[2].Value + "");

                int tonInRight = tonInLeft+Convert.ToInt32(dgvStore1.Rows[rw1[i]].Cells[4].Value + "");
                int kiloInRight = kiloInLeft+ Convert.ToInt32(dgvStore1.Rows[rw1[i]].Cells[3].Value + "");
                int gramInRight = gramInLeft+ Convert.ToInt32(dgvStore1.Rows[rw1[i]].Cells[2].Value + "");

                dgvRaw1.Rows[rw1[i]].Cells[4].Value = 0;
                dgvRaw1.Rows[rw1[i]].Cells[3].Value = 0;
                dgvRaw1.Rows[rw1[i]].Cells[2].Value = 0;

                dgvStore1.Rows[rw1[i]].Cells[4].Value = tonInRight;
                dgvStore1.Rows[rw1[i]].Cells[3].Value = kiloInRight;
                dgvStore1.Rows[rw1[i]].Cells[2].Value = gramInRight;
            }

            //2
            for (int i = 0; i < rw2.Count; i++)
            {
                int tonInLeft = Convert.ToInt32(dgvRaw2.Rows[rw2[i]].Cells[4].Value + "");
                int kiloInLeft = Convert.ToInt32(dgvRaw2.Rows[rw2[i]].Cells[3].Value + "");
                int gramInLeft = Convert.ToInt32(dgvRaw2.Rows[rw2[i]].Cells[2].Value + "");

                int tonInRight = tonInLeft + Convert.ToInt32(dgvStore2.Rows[rw2[i]].Cells[4].Value + "");
                int kiloInRight = kiloInLeft + Convert.ToInt32(dgvStore2.Rows[rw2[i]].Cells[3].Value + "");
                int gramInRight = gramInLeft + Convert.ToInt32(dgvStore2.Rows[rw2[i]].Cells[2].Value + "");

                dgvRaw2.Rows[rw2[i]].Cells[4].Value = 0;
                dgvRaw2.Rows[rw2[i]].Cells[3].Value = 0;
                dgvRaw2.Rows[rw2[i]].Cells[2].Value = 0;

                dgvStore2.Rows[rw2[i]].Cells[4].Value = tonInRight;
                dgvStore2.Rows[rw2[i]].Cells[3].Value = kiloInRight;
                dgvStore2.Rows[rw2[i]].Cells[2].Value = gramInRight;
            }

            //3
            for (int i = 0; i < rw3.Count; i++)
            {
                int tonInLeft = Convert.ToInt32(dgvRaw3.Rows[rw3[i]].Cells[4].Value + "");
                int kiloInLeft = Convert.ToInt32(dgvRaw3.Rows[rw3[i]].Cells[3].Value + "");
                int gramInLeft = Convert.ToInt32(dgvRaw3.Rows[rw3[i]].Cells[2].Value + "");

                int tonInRight = tonInLeft + Convert.ToInt32(dgvStore3.Rows[rw3[i]].Cells[4].Value + "");
                int kiloInRight = kiloInLeft + Convert.ToInt32(dgvStore3.Rows[rw3[i]].Cells[3].Value + "");
                int gramInRight = gramInLeft + Convert.ToInt32(dgvStore3.Rows[rw3[i]].Cells[2].Value + "");

                dgvRaw3.Rows[rw3[i]].Cells[4].Value = 0;
                dgvRaw3.Rows[rw3[i]].Cells[3].Value = 0;
                dgvRaw3.Rows[rw3[i]].Cells[2].Value = 0;

                dgvStore3.Rows[rw3[i]].Cells[4].Value = tonInRight;
                dgvStore3.Rows[rw3[i]].Cells[3].Value = kiloInRight;
                dgvStore3.Rows[rw3[i]].Cells[2].Value = gramInRight;
            }
            rw1 = new List<int>();
            rw2 = new List<int>();
            rw3 = new List<int>();
        }

        private bool rawsInstore()
        {
            for (int i = 0; i < mixtureInfo.Rows.Count; i++)
            {
                string mixtureRawName = mixtureInfo.Rows[i][0].ToString();
                bool findRaw = false;
                for (int k = 0; k < dtRawStore.Rows.Count; k++)
                {
                    string storeRawName = dtRawStore.Rows[k][2].ToString();
                    if (mixtureRawName== storeRawName)
                    {
                        findRaw=true;
                    }
                }
                if (!findRaw)
                    return false;
                    
            }
            return true; 
        }
    }
}
