namespace Main_System
{
    partial class SessionForm
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
            boxCardFront = new RichTextBox();
            boxCardBack = new RichTextBox();
            btnRevealAnswer = new Button();
            btn1 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn4 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // boxCardFront
            // 
            boxCardFront.Location = new Point(12, 3);
            boxCardFront.Name = "boxCardFront";
            boxCardFront.ReadOnly = true;
            boxCardFront.Size = new Size(776, 87);
            boxCardFront.TabIndex = 0;
            boxCardFront.Text = "";
            // 
            // boxCardBack
            // 
            boxCardBack.Location = new Point(12, 96);
            boxCardBack.Name = "boxCardBack";
            boxCardBack.ReadOnly = true;
            boxCardBack.Size = new Size(776, 280);
            boxCardBack.TabIndex = 1;
            boxCardBack.Text = "";
            // 
            // btnRevealAnswer
            // 
            btnRevealAnswer.Location = new Point(533, 382);
            btnRevealAnswer.Name = "btnRevealAnswer";
            btnRevealAnswer.Size = new Size(255, 67);
            btnRevealAnswer.TabIndex = 2;
            btnRevealAnswer.Text = "Reveal Answer";
            btnRevealAnswer.UseVisualStyleBackColor = true;
            btnRevealAnswer.Click += btnRevealAnswer_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 30F);
            btn1.Location = new Point(12, 525);
            btn1.Name = "btn1";
            btn1.Size = new Size(156, 102);
            btn1.TabIndex = 3;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 30F);
            btn3.Location = new Point(423, 525);
            btn3.Name = "btn3";
            btn3.Size = new Size(156, 102);
            btn3.TabIndex = 4;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 30F);
            btn2.Location = new Point(220, 525);
            btn2.Name = "btn2";
            btn2.Size = new Size(156, 102);
            btn2.TabIndex = 5;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 30F);
            btn4.Location = new Point(619, 525);
            btn4.Name = "btn4";
            btn4.Size = new Size(156, 102);
            btn4.TabIndex = 6;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 394);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 8;
            label2.Text = "Cards completed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 394);
            label3.Name = "label3";
            label3.Size = new Size(22, 25);
            label3.TabIndex = 9;
            label3.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 424);
            label4.Name = "label4";
            label4.Size = new Size(145, 25);
            label4.TabIndex = 10;
            label4.Text = "Cards remaining:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(173, 424);
            label5.Name = "label5";
            label5.Size = new Size(22, 25);
            label5.TabIndex = 11;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 471);
            label6.Name = "label6";
            label6.Size = new Size(58, 25);
            label6.TabIndex = 12;
            label6.Text = "[RNG]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(619, 471);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 13;
            label1.Text = "[Current Card Type]";
            // 
            // SessionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 639);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btn4);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn1);
            Controls.Add(btnRevealAnswer);
            Controls.Add(boxCardBack);
            Controls.Add(boxCardFront);
            Name = "SessionForm";
            Text = "Session";
            Load += SessionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox boxCardFront;
        private RichTextBox boxCardBack;
        private Button btnRevealAnswer;
        private Button btn1;
        private Button btn3;
        private Button btn2;
        private Button btn4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label1;
    }
}