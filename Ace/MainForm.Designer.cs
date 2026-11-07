namespace Main_System
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridDecks = new DataGridView();
            btnAddCard = new Button();
            btnBrowseCards = new Button();
            btnCreateDeck = new Button();
            btnShareDecks = new Button();
            btnReceiveDecks = new Button();
            btnManageStudents = new Button();
            btnDeleteSelectedDecks = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridDecks).BeginInit();
            SuspendLayout();
            // 
            // dataGridDecks
            // 
            dataGridDecks.AllowUserToAddRows = false;
            dataGridDecks.AllowUserToDeleteRows = false;
            dataGridDecks.AllowUserToResizeColumns = false;
            dataGridDecks.AllowUserToResizeRows = false;
            dataGridDecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridDecks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDecks.Location = new Point(31, 139);
            dataGridDecks.Name = "dataGridDecks";
            dataGridDecks.RowHeadersWidth = 62;
            dataGridDecks.Size = new Size(746, 225);
            dataGridDecks.TabIndex = 0;
            dataGridDecks.CellDoubleClick += dataGridDecks_CellDoubleClick;
            // 
            // btnAddCard
            // 
            btnAddCard.Location = new Point(12, 388);
            btnAddCard.Name = "btnAddCard";
            btnAddCard.Size = new Size(315, 34);
            btnAddCard.TabIndex = 1;
            btnAddCard.Text = "Add Card";
            btnAddCard.UseVisualStyleBackColor = true;
            btnAddCard.Click += btnAddCard_Click;
            // 
            // btnBrowseCards
            // 
            btnBrowseCards.Location = new Point(501, 388);
            btnBrowseCards.Name = "btnBrowseCards";
            btnBrowseCards.Size = new Size(287, 34);
            btnBrowseCards.TabIndex = 2;
            btnBrowseCards.Text = "Browse cards";
            btnBrowseCards.UseVisualStyleBackColor = true;
            btnBrowseCards.Click += btnBrowseCards_Click;
            // 
            // btnCreateDeck
            // 
            btnCreateDeck.Location = new Point(333, 388);
            btnCreateDeck.Name = "btnCreateDeck";
            btnCreateDeck.Size = new Size(162, 34);
            btnCreateDeck.TabIndex = 3;
            btnCreateDeck.Text = "Create Deck";
            btnCreateDeck.UseVisualStyleBackColor = true;
            btnCreateDeck.Click += btnCreateDeck_Click;
            // 
            // btnShareDecks
            // 
            btnShareDecks.Location = new Point(312, 23);
            btnShareDecks.Name = "btnShareDecks";
            btnShareDecks.Size = new Size(148, 101);
            btnShareDecks.TabIndex = 4;
            btnShareDecks.Text = "Share Decks";
            btnShareDecks.UseVisualStyleBackColor = true;
            btnShareDecks.Click += btnShareDecks_Click;
            // 
            // btnReceiveDecks
            // 
            btnReceiveDecks.Location = new Point(178, 23);
            btnReceiveDecks.Name = "btnReceiveDecks";
            btnReceiveDecks.Size = new Size(128, 101);
            btnReceiveDecks.TabIndex = 5;
            btnReceiveDecks.Text = "Receive Decks";
            btnReceiveDecks.UseVisualStyleBackColor = true;
            btnReceiveDecks.Click += btnReceiveDecks_Click;
            // 
            // btnManageStudents
            // 
            btnManageStudents.Location = new Point(31, 23);
            btnManageStudents.Name = "btnManageStudents";
            btnManageStudents.Size = new Size(141, 101);
            btnManageStudents.TabIndex = 6;
            btnManageStudents.Text = "Manage Students";
            btnManageStudents.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelectedDecks
            // 
            btnDeleteSelectedDecks.Location = new Point(478, 23);
            btnDeleteSelectedDecks.Name = "btnDeleteSelectedDecks";
            btnDeleteSelectedDecks.Size = new Size(299, 101);
            btnDeleteSelectedDecks.TabIndex = 7;
            btnDeleteSelectedDecks.Text = "Delete selected decks";
            btnDeleteSelectedDecks.UseVisualStyleBackColor = true;
            btnDeleteSelectedDecks.Click += btnDeleteSelectedDecks_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteSelectedDecks);
            Controls.Add(btnManageStudents);
            Controls.Add(btnReceiveDecks);
            Controls.Add(btnShareDecks);
            Controls.Add(btnCreateDeck);
            Controls.Add(btnBrowseCards);
            Controls.Add(btnAddCard);
            Controls.Add(dataGridDecks);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridDecks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridDecks;
        private Button btnAddCard;
        private Button btnBrowseCards;
        private Button btnCreateDeck;
        private Button btnShareDecks;
        private Button btnReceiveDecks;
        private Button btnManageStudents;
        private Button btnDeleteSelectedDecks;
    }
}