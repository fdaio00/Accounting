using AccountingPR_BusinessLA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingPR.Company
{
    public partial class frmCompanyInfo : Form
    {
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _EnbleDesableTextBoxes(bool IsEnable)
        {
            txtAddressAr.Enabled = IsEnable;
            txtAddressEN.Enabled = IsEnable;
            txtCompNameAr.Enabled = IsEnable;
            txtCompNameEn.Enabled = IsEnable;
            txtEmail.Enabled = IsEnable;
            txtFax.Enabled = IsEnable;
            txtPhone.Enabled = IsEnable;
            txtWebiste.Enabled = IsEnable;
            txtWebiste.Enabled = IsEnable;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _EnbleDesableTextBoxes(true);
            txtCompNameAr.Focus();
            btnSave.Enabled = true;
            btnNew.Enabled = false; 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDataAccessSettings connection = clsDataAccessSettings.GetInstance();
            SqlParameter []par = new SqlParameter[10];

            //par[0] = 
        }
    }
}
