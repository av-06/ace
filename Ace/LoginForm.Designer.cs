namespace Main_System
{
    partial class LoginForm
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
            txtUsername = new Label();
            txtPassword = new Label();
            boxUsername = new TextBox();
            boxPassword = new TextBox();
            checkboxTeacher = new CheckBox();
            checkboxStudent = new CheckBox();
            txtIAm = new Label();
            btnLogin = new Button();
            txtLoginHeader = new Label();
            txtNoAccount = new Label();
            linktxtSignUp = new LinkLabel();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.AutoSize = true;
            txtUsername.Location = new Point(31, 81);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(95, 25);
            txtUsername.TabIndex = 0;
            txtUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.Location = new Point(31, 139);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(91, 25);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "Password:";
            // 
            // boxUsername
            // 
            boxUsername.Location = new Point(132, 81);
            boxUsername.Name = "boxUsername";
            boxUsername.Size = new Size(483, 31);
            boxUsername.TabIndex = 2;
            // 
            // boxPassword
            // 
            boxPassword.Location = new Point(132, 139);
            boxPassword.Name = "boxPassword";
            boxPassword.Size = new Size(483, 31);
            boxPassword.TabIndex = 3;
            // 
            // checkboxTeacher
            // 
            checkboxTeacher.AutoSize = true;
            checkboxTeacher.Location = new Point(396, 189);
            checkboxTeacher.Name = "checkboxTeacher";
            checkboxTeacher.Size = new Size(96, 29);
            checkboxTeacher.TabIndex = 4;
            checkboxTeacher.Text = "Teacher";
            checkboxTeacher.UseVisualStyleBackColor = true;
            checkboxTeacher.CheckedChanged += checkboxTeacher_CheckedChanged;
            // 
            // checkboxStudent
            // 
            checkboxStudent.AutoSize = true;
            checkboxStudent.Location = new Point(516, 189);
            checkboxStudent.Name = "checkboxStudent";
            checkboxStudent.Size = new Size(99, 29);
            checkboxStudent.TabIndex = 5;
            checkboxStudent.Text = "Student";
            checkboxStudent.UseVisualStyleBackColor = true;
            checkboxStudent.CheckedChanged += checkboxStudent_CheckedChanged;
            // 
            // txtIAm
            // 
            txtIAm.AutoSize = true;
            txtIAm.Location = new Point(281, 190);
            txtIAm.Name = "txtIAm";
            txtIAm.Size = new Size(65, 25);
            txtIAm.TabIndex = 6;
            txtIAm.Text = "I am a:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(31, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(584, 60);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLoginHeader
            // 
            txtLoginHeader.AutoSize = true;
            txtLoginHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtLoginHeader.Location = new Point(23, 9);
            txtLoginHeader.Name = "txtLoginHeader";
            txtLoginHeader.Size = new Size(127, 54);
            txtLoginHeader.TabIndex = 8;
            txtLoginHeader.Text = "Login";
            // 
            // txtNoAccount
            // 
            txtNoAccount.AutoSize = true;
            txtNoAccount.Location = new Point(31, 382);
            txtNoAccount.Name = "txtNoAccount";
            txtNoAccount.Size = new Size(197, 25);
            txtNoAccount.TabIndex = 9;
            txtNoAccount.Text = "Don't have an account?";
            // 
            // linktxtSignUp
            // 
            linktxtSignUp.AutoSize = true;
            linktxtSignUp.Location = new Point(234, 382);
            linktxtSignUp.Name = "linktxtSignUp";
            linktxtSignUp.Size = new Size(78, 25);
            linktxtSignUp.TabIndex = 10;
            linktxtSignUp.TabStop = true;
            linktxtSignUp.Text = "Sign up!";
            linktxtSignUp.LinkClicked += linktxtSignUp_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 460);
            Controls.Add(linktxtSignUp);
            Controls.Add(txtNoAccount);
            Controls.Add(txtLoginHeader);
            Controls.Add(btnLogin);
            Controls.Add(txtIAm);
            Controls.Add(checkboxStudent);
            Controls.Add(checkboxTeacher);
            Controls.Add(boxPassword);
            Controls.Add(boxUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtUsername;
        private Label txtPassword;
        private TextBox boxUsername;
        private TextBox boxPassword;
        private CheckBox checkboxTeacher;
        private CheckBox checkboxStudent;
        private Label txtIAm;
        private Button btnLogin;
        private Label txtLoginHeader;
        private Label txtNoAccount;
        private LinkLabel linktxtSignUp;
    }
}