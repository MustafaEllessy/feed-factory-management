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
    public partial class RawStore : Form
    {
        DataTable dtRawStore;
        public RawStore()
        {
            InitializeComponent();
        }
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        private void frmRawStore_Load(object sender, EventArgs e)
        {
            loadRawStore();
            dgvStore1.ClearSelection();
            dgvStore2.ClearSelection();
            lblNo.Text = "1";

        }

        private void loadRawStore()
        {
            dtRawStore = DB.Data("select * from rawsStore");
            
            if (dtRawStore.Rows.Count > 11)
            {
                for (int i = 0; i < 11; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    DateTime lastUpdate =(DateTime) dr[1];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
                   // if (Unit == "جرام")
                  //  {
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                    string serialNO = (i + 1)+"";
                    string rowName=  rawName;
                    string gramValue = unitsValues[0]+"";
                    string kiloValue = unitsValues[1]+"";
                    string tonValue = unitsValues[2]+"";
                    dgvStore1.Rows.Add(serialNO, lastUpdate.ToString("yyyy/MM/dd"),rowName, gramValue, kiloValue, tonValue);
                   // }
                }
                for (int i = 11; i < dtRawStore.Rows.Count; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    DateTime lastUpdate = (DateTime)dr[1];
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
               //     if (Unit == "جرام")
                 //   {
                    decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                    string serialNO = (i + 1) + "";
                    string rowName = rawName;
                    string gramValue = unitsValues[0] + "";
                    string kiloValue = unitsValues[1] + "";
                    string tonValue = unitsValues[2] + ""; // }
                    dgvStore2.Rows.Add(serialNO, lastUpdate.ToString("yyyy/MM/dd"), rowName, gramValue, kiloValue, tonValue);
                }

            }
            else
            {
                for (int i = 0; i < dtRawStore.Rows.Count; i++)
                {
                    DataRow dr = dtRawStore.Rows[i];
                    string lastUpdate = dr[1].ToString();
                    string rawName = dr[2].ToString();
                    decimal quantity = Convert.ToDecimal(dr[3].ToString());
                    string Unit = dr[4].ToString();
                    if (Unit == "جرام")
                    {
                        decimal[] unitsValues = convertFromGramToTonAndKiloAndGram(quantity);
                        dgvStore1.Rows.Add(new object[] { i + 1, lastUpdate,rawName, unitsValues[0], unitsValues[1], unitsValues[2] });
                    }
                }
            }
        }


        private decimal[] convertFromGramToTonAndKiloAndGram(decimal quantity)
        {
            decimal tonn = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal(quantity / 1000000)));
            decimal Killo = Convert.ToDecimal(Math.Truncate(Convert.ToDecimal((quantity - (tonn * 1000000)) / 1000)));
            decimal Gram = Convert.ToDecimal((quantity - ((tonn * 1000000) + (Killo * 1000))));
            return new decimal[] { Gram, Killo, tonn };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvStore2.Visible = true;
            dgvStore1.Visible = false;
            lblNo.Text = "2";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            dgvStore1.Visible = true;
            dgvStore2.Visible = false;
            lblNo.Text = "1";
        }

        private void dgvStore1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStore2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        bool firstLoad = true;
        private void RawStore_Resize(object sender, EventArgs e)
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
