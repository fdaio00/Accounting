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

        clsAccount _Account; 
        DataTable _dtReports;
        DataTable _dtAccountTypes;

        async void _FillAccountTypeIDComboBox()
        {
            _dtAccountTypes = await clsAccountType.GetAllAccountTypeIDsAsync();
            if (_dtAccountTypes.Rows.Count>0)
            {
                cbAccountType.DataSource = _dtAccountTypes;
                cbAccountType.ValueMember = "AccountTypeID";
                cbAccountType.DisplayMember = "AccountTypeNameAr";

                //foreach (DataRow r in _dtAccountTypes.Rows)
                //{
                //    cbAccountType.Items.Add(r["AccountTypeNameAr"]);
                //}
            }
        }
        public frmListAccounts()


        {
            InitializeComponent();
        }


        private async void _CreateNodes()
        {
            TreeNode tn;
            tvAccounts.Nodes.Clear();
            DataView dataView = new DataView(await clsAccount.GetAllAccountsAsync());
            dataView.RowFilter = "AccountParentNo=0";
            foreach(DataRowView dv in dataView)
            {
                tn = new TreeNode((dv["AccountNo"]).ToString()+" " + dv["AccountNameAr"].ToString() );
                tn.Tag = dv["AccountNo"].ToString();
                tvAccounts.Nodes.Add(tn);
            }
            foreach(TreeNode tNode in tvAccounts.Nodes)
            {
                _CreateChildNode(tNode);
            }
        }

        private void _LoadAccountInfo(int AccountNo)
        {
            _Account = clsAccount.GetAccountByID(AccountNo);
            if (_Account == null)
            {
                MessageBox.Show("لايوجد حساب بهذا الرقم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtAccountLevel.Text = _Account.AccountLevel.ToString();
            txtAccountNo.Text = _Account.AccountID.ToString();
            txtAccountName.Text = _Account.AccountNameAr.ToString();
            txtBalance.Text = _Account.AccountBalance.ToString();
            txtDebit.Text = _Account.AccountDebit.ToString();
            txtCredit.Text = _Account.AccountCredit.ToString();
            txtParentAccountNo.Text = _Account.AccountParentNo.ToString();
            cbAccountType.Text = _Account.AccountType.AccountTypeINameAr;
            cbReport.Text = _Account.AccoutReport.ReportNameAr;
            
        }
        private async void _CreateChildNode(TreeNode treeNode)
        {
            TreeNode childNode;
            DataView dataView = new DataView(await clsAccount.GetAllAccountsAsync());
            dataView.RowFilter = $"AccountParentNo={Convert.ToInt32(treeNode.Tag)}";
            foreach (DataRowView dv in dataView)
            {
                childNode = new TreeNode((dv["AccountNo"]).ToString() + " " + dv["AccountNameAr"].ToString());
                childNode.Tag = dv["AccountNo"].ToString();
                treeNode.Nodes.Add(childNode);
                _CreateChildNode(childNode);
            }
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
            _FillAccountTypeIDComboBox();
            _FillReportsCombomBox();
            _CreateNodes();
        }

        private void tvAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int AccountNo = Convert.ToInt32(tvAccounts.SelectedNode.Tag.ToString());
            _LoadAccountInfo(AccountNo);
            btnSave.Enabled = true;
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        void _ClearTextBoxes()
        {
            txtAccountLevel.Clear();
            txtAccountNo.Clear(); 
            txtAccountName.Clear(); 
            txtBalance.Clear(); 
                txtDebit.Clear(); 
            txtCredit.Clear(); 
            txtParentAccountNo.Clear();
            cbAccountType.SelectedIndex = 0; 
            cbReport.SelectedIndex = 0; 
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true; 
            _Account = new clsAccount();
            _ClearTextBoxes();
            txtAccountName.Focus();
        }
    }
}
