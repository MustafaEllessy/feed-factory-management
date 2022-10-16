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
    public partial class ProducedFeed : Form
    {
        public ProducedFeed()
        {
            InitializeComponent();
        }
        public void addImportedRow(DataGridViewRow dr)
        {
            string rawName = dr.Cells[1].Value.ToString();
            string gramQ = dr.Cells[2].Value.ToString();
            string kiloQ = dr.Cells[3].Value.ToString();
            string tonnQ = dr.Cells[4].Value.ToString();
            string price = dr.Cells[5].Value.ToString();
            string rawdateTime = FeedProccess.produceDate;
            decimal gram = 0;
            if ((gramQ == null || (gramQ == "") || (gramQ == "0")) && (kiloQ == null || (kiloQ == "") || (kiloQ == "0")) &&
                (tonnQ == null || (tonnQ == "") || (tonnQ == "0")))
                return;
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

            price = (price == null) ? "0" : price;
            object[] rawData = new object[] { rawdateTime, rawName, gram, "جرام", Convert.ToDecimal(price) };
            DB.insertToDB("importedRaws", new string[] { "importDate", "rawName", "quantity", "unit", "price" }, rawData);
        }
        public void updateRawStore(DataGridViewRow dr)
        {
            string rawName = dr.Cells[1].Value.ToString();
            string gramQ = dr.Cells[2].Value.ToString();
            string kiloQ = dr.Cells[3].Value.ToString();
            string tonnQ = dr.Cells[4].Value.ToString();
            string rawdateTime = FeedProccess.produceDate;
            decimal gram = 0;
            if ((gramQ == null || (gramQ == "") || (gramQ == "0")) && (kiloQ == null || (kiloQ == "") || (kiloQ == "0")) &&
                (tonnQ == null || (tonnQ == "") || (tonnQ == "0")))
                return;
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

            DB.affectBuild("update rawsStore set lastUpdate='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss a") + "', quantity=" + gram + " ,unit='جرام' " + "where rawName='" + rawName + "';");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtProductName.Text == "" || txtQuantity.Text == "" || txtUnit.Text == "")
                {
                    MessageBox.Show("يجب ملأ الخانات الفارغة");
                    return;
                }
                string itemName = txtProductName.Text;
                decimal quant = Convert.ToDecimal(txtQuantity.Text)*1000000;
                string unit = "جرام";
                DB.insertToDB("feedFactory", new string[] { "produceDate", "produceFeed", "quantity", "unit" }, new object[] { FeedProccess.produceDate, itemName, quant, unit });
                int FeedID = Convert.ToInt32(DB.Data("select * from feedLastID").Rows[0][0].ToString());
                for (int i = 0; i < FeedProccess.feedFactoryInsertRows.Count; i++)
                {
                    DataGridViewRow dr1 = FeedProccess.feedFactoryInsertRows[i];
                    string rawName = dr1.Cells[1].Value.ToString();
                    string gramQ = dr1.Cells[2].Value.ToString();
                    string kiloQ = dr1.Cells[3].Value.ToString();
                    string tonnQ = dr1.Cells[4].Value.ToString();
                    decimal gram = 0;
                    if ((gramQ == null || (gramQ == "") || (gramQ == "0")) && (kiloQ == null || (kiloQ == "") || (kiloQ == "0")) &&
                        (tonnQ == null || (tonnQ == "") || (tonnQ == "0")))
                    {
                        return;
                    }
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
                    object[] rawData = new object[] {  rawName, gram, "جرام", FeedID };
                    DB.insertToDB("exportedRaws", new string[] { "rawName", "quantity", "unit", "productID" }, rawData);
                }
                for (int i = 0; i < FeedProccess.feedFactoryUpdateRows.Count; i++)
                {
                    DataGridViewRow dr1 = FeedProccess.feedFactoryUpdateRows[i];
                    string rawName = dr1.Cells[1].Value.ToString();
                    string gramQ = dr1.Cells[2].Value.ToString();
                    string kiloQ = dr1.Cells[3].Value.ToString();
                    string tonnQ = dr1.Cells[4].Value.ToString();
                    string rawdateTime = FeedProccess.produceDate;
                    decimal gram = 0;
                    if ((gramQ == null || (gramQ == "") || (gramQ == "0")) && (kiloQ == null || (kiloQ == "") || (kiloQ == "0")) &&
                        (tonnQ == null || (tonnQ == "") || (tonnQ == "0")))
                        return;
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

                    DB.affectBuild("update rawsStore set lastUpdate='" + rawdateTime + "', quantity=" + gram + " ,unit='جرام' " + "where rawName='" + rawName + "';");
                }
                DataTable rslt = DB.Data("select quantity from feedStore where producedFeed='" + itemName + "'");
                if(rslt.Rows.Count==0)
                {
                    DB.insertToDB("feedStore", new string[] { "lastUpdate", "producedFeed", "quantity", "unit" }, new object[] { FeedProccess.produceDate, itemName, quant, "جرام" });
                }
                else
                {
                    decimal storedQuantity = Convert.ToDecimal(rslt.Rows[0][0].ToString());
                    quant += storedQuantity;
                    DB.affectBuild("update feedStore set lastUpdate='" + FeedProccess.produceDate + "', quantity=" + quant + " ,unit='جرام' " + " where producedFeed='" + itemName + "';");
                }

                DialogResult dr =  MessageBox.Show("تم الحفظ");
                if(dr==DialogResult.OK)
                {
                    this.Close();
                    FeedMsg frm = new FeedMsg();
                    frm.ShowDialog();
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك مشكلة فى الإدخال");
               MessageBox.Show(ex.Message);
            }
      
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar!='.') e.Handled = true;
        }
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        private void frmProducedFeed_Load(object sender, EventArgs e)
        {

        }

        private void loopOverControls(Control c)
        {
            if(!c.HasChildren)
            {

                return;
            }
            foreach (Control item in c.Controls)
            {
                MessageBox.Show(item.Name);
                MessageBox.Show("X: "+ item.Location.X);
                MessageBox.Show("Y: " + item.Location.Y);
                MessageBox.Show("Width: " + item.Width);
                MessageBox.Show("Height: " + item.Height);

                loopOverControls(item);
            }
        }

        private void ProducedFeed_FormClosed(object sender, FormClosedEventArgs e)
        {
            FeedProccess.feedFactoryInsertRows.Clear();
            FeedProccess.feedFactoryUpdateRows.Clear();   
        }
        bool firstLoad = true;
        private void ProducedFeed_Resize(object sender, EventArgs e)
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
