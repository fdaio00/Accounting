using AccountingPR.System_Settings;
using AccountingPR_BusinessLA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingPR
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void بياناتالاتصالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnectionFormat frm =new frmConnectionFormat();
            frm.ShowDialog(); 
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
