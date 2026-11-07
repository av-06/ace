namespace Main_System
{
    partial class DeckReceiverForm
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
            listBoxDecks = new ListBox();
            btnAccept = new Button();
            btnReject = new Button();
            txtSenderHeader = new Label();
            boxSender = new TextBox();
            boxDescription = new TextBox();
            txtDescriptionHeader = new Label();
            SuspendLayout();
            // 
            // listBoxDecks
            // 
            listBoxDecks.FormattingEnabled = true;
            listBoxDecks.ItemHeight = 25;
            listBoxDecks.Location = new Point(12, 36);
            listBoxDecks.Name = "listBoxDecks";
            listBoxDecks.SelectionMode = SelectionMode.MultiSimple;
            listBoxDecks.Size = new Size(219, 379);
            listBoxDecks.TabIndex = 2;
            listBoxDecks.SelectedIndexChanged += listBoxDecks_SelectedIndexChanged;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(257, 315);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(243, 64);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(537, 315);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(231, 64);
            btnReject.TabIndex = 4;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // txtSenderHeader
            // 
            txtSenderHeader.AutoSize = true;
            txtSenderHeader.Location = new Point(257, 36);
            txtSenderHeader.Name = "txtSenderHeader";
            txtSenderHeader.Size = new Size(71, 25);
            txtSenderHeader.TabIndex = 5;
            txtSenderHeader.Text = "Sender:";
            // 
            // boxSender
            // 
            boxSender.Location = new Point(334, 36);
            boxSender.Name = "boxSender";
            boxSender.ReadOnly = true;
            boxSender.Size = new Size(434, 31);
            boxSender.TabIndex = 6;
            // 
            // boxDescription
            // 
            boxDescription.Location = new Point(257, 115);
            boxDescription.Multiline = true;
            boxDescription.Name = "boxDescription";
            boxDescription.ReadOnly = true;
            boxDescription.Size = new Size(511, 179);
            boxDescription.TabIndex = 7;
            // 
            // txtDescriptionHeader
            // 
            txtDescriptionHeader.AutoSize = true;
            txtDescriptionHeader.Location = new Point(257, 87);
            txtDescriptionHeader.Name = "txtDescriptionHeader";
            txtDescriptionHeader.Size = new Size(148, 25);
            txtDescriptionHeader.TabIndex = 8;
            txtDescriptionHeader.Text = "Deck description:";
            // 
            // DeckReceiverForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDescriptionHeader);
            Controls.Add(boxDescription);
            Controls.Add(boxSender);
            Controls.Add(txtSenderHeader);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(listBoxDecks);
            Name = "DeckReceiverForm";
            Text = "DeckReceiverForm";
            Load += DeckReceiverForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxDecks;
        private ListBox listBoxDecks;
        private Button btnAccept;
        private Button btnReject;
        private Label txtSenderHeader;
        private TextBox boxSender;
        private TextBox boxDescription;
        private Label txtDescriptionHeader;
    }
}