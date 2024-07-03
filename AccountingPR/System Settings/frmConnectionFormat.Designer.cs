namespace AccountingPR.System_Settings
{
    partial class frmConnectionFormat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtSeverName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع الاتصال:";
            // 
            // txtMode
            // 
            this.txtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.Location = new System.Drawing.Point(154, 22);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(493, 30);
            this.txtMode.TabIndex = 0;
            // 
            // txtSeverName
            // 
            this.txtSeverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeverName.Location = new System.Drawing.Point(154, 73);
            this.txtSeverName.Name = "txtSeverName";
            this.txtSeverName.Size = new System.Drawing.Size(493, 30);
            this.txtSeverName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "اسم السرفر:";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataBase.Location = new System.Drawing.Point(154, 124);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(493, 30);
            this.txtDataBase.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "قاعدة البيانات: ";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(154, 179);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(493, 30);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(23, 179);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(115, 25);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.Text = "اسم المستخدم:";
            this.txtUserName.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(154, 241);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(493, 30);
            this.textBox5.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(23, 241);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(113, 25);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "كلمة المرور: ";
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNew.ForeColor = System.Drawing.Color.Blue;
            this.btnNew.Location = new System.Drawing.Point(53, 308);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(121, 37);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "جديد ";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(210, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 37);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "حفظ ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnShow.ForeColor = System.Drawing.Color.Blue;
            this.btnShow.Location = new System.Drawing.Point(367, 308);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(121, 37);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "عرض ";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(524, 308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 37);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "خروج ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConnectionFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 373);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeverName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionFormat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تهئية الاتصال بقاعدة البيانات";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtSeverName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClose;
    }
}