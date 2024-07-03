namespace AccountingPR.Login
{
    partial class frmLogin
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbRememberMe = new System.Windows.Forms.CheckBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المستخدم:";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtUserName.Location = new System.Drawing.Point(137, 29);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(278, 32);
            this.txtUserName.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnLogin.Location = new System.Drawing.Point(39, 188);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(178, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "دخول";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtPassword.Location = new System.Drawing.Point(137, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 32);
            this.txtPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "كلمة المرور:";
            // 
            // chbRememberMe
            // 
            this.chbRememberMe.AutoSize = true;
            this.chbRememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.chbRememberMe.Location = new System.Drawing.Point(150, 127);
            this.chbRememberMe.Name = "chbRememberMe";
            this.chbRememberMe.Size = new System.Drawing.Size(84, 30);
            this.chbRememberMe.TabIndex = 3;
            this.chbRememberMe.Text = "تذكرني";
            this.chbRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnCancle.Location = new System.Drawing.Point(244, 188);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(171, 40);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "الغاء";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(449, 260);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.chbRememberMe);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الدخول";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbRememberMe;
        private System.Windows.Forms.Button btnCancle;
    }
}