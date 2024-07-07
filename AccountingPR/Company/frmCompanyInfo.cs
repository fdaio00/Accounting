using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace AccountingPR.Company
{
    public partial class frmCompanyInfo : Form
    {

        DataTable _dt;
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;
        int? _CompanyID = -1;

        clsCompany _Company;
        public frmCompanyInfo(int CompanyID)
        {
            InitializeComponent();
            _CompanyID = CompanyID;
            _Mode = enMode.Update;



        }
        public frmCompanyInfo()
        {
            InitializeComponent();
            _CompanyID = -1;
            _Mode = enMode.AddNew;

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int CompanyID = Convert.ToInt32(dgvListCompines.CurrentRow.Cells[0].Value);
            if(MessageBox.Show("هل أنت متأكد من حذف هذه الشركة ؟","حذف!",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation)==DialogResult.OK)
            {
                if(await clsCompany.DeleteAsync(CompanyID))
                {

                    MessageBox.Show("تم الحذف بنجاح", "تم الحذف !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    _GetAllCompanies();
        
                }
                else
                {
                    MessageBox.Show("حصل خطأ ما", " خطأ!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _ClearTextBoxes()
        {

            txtAddressAr.Clear();
            txtAddressEN.Clear();
            txtCompNameAr.Clear();
            txtCompNameEn.Clear();
            txtEmail.Clear();
            txtFax.Clear();
            txtPhone.Clear();
            txtWebiste.Clear();
            txtWebiste.Clear();
            pbCompImage.Image = null;
        }
        void _ResetDefaultValues()
        {
            _GetAllCompanies();
            if (_Mode == enMode.AddNew)
                _Company = new clsCompany();
            _EnbleDesableTextBoxes(false);
            _ClearTextBoxes(); 
            btnDelete.Enabled = false;
            btnRemovePc.Enabled = false;
            btnBrowse.Enabled = false;
        }

        private static Bitmap ByteToImage(byte[] logo)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = logo;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        void _LoadCompanyInfo()
        {
            _Company = clsCompany.GetCompanyByIDAsync(_CompanyID ?? -1);
            if (_Company == null)
            {
                MessageBox.Show("لاتوجد شركة بهذا الاسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            txtAddressAr.Text = _Company.AddressAr;
            txtAddressEN.Text = _Company.AddressEn;
            txtCompNameAr.Text = _Company.CompanyNameAr;
            txtCompNameEn.Text = _Company.CompanyNameEn;
            txtEmail.Text = _Company.Email;
            txtFax.Text = _Company.Fax;
            txtPhone.Text = _Company.Phone;
            txtWebiste.Text = _Company.Website;

            if (_Company.Logo != null)
            {
                pbCompImage.Image = ByteToImage(_Company.Logo);
            }
            else
            {
                pbCompImage.Image = null;
            }

            //btnBrowse.Enabled = (_Company.Logo!=null);
            btnDelete.Enabled = (_Company.Logo != null);

        } 
        void _LoadCompanyInfo(int CompanyID)
        {
            
            _Company = clsCompany.GetCompanyByIDAsync(CompanyID);
            if (_Company == null)
            {
                MessageBox.Show("لاتوجد شركة بهذا الاسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _EnbleDesableTextBoxes(true);
            txtAddressAr.Text = _Company.AddressAr;
            txtAddressEN.Text = _Company.AddressEn;
            txtCompNameAr.Text = _Company.CompanyNameAr;
            txtCompNameEn.Text = _Company.CompanyNameEn;
            txtEmail.Text = _Company.Email;
            txtFax.Text = _Company.Fax;
            txtPhone.Text = _Company.Phone;
            txtWebiste.Text = _Company.Website;

            if (_Company.Logo != null)
            {
                pbCompImage.Image = ByteToImage(_Company.Logo);
            }
            else
            {
                pbCompImage.Image = null;
            }
            btnDelete.Enabled = true; 
            btnEdit.Enabled = true; 
            btnBrowse.Enabled = true;
            btnSave.Enabled = false; 
            btnRemovePc.Enabled = (_Company.Logo != null);

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
            dgvListCompines.ClearSelection();
            _ClearTextBoxes(); 
            txtCompNameAr.Focus();
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnBrowse.Enabled = true;


        }
        //public static byte[] CopyImageToByteArray(Image theImage)
        //{
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        theImage.Save(memoryStream, ImageFormat.Png);
        //        return memoryStream.ToArray();
        //    }
        //}
        private async void btnSave_Click(object sender, EventArgs e)
        {
            _Company.Phone = txtPhone.Text;
            // Checking if txtEmail.Text is not empty, then assigning its value to _Company.Email
            _Company.Email = string.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text;
            _Company.AddressAr = txtAddressAr.Text;
            _Company.AddressEn = string.IsNullOrEmpty(txtAddressEN.Text) ? "" : txtAddressEN.Text;
            byte[] imageBytes = null;

            // Check if there is an image in the PictureBox
            if (pbCompImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pbCompImage.Image.Save(ms, pbCompImage.Image.RawFormat);
                imageBytes = ms.ToArray();
            }

            _Company.Logo = imageBytes;
            _Company.CompanyNameAr = txtCompNameAr.Text;
            _Company.CompanyNameEn = string.IsNullOrEmpty(txtCompNameEn.Text) ? "" : txtCompNameEn.Text;
            _Company.Fax = string.IsNullOrEmpty(txtFax.Text) ? "" : txtFax.Text;
            _Company.Website = string.IsNullOrEmpty(txtWebiste.Text) ? "" : txtWebiste.Text;

            if (await _Company.SaveAsync())
            {
                MessageBox.Show("تم لحفظ بنجاح");
                _CompanyID = _Company.CompanyID;
                _Mode = enMode.Update;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                _GetAllCompanies();
    

            }
            else

            {
                MessageBox.Show("حدث خطأ ما ");

            }





        }

        async void _GetAllCompanies()
        {
            _dt = await clsCompany.GetAllCompaniesAsync();
                dgvListCompines.DataSource = _dt;
            if (dgvListCompines.Rows.Count > 0)
            {
                dgvListCompines.Columns[0].Visible = false; 
                dgvListCompines.Columns[9].Visible = false; 

            }
        }

        private async void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadCompanyInfo();

        }

        private void pbCompImage_Click(object sender, EventArgs e)
        {




        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog1.Title = "اختر صورة...";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    pbCompImage.ImageLocation = openFileDialog1.FileName;
                    btnDelete.Enabled = true;
                }
            }
           

        }

        private void dgvListCompines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CompanyID = Convert.ToInt32(dgvListCompines.CurrentRow.Cells[0].Value);
            if(CompanyID > 0)
            {
                _LoadCompanyInfo(CompanyID);
            }
        }

        private void btnRemovePc_Click(object sender, EventArgs e)
        {
            pbCompImage.Image = null;
            btnRemovePc.Enabled = false;
            _GetAllCompanies();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            _GetAllCompanies();

        }

        private void txtBoxEnter(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender; 
            temp.BackColor = Color.LightYellow;
        }
    }
}
