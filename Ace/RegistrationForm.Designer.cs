namespace Main_System
{
    partial class RegistrationForm
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
            txtLoginHeader = new Label();
            btnSignUp = new Button();
            txtIAm = new Label();
            checkboxStudent = new CheckBox();
            checkboxTeacher = new CheckBox();
            boxPassword = new TextBox();
            boxUsername = new TextBox();
            txtPassword = new Label();
            txtUsername = new Label();
            txtUsernameLength = new Label();
            txtPasswordLength = new Label();
            SuspendLayout();
            // 
            // txtLoginHeader
            // 
            txtLoginHeader.AutoSize = true;
            txtLoginHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtLoginHeader.Location = new Point(12, 9);
            txtLoginHeader.Name = "txtLoginHeader";
            txtLoginHeader.Size = new Size(170, 54);
            txtLoginHeader.TabIndex = 19;
            txtLoginHeader.Text = "Sign Up";
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(12, 246);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(584, 60);
            btnSignUp.TabIndex = 18;
            btnSignUp.Text = "Sign up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtIAm
            // 
            txtIAm.AutoSize = true;
            txtIAm.Location = new Point(262, 186);
            txtIAm.Name = "txtIAm";
            txtIAm.Size = new Size(65, 25);
            txtIAm.TabIndex = 17;
            txtIAm.Text = "I am a:";
            // 
            // checkboxStudent
            // 
            checkboxStudent.AutoSize = true;
            checkboxStudent.Location = new Point(497, 185);
            checkboxStudent.Name = "checkboxStudent";
            checkboxStudent.Size = new Size(99, 29);
            checkboxStudent.TabIndex = 16;
            checkboxStudent.Text = "Student";
            checkboxStudent.UseVisualStyleBackColor = true;
            checkboxStudent.CheckedChanged += checkboxStudent_CheckedChanged;
            // 
            // checkboxTeacher
            // 
            checkboxTeacher.AutoSize = true;
            checkboxTeacher.Location = new Point(377, 185);
            checkboxTeacher.Name = "checkboxTeacher";
            checkboxTeacher.Size = new Size(96, 29);
            checkboxTeacher.TabIndex = 15;
            checkboxTeacher.Text = "Teacher";
            checkboxTeacher.UseVisualStyleBackColor = true;
            checkboxTeacher.CheckedChanged += checkboxTeacher_CheckedChanged;
            // 
            // boxPassword
            // 
            boxPassword.Location = new Point(121, 139);
            boxPassword.Name = "boxPassword";
            boxPassword.Size = new Size(483, 31);
            boxPassword.TabIndex = 14;
            boxPassword.TextChanged += boxPassword_TextChanged;
            // 
            // boxUsername
            // 
            boxUsername.Location = new Point(121, 81);
            boxUsername.Name = "boxUsername";
            boxUsername.Size = new Size(483, 31);
            boxUsername.TabIndex = 13;
            boxUsername.TextChanged += boxUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.Location = new Point(20, 139);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(91, 25);
            txtPassword.TabIndex = 12;
            txtPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.AutoSize = true;
            txtUsername.Location = new Point(20, 81);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(95, 25);
            txtUsername.TabIndex = 11;
            txtUsername.Text = "Username:";
            // 
            // txtUsernameLength
            // 
            txtUsernameLength.AutoSize = true;
            txtUsernameLength.Location = new Point(610, 81);
            txtUsernameLength.Name = "txtUsernameLength";
            txtUsernameLength.Size = new Size(59, 25);
            txtUsernameLength.TabIndex = 20;
            txtUsernameLength.Text = "0 / 30";
            // 
            // txtPasswordLength
            // 
            txtPasswordLength.AutoSize = true;
            txtPasswordLength.Location = new Point(610, 139);
            txtPasswordLength.Name = "txtPasswordLength";
            txtPasswordLength.Size = new Size(59, 25);
            txtPasswordLength.TabIndex = 21;
            txtPasswordLength.Text = "0 / 30";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 355);
            Controls.Add(txtPasswordLength);
            Controls.Add(txtUsernameLength);
            Controls.Add(txtLoginHeader);
            Controls.Add(btnSignUp);
            Controls.Add(txtIAm);
            Controls.Add(checkboxStudent);
            Controls.Add(checkboxTeacher);
            Controls.Add(boxPassword);
            Controls.Add(boxUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "RegistrationForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtLoginHeader;
        private Button btnSignUp;
        private Label txtIAm;
        private CheckBox checkboxStudent;
        private CheckBox checkboxTeacher;
        private TextBox boxPassword;
        private TextBox boxUsername;
        private Label txtPassword;
        private Label txtUsername;
        private Label txtUsernameLength;
        private Label txtPasswordLength;
    }
}