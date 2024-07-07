using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingPR.Accounts
{
    public partial class frmListAccounts : Form
    {


        DataTable _dtReports;
        DataTable _dtAccounts;
        DataTable _dtAccountTypes;

        async void _FillAccountTypeComboBox()
        {
            _dtAccountTypes = await clsAccountType.GetAllAccountTypesAsync();
            if (_dtAccountTypes != null)
            {
                cbAccountType.DataSource = _dtAccountTypes;
                cbAccountType.ValueMember = "AccountTypeID";
                cbAccountType.DisplayMember = "AccountTypeNameAr";

                //    foreach (DataRow r in _dtAccountTypes.Rows)
                //    {
                //        cbAccountType.Items.Add(r["AccountTypeNameAr"]);
                //    }
            }
        }
        public frmListAccounts()


        {
            InitializeComponent();
        }

        async void _FillReportsCombomBox()
        {
            _dtReports = await clsReport.GetAllReportsAsync();
            if(_dtReports != null)
            {
                cbReport.DataSource = _dtReports;
                cbReport.ValueMember = "ReportID";
                cbReport.DisplayMember = "ReportNameAr";
                //foreach (DataRow row in _dtReports.Rows)
                //{
                //    cbReport.Items.Add(row["ReportNameAr"]);
                //}
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            temp.BackColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            temp.BackColor = Color.LightYellow;
            temp.SelectAll(); temp.Focus();

        }

        private void frmListAccounts_Load(object sender, EventArgs e)
        {
            _FillAccountTypeComboBox();
            _FillReportsCombomBox();
        }
    }
}
