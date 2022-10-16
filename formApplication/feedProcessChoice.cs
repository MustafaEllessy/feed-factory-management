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
    public partial class feedProcessChoice : Form
    {
        public feedProcessChoice()
        {
            InitializeComponent();
        }
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        private void feedProcessChoice_Load(object sender, EventArgs e)
        {

        }
        bool firstLoad = true;
        private void feedProcessChoice_Resize(object sender, EventArgs e)
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
        public static bool feedReady = false;
        private void btnMakeMixture_Click(object sender, EventArgs e)
        {
            feedReady = false;
            formApplication.FeedProccess frm=new formApplication.FeedProccess();
            frm.ShowDialog();

        }

        private void btnChooseMixture_Click(object sender, EventArgs e)
        {
            feedReady = true;
            formApplication.FeedProccess frm = new formApplication.FeedProccess();
            frm.ShowDialog();
        }
    }
}
