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
    public partial class ImportRaws : Form
    {
        DataTable dtRawStore;
        List<int> rowIndex1 = new List<int>();
        List<int> rowIndex2= new List<int>();
        List<int> rowIndex3 = new List<int>();

        public ImportRaws()
        {
           InitializeComponent();
        }
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        private void frmImportedRaws_Load(object sender, EventArgs e)
        {
            loadRawStore();

        }



        private void loadRawStore()
        {
            dtRawStore = DB.Data("select * from rawsStore");
         if (dtRawStore.Rows.Count < 9)
            {
                DataRow dr = dtRawStore.Rows[0];
                string rawName = dr[2].ToString();
                decimal quantity = Convert.ToDecimal(dr[3].ToString());
                string Unit = dr[4].ToString();
                //    if (Unit == "جرام")
                //    {
                decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                dgvStore1.Rows.Add(new object[] {  1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                dgvImport1.Rows.Add(new object[] { 1, rawName, 0, 0, 0, 0 });
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
                    dgvStore1.Rows.Add(new object[]  { i + 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                    dgvImport1.Rows.Add(new object[] { i + 1, rawName ,0,0,0,0});
                    //   }
                }
                for (int i = 9; i < 18; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
                    // if (Unit == "جرام")
                    //  {
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                        dgvStore2.Rows.Add(new object[] { i + 1, rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                        dgvImport2.Rows.Add(new object[] { i + 1, rawName, 0, 0, 0, 0 });
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
                        dgvImport3.Rows.Add(new object[] { i + 1, rawName, 0, 0, 0, 0 });
                    // }
                }
                dgvStore1.ClearSelection();
                dgvStore2.ClearSelection();
                dgvStore3.ClearSelection();
                dgvImport1.ClearSelection();
                dgvImport2.ClearSelection();
                dgvImport3.ClearSelection();
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
            
            if(dgvStore3.Visible)
            {
                dgvStore3.Visible = false;
                dgvStore2.Visible = true;
                dgvStore1.Visible = false;
            }
            else if(dgvStore2.Visible)
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
        public bool nextOnce = false;
        public bool prevOnce = false;
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
            if (dgvImport1.Visible)
            {
                dgvImport1.Visible = false;
                dgvImport2.Visible = true;
                dgvImport3.Visible = false;
            }
            else if (dgvImport2.Visible)
            {
                dgvImport1.Visible = false;
                dgvImport3.Visible = true;
                dgvImport2.Visible = false;
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

            if (dgvImport3.Visible)
            {
                dgvImport1.Visible = false;
                dgvImport2.Visible = true;
                dgvImport3.Visible = false;
            }
            else if (dgvImport2.Visible)
            {
                dgvImport2.Visible = false;
                dgvImport1.Visible = true;
                dgvImport3.Visible = false;
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

        private void btnRecord_Click(object sender, EventArgs e)
        {

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

  

        private void dgvStore1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvImport1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                return;
            }
            if ( Convert.ToInt32(dgvImport1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
            {
                dgvStore1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())-
                Convert.ToInt32(dgvImport1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }

        }
        private void dgvImport1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
       
            if (e.ColumnIndex == 5)
            {
                return;
            }
            try
            {
                dgvStore1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                (Convert.ToInt32(dgvStore1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) +
                Convert.ToInt32(dgvImport1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex1.Add(e.RowIndex);
        }

        private void dgvImport2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                return;
            }
            if (Convert.ToInt32(dgvImport2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
            {
                dgvStore2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) -
                Convert.ToInt32(dgvImport2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        private void dgvImport2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5  )
            {
                return;
            }
            try
            {
                  dgvStore2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                  (Convert.ToInt32(dgvStore2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) +
                   Convert.ToInt32(dgvImport2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rowIndex2.Add(e.RowIndex);

        }

        private void dgvImport3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                return;
            }
            if ( Convert.ToInt32(dgvImport3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
            {
                dgvStore3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) -
                Convert.ToInt32(dgvImport3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        private void dgvImport3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                return;
            }
            try
            {
                dgvStore3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                  (Convert.ToInt32(dgvStore3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) +
                   Convert.ToInt32(dgvImport3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
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
            string price = dr.Cells[5].Value.ToString();
            string rawdateTime= dtImportTime.Value.ToString("dd/MM/yyyy");
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
            string companyName = txtCompanyName.Text; 
            price = (price == null) ? "0" : price;
            object[] rawData = new object[] { rawdateTime, rawName, gram, "جرام",Convert.ToDecimal( price) , companyName };
            DB.insertToDB("importedRaws", new string[] { "importDate","rawName", "quantity", "unit", "price", "companyName" }, rawData);
        }
        public void updateRawStore(DataGridViewRow dr)
        {
            string rawName = dr.Cells[1].Value.ToString();
            string gramQ = dr.Cells[2].Value.ToString();
            string kiloQ = dr.Cells[3].Value.ToString();
            string tonnQ = dr.Cells[4].Value.ToString();
            string rawdateTime = dtImportTime.Value.ToString("dd/MM/yyyy");
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

            DB.affectBuild("update rawsStore set lastUpdate='"+ rawdateTime + "', quantity="+gram+ " ,unit='جرام' "+"where rawName='"+rawName+"';");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> row1 = rowIndex1.Distinct().ToList();
                List<int> row2 = rowIndex2.Distinct().ToList();
                List<int> row3 = rowIndex3.Distinct().ToList();
                for (int i = 0; i < row1.Count; i++)
                {
                    DataGridViewRow dr = dgvImport1.Rows[row1[i]];
                    DataGridViewRow dr2 = dgvStore1.Rows[row1[i]];
                    addImportedRow(dr);
                    updateRawStore(dr2);
                }
                for (int i = 0; i < row2.Count; i++)
                {
                    DataGridViewRow dr = dgvImport2.Rows[row2[i]];
                    DataGridViewRow dr2 = dgvStore2.Rows[row2[i]];
                    addImportedRow(dr);
                    updateRawStore(dr2);
                }
                for (int i = 0; i < row3.Count; i++)
                {
                    DataGridViewRow dr = dgvImport3.Rows[row3[i]];
                    DataGridViewRow dr2 = dgvStore3.Rows[row3[i]];
                    addImportedRow(dr);
                    updateRawStore(dr2);
                }
                if((row1.Count+ row2.Count+ row3.Count)==0)
                {
                    MessageBox.Show("لم يتم ادخال بيانات");
                    return;
                }
                MessageBox.Show("تم الحفظ");
                for (int i = 0; i < row1.Count; i++)
                {
                    dgvImport1.Rows[row1[i]].Cells[2].Value = 0;
                    dgvImport1.Rows[row1[i]].Cells[3].Value = 0;
                    dgvImport1.Rows[row1[i]].Cells[4].Value = 0;
                    dgvImport1.Rows[row1[i]].Cells[5].Value = 0;
                }
                for (int i = 0; i < row2.Count; i++)
                {
                    dgvImport2.Rows[row2[i]].Cells[2].Value = 0;
                    dgvImport2.Rows[row2[i]].Cells[3].Value = 0;
                    dgvImport2.Rows[row2[i]].Cells[4].Value = 0;
                    dgvImport2.Rows[row2[i]].Cells[5].Value = 0;
                }
                for (int i = 0; i < row3.Count; i++)
                {
                    dgvImport3.Rows[row3[i]].Cells[2].Value = 0;
                    dgvImport3.Rows[row3[i]].Cells[3].Value = 0;
                    dgvImport3.Rows[row3[i]].Cells[4].Value = 0;
                    dgvImport3.Rows[row3[i]].Cells[5].Value = 0;
                }
                row1.Clear();
                row2.Clear();
                row3.Clear();
                txtCompanyName.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد مشكلة كالاًتى: "+ex.Message);
            }
            

        }

        private void dgvImport2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                e.Cancel=true;
            }
        }

        private void dgvImport2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvImport3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStore2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvImport1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtImportTime_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dgvStore3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        bool firstLoad = true;
        private void ImportRaws_Resize(object sender, EventArgs e)
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


