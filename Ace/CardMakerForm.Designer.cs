namespace Main_System
{
    partial class CardMakerForm
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
            txtFrontHeader = new Label();
            txtBackHeader = new Label();
            boxCardFront = new RichTextBox();
            boxCardBack = new RichTextBox();
            txtCardType = new Label();
            txtDeck = new Label();
            cmbBoxCardType = new ComboBox();
            cmbBoxDeck = new ComboBox();
            txtTagsHeader = new Label();
            btnAddCard = new Button();
            listBoxTags = new ListBox();
            txtCharLimit = new Label();
            txtNewTagHeader = new Label();
            boxNewTag = new TextBox();
            SuspendLayout();
            // 
            // txtFrontHeader
            // 
            txtFrontHeader.AutoSize = true;
            txtFrontHeader.Location = new Point(12, 9);
            txtFrontHeader.Name = "txtFrontHeader";
            txtFrontHeader.Size = new Size(54, 25);
            txtFrontHeader.TabIndex = 0;
            txtFrontHeader.Text = "Front";
            // 
            // txtBackHeader
            // 
            txtBackHeader.AutoSize = true;
            txtBackHeader.Location = new Point(423, 9);
            txtBackHeader.Name = "txtBackHeader";
            txtBackHeader.Size = new Size(48, 25);
            txtBackHeader.TabIndex = 1;
            txtBackHeader.Text = "Back";
            // 
            // boxCardFront
            // 
            boxCardFront.Location = new Point(12, 37);
            boxCardFront.Name = "boxCardFront";
            boxCardFront.Size = new Size(365, 353);
            boxCardFront.TabIndex = 2;
            boxCardFront.Text = "";
            boxCardFront.KeyDown += boxCardFront_KeyDown;
            // 
            // boxCardBack
            // 
            boxCardBack.Location = new Point(423, 37);
            boxCardBack.Name = "boxCardBack";
            boxCardBack.Size = new Size(365, 353);
            boxCardBack.TabIndex = 3;
            boxCardBack.Text = "";
            boxCardBack.KeyDown += boxCardBack_KeyDown;
            // 
            // txtCardType
            // 
            txtCardType.AutoSize = true;
            txtCardType.Location = new Point(13, 409);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(95, 25);
            txtCardType.TabIndex = 4;
            txtCardType.Text = "Card Type:";
            // 
            // txtDeck
            // 
            txtDeck.AutoSize = true;
            txtDeck.Location = new Point(13, 449);
            txtDeck.Name = "txtDeck";
            txtDeck.Size = new Size(55, 25);
            txtDeck.TabIndex = 5;
            txtDeck.Text = "Deck:";
            // 
            // cmbBoxCardType
            // 
            cmbBoxCardType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxCardType.FormattingEnabled = true;
            cmbBoxCardType.Items.AddRange(new object[] { "Normal" });
            cmbBoxCardType.Location = new Point(114, 409);
            cmbBoxCardType.Name = "cmbBoxCardType";
            cmbBoxCardType.Size = new Size(182, 33);
            cmbBoxCardType.TabIndex = 6;
            // 
            // cmbBoxDeck
            // 
            cmbBoxDeck.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDeck.FormattingEnabled = true;
            cmbBoxDeck.Location = new Point(114, 449);
            cmbBoxDeck.Name = "cmbBoxDeck";
            cmbBoxDeck.Size = new Size(182, 33);
            cmbBoxDeck.TabIndex = 7;
            // 
            // txtTagsHeader
            // 
            txtTagsHeader.AutoSize = true;
            txtTagsHeader.Location = new Point(9, 498);
            txtTagsHeader.Name = "txtTagsHeader";
            txtTagsHeader.Size = new Size(51, 25);
            txtTagsHeader.TabIndex = 8;
            txtTagsHeader.Text = "Tags:";
            // 
            // btnAddCard
            // 
            btnAddCard.Location = new Point(423, 639);
            btnAddCard.Name = "btnAddCard";
            btnAddCard.Size = new Size(365, 80);
            btnAddCard.TabIndex = 10;
            btnAddCard.Text = "Add Card";
            btnAddCard.UseVisualStyleBackColor = true;
            btnAddCard.Click += btnAddCard_Click;
            // 
            // listBoxTags
            // 
            listBoxTags.FormattingEnabled = true;
            listBoxTags.ItemHeight = 25;
            listBoxTags.Location = new Point(13, 537);
            listBoxTags.Name = "listBoxTags";
            listBoxTags.SelectionMode = SelectionMode.MultiSimple;
            listBoxTags.Size = new Size(261, 254);
            listBoxTags.TabIndex = 11;
            // 
            // txtCharLimit
            // 
            txtCharLimit.AutoSize = true;
            txtCharLimit.ForeColor = SystemColors.ControlDarkDark;
            txtCharLimit.Location = new Point(397, 430);
            txtCharLimit.Name = "txtCharLimit";
            txtCharLimit.Size = new Size(220, 50);
            txtCharLimit.TabIndex = 15;
            txtCharLimit.Text = "Each new line is a new tag.\r\nCharacter limit per tag: 15\r\n";
            // 
            // txtNewTagHeader
            // 
            txtNewTagHeader.AutoSize = true;
            txtNewTagHeader.Location = new Point(397, 405);
            txtNewTagHeader.Name = "txtNewTagHeader";
            txtNewTagHeader.Size = new Size(277, 25);
            txtNewTagHeader.TabIndex = 14;
            txtNewTagHeader.Text = "Add a new tag(s) to tag selection:";
            // 
            // boxNewTag
            // 
            boxNewTag.Location = new Point(397, 483);
            boxNewTag.Multiline = true;
            boxNewTag.Name = "boxNewTag";
            boxNewTag.ScrollBars = ScrollBars.Both;
            boxNewTag.Size = new Size(391, 126);
            boxNewTag.TabIndex = 13;
            // 
            // CardMakerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 805);
            Controls.Add(txtCharLimit);
            Controls.Add(txtNewTagHeader);
            Controls.Add(boxNewTag);
            Controls.Add(listBoxTags);
            Controls.Add(btnAddCard);
            Controls.Add(txtTagsHeader);
            Controls.Add(cmbBoxDeck);
            Controls.Add(cmbBoxCardType);
            Controls.Add(txtDeck);
            Controls.Add(txtCardType);
            Controls.Add(boxCardBack);
            Controls.Add(boxCardFront);
            Controls.Add(txtBackHeader);
            Controls.Add(txtFrontHeader);
            Name = "CardMakerForm";
            Text = "CardMakerForm";
            Load += CardMakerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtFrontHeader;
        private Label txtBackHeader;
        private RichTextBox boxCardFront;
        private RichTextBox boxCardBack;
        private Label txtCardType;
        private Label txtDeck;
        private ComboBox cmbBoxCardType;
        private ComboBox cmbBoxDeck;
        private Label txtTagsHeader;
        private Button btnAddCard;
        private ListBox listBoxTags;
        private Label txtCharLimit;
        private Label txtNewTagHeader;
        private TextBox boxNewTag;
    }
}