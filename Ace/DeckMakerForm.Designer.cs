namespace Main_System
{
    partial class DeckMakerForm
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
            txtNameHeader = new Label();
            txtDescriptionHeader = new Label();
            btnCreateDeck = new Button();
            boxDescription = new TextBox();
            boxName = new TextBox();
            SuspendLayout();
            // 
            // txtNameHeader
            // 
            txtNameHeader.AutoSize = true;
            txtNameHeader.Location = new Point(30, 19);
            txtNameHeader.Name = "txtNameHeader";
            txtNameHeader.Size = new Size(63, 25);
            txtNameHeader.TabIndex = 0;
            txtNameHeader.Text = "Name:";
            // 
            // txtDescriptionHeader
            // 
            txtDescriptionHeader.AutoSize = true;
            txtDescriptionHeader.Location = new Point(30, 112);
            txtDescriptionHeader.Name = "txtDescriptionHeader";
            txtDescriptionHeader.Size = new Size(106, 25);
            txtDescriptionHeader.TabIndex = 1;
            txtDescriptionHeader.Text = "Description:";
            // 
            // btnCreateDeck
            // 
            btnCreateDeck.Location = new Point(30, 358);
            btnCreateDeck.Name = "btnCreateDeck";
            btnCreateDeck.Size = new Size(494, 80);
            btnCreateDeck.TabIndex = 2;
            btnCreateDeck.Text = "Create Deck";
            btnCreateDeck.UseVisualStyleBackColor = true;
            btnCreateDeck.Click += btnCreateDeck_Click;
            // 
            // boxDescription
            // 
            boxDescription.Location = new Point(30, 150);
            boxDescription.Multiline = true;
            boxDescription.Name = "boxDescription";
            boxDescription.Size = new Size(494, 179);
            boxDescription.TabIndex = 3;
            // 
            // boxName
            // 
            boxName.Location = new Point(30, 63);
            boxName.Name = "boxName";
            boxName.Size = new Size(494, 31);
            boxName.TabIndex = 4;
            // 
            // DeckMakerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 486);
            Controls.Add(boxName);
            Controls.Add(boxDescription);
            Controls.Add(btnCreateDeck);
            Controls.Add(txtDescriptionHeader);
            Controls.Add(txtNameHeader);
            Name = "DeckMakerForm";
            Text = "DeckMakerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtNameHeader;
        private Label txtDescriptionHeader;
        private Button btnCreateDeck;
        private TextBox boxDescription;
        private TextBox boxName;
    }
}