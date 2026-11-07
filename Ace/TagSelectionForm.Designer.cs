namespace Main_System
{
    partial class TagSelectionForm
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
            txtTags = new Label();
            listBoxTags = new ListBox();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // txtTags
            // 
            txtTags.AutoSize = true;
            txtTags.Location = new Point(23, 9);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(51, 25);
            txtTags.TabIndex = 0;
            txtTags.Text = "Tags:";
            // 
            // listBoxTags
            // 
            listBoxTags.FormattingEnabled = true;
            listBoxTags.ItemHeight = 25;
            listBoxTags.Location = new Point(23, 54);
            listBoxTags.Name = "listBoxTags";
            listBoxTags.SelectionMode = SelectionMode.MultiExtended;
            listBoxTags.Size = new Size(374, 329);
            listBoxTags.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(23, 404);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(374, 34);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // TagFilterSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 450);
            Controls.Add(btnSelect);
            Controls.Add(listBoxTags);
            Controls.Add(txtTags);
            Name = "TagFilterSelectionForm";
            Text = "TagFilterSelectionForm";
            Load += TagSelectionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTags;
        private ListBox listBoxTags;
        private Button btnSelect;
    }
}