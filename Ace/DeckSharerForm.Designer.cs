namespace Main_System
{
    partial class DeckSharerForm
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
            txtShareDecksHeader = new Label();
            listBoxDecks = new ListBox();
            txtWith = new Label();
            listBoxTeachers = new ListBox();
            txtUserSelectionHeader = new Label();
            listBoxStudents = new ListBox();
            txtTeachers = new Label();
            txtStudents = new Label();
            btnShare = new Button();
            SuspendLayout();
            // 
            // txtShareDecksHeader
            // 
            txtShareDecksHeader.AutoSize = true;
            txtShareDecksHeader.Location = new Point(12, 9);
            txtShareDecksHeader.Name = "txtShareDecksHeader";
            txtShareDecksHeader.Size = new Size(219, 25);
            txtShareDecksHeader.TabIndex = 0;
            txtShareDecksHeader.Text = "Share the following decks:";
            // 
            // listBoxDecks
            // 
            listBoxDecks.FormattingEnabled = true;
            listBoxDecks.ItemHeight = 25;
            listBoxDecks.Location = new Point(12, 37);
            listBoxDecks.Name = "listBoxDecks";
            listBoxDecks.SelectionMode = SelectionMode.MultiSimple;
            listBoxDecks.Size = new Size(219, 379);
            listBoxDecks.TabIndex = 1;
            // 
            // txtWith
            // 
            txtWith.AutoSize = true;
            txtWith.Location = new Point(256, 199);
            txtWith.Name = "txtWith";
            txtWith.Size = new Size(45, 25);
            txtWith.TabIndex = 2;
            txtWith.Text = "with";
            // 
            // listBoxTeachers
            // 
            listBoxTeachers.FormattingEnabled = true;
            listBoxTeachers.ItemHeight = 25;
            listBoxTeachers.Location = new Point(322, 87);
            listBoxTeachers.Name = "listBoxTeachers";
            listBoxTeachers.SelectionMode = SelectionMode.MultiSimple;
            listBoxTeachers.Size = new Size(207, 329);
            listBoxTeachers.TabIndex = 3;
            // 
            // txtUserSelectionHeader
            // 
            txtUserSelectionHeader.AutoSize = true;
            txtUserSelectionHeader.Location = new Point(322, 9);
            txtUserSelectionHeader.Name = "txtUserSelectionHeader";
            txtUserSelectionHeader.Size = new Size(166, 25);
            txtUserSelectionHeader.TabIndex = 4;
            txtUserSelectionHeader.Text = "the following users:";
            // 
            // listBoxStudents
            // 
            listBoxStudents.FormattingEnabled = true;
            listBoxStudents.ItemHeight = 25;
            listBoxStudents.Location = new Point(585, 87);
            listBoxStudents.Name = "listBoxStudents";
            listBoxStudents.SelectionMode = SelectionMode.MultiSimple;
            listBoxStudents.Size = new Size(207, 329);
            listBoxStudents.TabIndex = 5;
            // 
            // txtTeachers
            // 
            txtTeachers.AutoSize = true;
            txtTeachers.Location = new Point(322, 48);
            txtTeachers.Name = "txtTeachers";
            txtTeachers.Size = new Size(82, 25);
            txtTeachers.TabIndex = 6;
            txtTeachers.Text = "Teachers:";
            // 
            // txtStudents
            // 
            txtStudents.AutoSize = true;
            txtStudents.Location = new Point(585, 48);
            txtStudents.Name = "txtStudents";
            txtStudents.Size = new Size(85, 25);
            txtStudents.TabIndex = 7;
            txtStudents.Text = "Students:";
            // 
            // btnShare
            // 
            btnShare.Location = new Point(520, 443);
            btnShare.Name = "btnShare";
            btnShare.Size = new Size(272, 87);
            btnShare.TabIndex = 8;
            btnShare.Text = "Share decks";
            btnShare.UseVisualStyleBackColor = true;
            btnShare.Click += btnShare_Click;
            // 
            // DeckSharerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 558);
            Controls.Add(btnShare);
            Controls.Add(txtStudents);
            Controls.Add(txtTeachers);
            Controls.Add(listBoxStudents);
            Controls.Add(txtUserSelectionHeader);
            Controls.Add(listBoxTeachers);
            Controls.Add(txtWith);
            Controls.Add(listBoxDecks);
            Controls.Add(txtShareDecksHeader);
            Name = "DeckSharerForm";
            Text = "DeckSharerForm";
            Load += DeckSharerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtShareDecksHeader;
        private ListBox listBoxDecks;
        private Label txtWith;
        private ListBox listBoxTeachers;
        private Label txtUserSelectionHeader;
        private ListBox listBoxStudents;
        private Label txtTeachers;
        private Label txtStudents;
        private Button btnShare;
    }
}