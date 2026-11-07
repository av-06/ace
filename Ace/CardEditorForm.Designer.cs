namespace Main_System
{
    partial class CardEditorForm
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
            btnFinishEdit = new Button();
            cmbBoxDeck = new ComboBox();
            cmbBoxCardType = new ComboBox();
            txtDeck = new Label();
            txtCardType = new Label();
            boxCardBack = new RichTextBox();
            boxCardFront = new RichTextBox();
            txtBackHeader = new Label();
            txtFrontHeader = new Label();
            SuspendLayout();
            // 
            // btnFinishEdit
            // 
            btnFinishEdit.Location = new Point(429, 430);
            btnFinishEdit.Name = "btnFinishEdit";
            btnFinishEdit.Size = new Size(365, 80);
            btnFinishEdit.TabIndex = 25;
            btnFinishEdit.Text = "Finish Edit";
            btnFinishEdit.UseVisualStyleBackColor = true;
            btnFinishEdit.Click += btnFinishEdit_Click;
            // 
            // cmbBoxDeck
            // 
            cmbBoxDeck.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDeck.FormattingEnabled = true;
            cmbBoxDeck.Location = new Point(122, 470);
            cmbBoxDeck.Name = "cmbBoxDeck";
            cmbBoxDeck.Size = new Size(182, 33);
            cmbBoxDeck.TabIndex = 23;
            // 
            // cmbBoxCardType
            // 
            cmbBoxCardType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxCardType.FormattingEnabled = true;
            cmbBoxCardType.Items.AddRange(new object[] { "Normal" });
            cmbBoxCardType.Location = new Point(122, 430);
            cmbBoxCardType.Name = "cmbBoxCardType";
            cmbBoxCardType.Size = new Size(182, 33);
            cmbBoxCardType.TabIndex = 22;
            // 
            // txtDeck
            // 
            txtDeck.AutoSize = true;
            txtDeck.Location = new Point(21, 470);
            txtDeck.Name = "txtDeck";
            txtDeck.Size = new Size(55, 25);
            txtDeck.TabIndex = 21;
            txtDeck.Text = "Deck:";
            // 
            // txtCardType
            // 
            txtCardType.AutoSize = true;
            txtCardType.Location = new Point(21, 430);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(95, 25);
            txtCardType.TabIndex = 20;
            txtCardType.Text = "Card Type:";
            // 
            // boxCardBack
            // 
            boxCardBack.Location = new Point(429, 41);
            boxCardBack.Name = "boxCardBack";
            boxCardBack.Size = new Size(365, 353);
            boxCardBack.TabIndex = 19;
            boxCardBack.Text = "";
            boxCardBack.KeyDown += boxCardBack_KeyDown;
            // 
            // boxCardFront
            // 
            boxCardFront.Location = new Point(18, 41);
            boxCardFront.Name = "boxCardFront";
            boxCardFront.Size = new Size(365, 353);
            boxCardFront.TabIndex = 18;
            boxCardFront.Text = "";
            boxCardFront.KeyDown += boxCardFront_KeyDown;
            // 
            // txtBackHeader
            // 
            txtBackHeader.AutoSize = true;
            txtBackHeader.Location = new Point(429, 13);
            txtBackHeader.Name = "txtBackHeader";
            txtBackHeader.Size = new Size(48, 25);
            txtBackHeader.TabIndex = 17;
            txtBackHeader.Text = "Back";
            // 
            // txtFrontHeader
            // 
            txtFrontHeader.AutoSize = true;
            txtFrontHeader.Location = new Point(18, 13);
            txtFrontHeader.Name = "txtFrontHeader";
            txtFrontHeader.Size = new Size(54, 25);
            txtFrontHeader.TabIndex = 16;
            txtFrontHeader.Text = "Front";
            // 
            // CardEditorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 539);
            Controls.Add(btnFinishEdit);
            Controls.Add(cmbBoxDeck);
            Controls.Add(cmbBoxCardType);
            Controls.Add(txtDeck);
            Controls.Add(txtCardType);
            Controls.Add(boxCardBack);
            Controls.Add(boxCardFront);
            Controls.Add(txtBackHeader);
            Controls.Add(txtFrontHeader);
            Name = "CardEditorForm";
            Text = "CardEditorForm";
            Load += CardEditorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnFinishEdit;
        private ComboBox cmbBoxDeck;
        private ComboBox cmbBoxCardType;
        private Label txtDeck;
        private Label txtCardType;
        private RichTextBox boxCardBack;
        private RichTextBox boxCardFront;
        private Label txtBackHeader;
        private Label txtFrontHeader;
    }
}