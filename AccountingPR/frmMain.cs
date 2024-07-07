using AccountingPR.Accounts;
using AccountingPR.Company;
using AccountingPR.System_Settings;
using AccountingPR.Users;
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

        private void بياناتالشركةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyInfo frm = new frmCompanyInfo();
            frm.ShowDialog();
        }

        private void المستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog(); 
        }

        private void دليلالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAccounts frm = new frmListAccounts();
            frm.ShowDialog(); 
        }
    }
}
