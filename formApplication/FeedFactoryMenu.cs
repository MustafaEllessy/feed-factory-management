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
    public partial class FeedFactoryMenu : Form
    {
       
        public FeedFactoryMenu()
        {
            InitializeComponent();
        }
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        decimal initialFormWidth = 0;
        decimal initialFormHeight = 0;

        private void pnlRawImports_Click(object sender, EventArgs e)
        {
            if (frmMode == 0)
            {
                formApplication.ImportRaws frm = new formApplication.ImportRaws();
                frm.ShowDialog();
            }
           else if(frmMode == 1)
            {
                formApplication.DisplayImportRaws frm = new formApplication.DisplayImportRaws();
                frm.ShowDialog();
            }

        }

        private void pnlRawStore_Click(object sender, EventArgs e)
        {
            formApplication.RawStore frm = new formApplication.RawStore();
            frm.ShowDialog();
        }

        private void pnlFeedProcess_Click(object sender, EventArgs e)
        {
            if (frmMode == 0)
            {
                feedProcessChoice frm = new feedProcessChoice();
                frm.ShowDialog();
            }
            else if (frmMode == 1)
            {
                formApplication.DisplayFeedProcess frm = new formApplication.DisplayFeedProcess();
                frm.ShowDialog();
            }
        }

        private void pnlFeedOut_Click(object sender, EventArgs e)
        {
            if (frmMode == 0)
            {
                formApplication.ExportFeeds frm = new formApplication.ExportFeeds();
                frm.ShowDialog();
            }
            else if (frmMode == 1)
            {
                formApplication.DisplayExportFeeds frm = new formApplication.DisplayExportFeeds();
                frm.ShowDialog();
            }
        }

        private void pnlFeedStore_Click(object sender, EventArgs e)
        {
            formApplication.FeedStore frm = new formApplication.FeedStore();
            frm.ShowDialog();
        }
        int frmMode = 0;
        private void FeedFactoryMenu_Load(object sender, EventArgs e)
        {
            frmMode = 0;
            panel1.BackgroundImage = formApplication.Properties.Resources.ادخال;
        }

        private void setControlResult()
        {
            foreach (var item in controlsDetails)
            {
                SortedDictionary<string, decimal> values = new SortedDictionary<string, decimal>();
                foreach (var item2 in item.Value)
                {
                    if (item2.Key == "width")
                    {
                        decimal widthPercentage = item2.Value / initialFormWidth;
                        values.Add(item2.Key, widthPercentage);
                    }
                    else if (item2.Key == "height")
                    {
                        decimal heightPercentage = item2.Value / initialFormHeight;
                        values.Add(item2.Key, heightPercentage);
                    }
                    else if (item2.Key == "x")
                    {
                        decimal xPercentage = item2.Value / initialFormWidth;
                        values.Add(item2.Key, xPercentage);
                    }
                    else if (item2.Key == "y")
                    {
                        decimal yPercentage = item2.Value / initialFormHeight;
                        values.Add(item2.Key, yPercentage);
                    }
                }
                string controlName = item.Key;

                controlsResult.Add(controlName, values);
            }
        }

        private void setContolDetails(Control control)
        {
            if (!control.HasChildren)
            {
                return;
            }
            foreach (Control c in control.Controls)
            {
                SortedDictionary<string, decimal> item = new SortedDictionary<string, decimal>();
                item.Add("width", c.Width);
                item.Add("height", c.Height);
                item.Add("x", c.Location.X);
                item.Add("y", c.Location.Y);
                controlsDetails.Add(c.Name, item);
            }
        }
        bool firstLoad = true;
        private void FeedFactoryMenu_Resize(object sender, EventArgs e)
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
        private void changeControls()
        {
            foreach (var item in controlsResult)
            {
                Control c = this.Controls.Find(item.Key, true).FirstOrDefault();
                List<int> targetValues = new List<int>();
                int newWidth = 0, newHeight = 0, newX = 0, newY = 0;
                foreach (var item2 in item.Value)
                {
                    if (item2.Key == "width")
                    {
                        newWidth = Convert.ToInt32(item2.Value * Width);
                    }
                    else if (item2.Key == "height")
                    {
                        newHeight = Convert.ToInt32(item2.Value * Height);
                    }
                    else if (item2.Key == "x")
                    {
                        newX = Convert.ToInt32(item2.Value * Width);
                    }
                    else if (item2.Key == "y")
                    {
                        newY = Convert.ToInt32(item2.Value * Height);

                    }

                }
                c.Width = newWidth;
                c.Height = newHeight;
                c.Location = new Point(newX, newY);
            }
        }

        private void pnlEnter_Click(object sender, EventArgs e)
        {
            frmMode = 0;
            panel1.BackgroundImage = formApplication.Properties.Resources.ادخال;
        }

        private void pnlView_Click(object sender, EventArgs e)
        {
            frmMode = 1;
            panel1.BackgroundImage = formApplication.Properties.Resources.عرض;
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void pnlSoledFeeds_Click(object sender, EventArgs e)
        {
            if(frmMode==0)
            {
                SoledFeeds frm = new SoledFeeds();
                frm.ShowDialog(); 
            }
            else if(frmMode==1)
            {
                DisplaySoledFeeds frm = new DisplaySoledFeeds();
                frm.ShowDialog();
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            formApplication.Reports frm = new formApplication.Reports();
            frm.ShowDialog();
        }

        private void pnlFeedProcess_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
