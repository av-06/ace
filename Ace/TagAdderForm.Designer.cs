namespace Main_System
{
    partial class TagAdderForm
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
            txtOr = new Label();
            boxNewTag = new TextBox();
            listBoxTags = new ListBox();
            txtAddTagsHeader = new Label();
            txtNewTagHeader = new Label();
            btnApplySelectedTags = new Button();
            btnAddNewTag = new Button();
            txtCharLimit = new Label();
            SuspendLayout();
            // 
            // txtOr
            // 
            txtOr.AutoSize = true;
            txtOr.Font = new Font("Segoe UI", 16F);
            txtOr.Location = new Point(257, 142);
            txtOr.Name = "txtOr";
            txtOr.Size = new Size(55, 45);
            txtOr.TabIndex = 0;
            txtOr.Text = "Or";
            // 
            // boxNewTag
            // 
            boxNewTag.Location = new Point(380, 240);
            boxNewTag.Multiline = true;
            boxNewTag.Name = "boxNewTag";
            boxNewTag.ScrollBars = ScrollBars.Both;
            boxNewTag.Size = new Size(391, 126);
            boxNewTag.TabIndex = 1;
            // 
            // listBoxTags
            // 
            listBoxTags.FormattingEnabled = true;
            listBoxTags.ItemHeight = 25;
            listBoxTags.Location = new Point(22, 60);
            listBoxTags.Name = "listBoxTags";
            listBoxTags.SelectionMode = SelectionMode.MultiSimple;
            listBoxTags.Size = new Size(198, 379);
            listBoxTags.TabIndex = 2;
            // 
            // txtAddTagsHeader
            // 
            txtAddTagsHeader.AutoSize = true;
            txtAddTagsHeader.Location = new Point(22, 23);
            txtAddTagsHeader.Name = "txtAddTagsHeader";
            txtAddTagsHeader.Size = new Size(198, 25);
            txtAddTagsHeader.TabIndex = 3;
            txtAddTagsHeader.Text = "Add the following tags:";
            // 
            // txtNewTagHeader
            // 
            txtNewTagHeader.AutoSize = true;
            txtNewTagHeader.Location = new Point(380, 162);
            txtNewTagHeader.Name = "txtNewTagHeader";
            txtNewTagHeader.Size = new Size(277, 25);
            txtNewTagHeader.TabIndex = 4;
            txtNewTagHeader.Text = "Add a new tag(s) to tag selection:";
            // 
            // btnApplySelectedTags
            // 
            btnApplySelectedTags.Location = new Point(240, 12);
            btnApplySelectedTags.Name = "btnApplySelectedTags";
            btnApplySelectedTags.Size = new Size(531, 94);
            btnApplySelectedTags.TabIndex = 5;
            btnApplySelectedTags.Text = "Apply selected tags";
            btnApplySelectedTags.UseVisualStyleBackColor = true;
            btnApplySelectedTags.Click += btnApplySelectedTags_Click;
            // 
            // btnAddNewTag
            // 
            btnAddNewTag.Location = new Point(393, 386);
            btnAddNewTag.Name = "btnAddNewTag";
            btnAddNewTag.Size = new Size(361, 55);
            btnAddNewTag.TabIndex = 6;
            btnAddNewTag.Text = "Add new tag";
            btnAddNewTag.UseVisualStyleBackColor = true;
            btnAddNewTag.Click += btnAddNewTag_Click;
            // 
            // txtCharLimit
            // 
            txtCharLimit.AutoSize = true;
            txtCharLimit.ForeColor = SystemColors.ControlDarkDark;
            txtCharLimit.Location = new Point(380, 187);
            txtCharLimit.Name = "txtCharLimit";
            txtCharLimit.Size = new Size(220, 50);
            txtCharLimit.TabIndex = 7;
            txtCharLimit.Text = "Each new line is a new tag.\r\nCharacter limit per tag: 15\r\n";
            // 
            // TagAdderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 478);
            Controls.Add(txtCharLimit);
            Controls.Add(btnAddNewTag);
            Controls.Add(btnApplySelectedTags);
            Controls.Add(txtNewTagHeader);
            Controls.Add(txtAddTagsHeader);
            Controls.Add(listBoxTags);
            Controls.Add(boxNewTag);
            Controls.Add(txtOr);
            Name = "TagAdderForm";
            Text = "TagAdderForm";
            Load += TagAdderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtOr;
        private TextBox boxNewTag;
        private ListBox listBoxTags;
        private Label txtAddTagsHeader;
        private Label txtNewTagHeader;
        private Button btnApplySelectedTags;
        private Button btnAddNewTag;
        private Label txtCharLimit;
    }
}