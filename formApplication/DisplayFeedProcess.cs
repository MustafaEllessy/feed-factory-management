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
    public partial class DisplayFeedProcess : Form
    {
        DataTable dtFeedFactory;
        DataTable dtExportedRaws;
        public DisplayFeedProcess()
        {
            InitializeComponent();
        }
        public DataTable getUsedRaws(string id)
        {
            DataTable dt = DB.Data("select * from exportedRaws where productID="+id);
            return dt;
        }
        private void frmProducedFeedDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                dtFeedFactory = DB.Data("select * from feedFactory");
                dtExportedRaws = DB.Data("select * from exportedRaws");
                foreach (DataRow row in dtFeedFactory.Rows)
                {
                    //feed
                    string ID = row[0].ToString();
                    string produceDate = ((DateTime)row[1]).ToString("dd/MM/yyyy");
                    string produceFeed = row[2].ToString();
                    decimal quantity =( Convert.ToDecimal(row[3].ToString())/1000000);
                    string unit = "طن";
                    //raws
                    DataTable usedRaws = getUsedRaws(ID);
                    string rawsAndQnts = "";
                    int counter = 0;
                    foreach (DataRow dr in usedRaws.Rows)
                    {
                        string rawName = dr[1].ToString();
                        decimal qnt =Convert.ToDecimal (Convert.ToDecimal(dr[2].ToString())/1000);
                        string rawUnit = dr[3].ToString();
                        rawsAndQnts += (qnt + " " + "كيلو" + " -> " + rawName);
                        counter++;
                        if (counter == usedRaws.Rows.Count) break;
                        rawsAndQnts += " و ";
                    }

                    object[] displayRow = new object[] { produceDate, rawsAndQnts, produceFeed, unit, quantity };
                    dgvFeedsInFactory.Rows.Add(displayRow);
                }
                dgvFeedsInFactory.ClearSelection();
             //   dgvFeedsInFactory.Sort(dgvFeedsInFactory.Columns["colProductDate"], ListSortDirection.Ascending);

            }


            catch (Exception ex)
            {
                MessageBox.Show("يوجد مشكلة فى العرض : ");
                MessageBox.Show(ex.Message);
            }

        }
    }
}
