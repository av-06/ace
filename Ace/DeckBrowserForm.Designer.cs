namespace Main_System
{
    partial class DeckBrowserForm
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
            dataGridDecks = new DataGridView();
            txtSearch = new Label();
            boxSearch = new TextBox();
            txtFilter = new Label();
            btnNew = new Button();
            btnLearning = new Button();
            btnReview = new Button();
            btnDue = new Button();
            btnTags = new Button();
            txtCardFront = new Label();
            txtBack = new Label();
            boxCardFront = new RichTextBox();
            boxCardBack = new RichTextBox();
            cmbBoxCurrentDeck = new ComboBox();
            txtCurrentDeck = new Label();
            txtOperations = new Label();
            btnDelete = new Button();
            btnTagCards = new Button();
            btnRemoveFilters = new Button();
            boxTags = new TextBox();
            txtTags = new Label();
            btnDeleteTags = new Button();
            btnRemoveTags = new Button();
            btnEditCard = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridDecks).BeginInit();
            SuspendLayout();
            // 
            // dataGridDecks
            // 
            dataGridDecks.AllowUserToDeleteRows = false;
            dataGridDecks.AllowUserToOrderColumns = true;
            dataGridDecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridDecks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDecks.Location = new Point(21, 26);
            dataGridDecks.Name = "dataGridDecks";
            dataGridDecks.ReadOnly = true;
            dataGridDecks.RowHeadersWidth = 62;
            dataGridDecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDecks.Size = new Size(565, 381);
            dataGridDecks.TabIndex = 0;
            dataGridDecks.SelectionChanged += dataGridDecks_SelectionChanged;
            // 
            // txtSearch
            // 
            txtSearch.AutoSize = true;
            txtSearch.Location = new Point(21, 439);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(68, 25);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search:";
            // 
            // boxSearch
            // 
            boxSearch.Location = new Point(21, 467);
            boxSearch.Name = "boxSearch";
            boxSearch.Size = new Size(440, 31);
            boxSearch.TabIndex = 2;
            boxSearch.KeyUp += boxSearch_KeyUp;
            // 
            // txtFilter
            // 
            txtFilter.AutoSize = true;
            txtFilter.Location = new Point(566, 524);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(54, 25);
            txtFilter.TabIndex = 3;
            txtFilter.Text = "Filter:";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(626, 526);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(112, 34);
            btnNew.TabIndex = 4;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnLearning
            // 
            btnLearning.Location = new Point(744, 526);
            btnLearning.Name = "btnLearning";
            btnLearning.Size = new Size(112, 34);
            btnLearning.TabIndex = 5;
            btnLearning.Text = "Learning";
            btnLearning.UseVisualStyleBackColor = true;
            btnLearning.Click += btnLearning_Click;
            // 
            // btnReview
            // 
            btnReview.Location = new Point(862, 526);
            btnReview.Name = "btnReview";
            btnReview.Size = new Size(112, 34);
            btnReview.TabIndex = 6;
            btnReview.Text = "Review";
            btnReview.UseVisualStyleBackColor = true;
            btnReview.Click += btnReview_Click;
            // 
            // btnDue
            // 
            btnDue.Location = new Point(626, 566);
            btnDue.Name = "btnDue";
            btnDue.Size = new Size(112, 34);
            btnDue.TabIndex = 7;
            btnDue.Text = "Due";
            btnDue.UseVisualStyleBackColor = true;
            btnDue.Click += btnDue_Click;
            // 
            // btnTags
            // 
            btnTags.Location = new Point(744, 566);
            btnTags.Name = "btnTags";
            btnTags.Size = new Size(112, 34);
            btnTags.TabIndex = 9;
            btnTags.Text = "Tags";
            btnTags.UseVisualStyleBackColor = true;
            btnTags.Click += btnTags_Click;
            // 
            // txtCardFront
            // 
            txtCardFront.AutoSize = true;
            txtCardFront.Location = new Point(604, 26);
            txtCardFront.Name = "txtCardFront";
            txtCardFront.Size = new Size(58, 25);
            txtCardFront.TabIndex = 10;
            txtCardFront.Text = "Front:";
            // 
            // txtBack
            // 
            txtBack.AutoSize = true;
            txtBack.Location = new Point(604, 185);
            txtBack.Name = "txtBack";
            txtBack.Size = new Size(52, 25);
            txtBack.TabIndex = 11;
            txtBack.Text = "Back:";
            // 
            // boxCardFront
            // 
            boxCardFront.Location = new Point(604, 54);
            boxCardFront.Name = "boxCardFront";
            boxCardFront.ReadOnly = true;
            boxCardFront.Size = new Size(374, 115);
            boxCardFront.TabIndex = 12;
            boxCardFront.Text = "";
            // 
            // boxCardBack
            // 
            boxCardBack.Location = new Point(604, 213);
            boxCardBack.Name = "boxCardBack";
            boxCardBack.ReadOnly = true;
            boxCardBack.Size = new Size(374, 194);
            boxCardBack.TabIndex = 13;
            boxCardBack.Text = "";
            // 
            // cmbBoxCurrentDeck
            // 
            cmbBoxCurrentDeck.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxCurrentDeck.FormattingEnabled = true;
            cmbBoxCurrentDeck.Items.AddRange(new object[] { "All" });
            cmbBoxCurrentDeck.Location = new Point(21, 554);
            cmbBoxCurrentDeck.Name = "cmbBoxCurrentDeck";
            cmbBoxCurrentDeck.Size = new Size(182, 33);
            cmbBoxCurrentDeck.TabIndex = 14;
            cmbBoxCurrentDeck.TextChanged += cmbBoxCurrentDeck_TextChanged;
            // 
            // txtCurrentDeck
            // 
            txtCurrentDeck.AutoSize = true;
            txtCurrentDeck.Location = new Point(21, 526);
            txtCurrentDeck.Name = "txtCurrentDeck";
            txtCurrentDeck.Size = new Size(118, 25);
            txtCurrentDeck.TabIndex = 15;
            txtCurrentDeck.Text = "Current Deck:";
            // 
            // txtOperations
            // 
            txtOperations.AutoSize = true;
            txtOperations.Location = new Point(19, 604);
            txtOperations.Name = "txtOperations";
            txtOperations.Size = new Size(104, 25);
            txtOperations.TabIndex = 16;
            txtOperations.Text = "Operations:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(484, 632);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 114);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete Card(s)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnTagCards
            // 
            btnTagCards.Location = new Point(327, 632);
            btnTagCards.Name = "btnTagCards";
            btnTagCards.Size = new Size(134, 114);
            btnTagCards.TabIndex = 18;
            btnTagCards.Text = "Tag Card(s)";
            btnTagCards.UseVisualStyleBackColor = true;
            btnTagCards.Click += btnTagCards_Click;
            // 
            // btnRemoveFilters
            // 
            btnRemoveFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveFilters.Location = new Point(862, 566);
            btnRemoveFilters.Name = "btnRemoveFilters";
            btnRemoveFilters.Size = new Size(112, 84);
            btnRemoveFilters.TabIndex = 19;
            btnRemoveFilters.Text = "REMOVE FILTERS\r\n";
            btnRemoveFilters.UseVisualStyleBackColor = true;
            btnRemoveFilters.Click += btnRemoveFilters_Click;
            // 
            // boxTags
            // 
            boxTags.Location = new Point(604, 452);
            boxTags.Multiline = true;
            boxTags.Name = "boxTags";
            boxTags.ReadOnly = true;
            boxTags.Size = new Size(374, 46);
            boxTags.TabIndex = 20;
            // 
            // txtTags
            // 
            txtTags.AutoSize = true;
            txtTags.Location = new Point(605, 424);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(51, 25);
            txtTags.TabIndex = 21;
            txtTags.Text = "Tags:";
            // 
            // btnDeleteTags
            // 
            btnDeleteTags.Location = new Point(174, 632);
            btnDeleteTags.Name = "btnDeleteTags";
            btnDeleteTags.Size = new Size(134, 114);
            btnDeleteTags.TabIndex = 22;
            btnDeleteTags.Text = "Delete Tag(s)";
            btnDeleteTags.UseVisualStyleBackColor = true;
            btnDeleteTags.Click += btnDeleteTags_Click;
            // 
            // btnRemoveTags
            // 
            btnRemoveTags.Location = new Point(21, 632);
            btnRemoveTags.Name = "btnRemoveTags";
            btnRemoveTags.Size = new Size(134, 114);
            btnRemoveTags.TabIndex = 23;
            btnRemoveTags.Text = "Remove Tags";
            btnRemoveTags.UseVisualStyleBackColor = true;
            btnRemoveTags.Click += btnRemoveTags_Click;
            // 
            // btnEditCard
            // 
            btnEditCard.Location = new Point(643, 632);
            btnEditCard.Name = "btnEditCard";
            btnEditCard.Size = new Size(134, 114);
            btnEditCard.TabIndex = 24;
            btnEditCard.Text = "Edit Card";
            btnEditCard.UseVisualStyleBackColor = true;
            btnEditCard.Click += btnEditCard_Click;
            // 
            // DeckBrowserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 767);
            Controls.Add(btnEditCard);
            Controls.Add(btnRemoveTags);
            Controls.Add(btnDeleteTags);
            Controls.Add(txtTags);
            Controls.Add(boxTags);
            Controls.Add(btnRemoveFilters);
            Controls.Add(btnTagCards);
            Controls.Add(btnDelete);
            Controls.Add(txtOperations);
            Controls.Add(txtCurrentDeck);
            Controls.Add(cmbBoxCurrentDeck);
            Controls.Add(boxCardBack);
            Controls.Add(boxCardFront);
            Controls.Add(txtBack);
            Controls.Add(txtCardFront);
            Controls.Add(btnTags);
            Controls.Add(btnDue);
            Controls.Add(btnReview);
            Controls.Add(btnLearning);
            Controls.Add(btnNew);
            Controls.Add(txtFilter);
            Controls.Add(boxSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridDecks);
            Name = "DeckBrowserForm";
            Text = "DeckBrowserForm";
            Load += DeckBrowserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridDecks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridDecks;
        private Label txtSearch;
        private TextBox boxSearch;
        private Label txtFilter;
        private Button btnNew;
        private Button btnLearning;
        private Button btnReview;
        private Button btnDue;
        private Button btnTags;
        private Label txtCardFront;
        private Label txtBack;
        private RichTextBox boxCardFront;
        private RichTextBox boxCardBack;
        private ComboBox cmbBoxCurrentDeck;
        private Label txtCurrentDeck;
        private Label txtOperations;
        private Button btnDelete;
        private Button btnTagCards;
        private Button btnRemoveFilters;
        private TextBox boxTags;
        private Label txtTags;
        private Button btnDeleteTags;
        private Button btnRemoveTags;
        private Button btnEditCard;
    }
}