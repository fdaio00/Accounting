using AccountingPR.Global;
using AccountingPR.System_Settings;
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

namespace AccountingPR.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            string Mode = Properties.Settings.Default.Mode;
            string Server = Properties.Settings.Default.Server;
            string DB = Properties.Settings.Default.DB;
            string UserID = Properties.Settings.Default.UserID;
            string Password = Properties.Settings.Default.Password;
            clsSettings.SetServerSettings(Mode, Server, DB, UserID, Password);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region Code to save credintial in Registery
            if (chbRememberMe.Checked)
            {
                if (clsGlobal.SaveCredintail(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    //MessageBox.Show("Saved");
                };
            }
            else
            {
                clsGlobal.SaveCredintail("", "");
            }
            #endregion

            DataTable dtLogin = clsLogin.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            try
            {


                if (dtLogin.Rows.Count > 0 && dtLogin != null)
                {
                    frmMain frm = new frmMain();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور خاطئة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsGlobal.SetErrorLoggingEvent(ex.Message);
                return; 
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";

            if (clsGlobal.GetCredintail(ref UserName, ref Password))
            {
                if (UserName != "")
                {
                    chbRememberMe.Checked = true;
                }
                else
                    chbRememberMe.Checked = false;

            }

            txtPassword.Text = Password;
            txtUserName.Text = UserName;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectionFormat frm = new frmConnectionFormat();
            frm.ShowDialog();
        }
    }
}
