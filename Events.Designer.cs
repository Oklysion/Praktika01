namespace Praktika01Uvarov
{
    partial class Events
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
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtDate = new DateTimePicker();
            txtKratko = new TextBox();
            txtOsn = new TextBox();
            txtMesto = new TextBox();
            EventNameCB = new ComboBox();
            label6 = new Label();
            NameCB = new ComboBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 458);
            button2.Name = "button2";
            button2.Size = new Size(160, 40);
            button2.TabIndex = 4;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(182, 458);
            button1.Name = "button1";
            button1.Size = new Size(160, 40);
            button1.TabIndex = 5;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(111, 17);
            label1.TabIndex = 6;
            label1.Text = "Название группы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(12, 140);
            label2.Name = "label2";
            label2.Size = new Size(122, 17);
            label2.TabIndex = 7;
            label2.Text = "Место проведения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(12, 197);
            label3.Name = "label3";
            label3.Size = new Size(131, 17);
            label3.TabIndex = 8;
            label3.Text = "Основные участники";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(12, 261);
            label4.Name = "label4";
            label4.Size = new Size(218, 17);
            label4.TabIndex = 9;
            label4.Text = "Краткое содержание мероприятия";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(11, 385);
            label5.Name = "label5";
            label5.Size = new Size(112, 17);
            label5.TabIndex = 10;
            label5.Text = "Дата проведения";
            // 
            // dtDate
            // 
            dtDate.Location = new Point(12, 405);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(330, 23);
            dtDate.TabIndex = 11;
            // 
            // txtKratko
            // 
            txtKratko.Location = new Point(12, 281);
            txtKratko.Multiline = true;
            txtKratko.Name = "txtKratko";
            txtKratko.PlaceholderText = "Краткое содержание мероприятия";
            txtKratko.Size = new Size(330, 85);
            txtKratko.TabIndex = 12;
            // 
            // txtOsn
            // 
            txtOsn.Location = new Point(12, 217);
            txtOsn.Name = "txtOsn";
            txtOsn.PlaceholderText = "Основные участники";
            txtOsn.Size = new Size(330, 23);
            txtOsn.TabIndex = 13;
            // 
            // txtMesto
            // 
            txtMesto.Location = new Point(12, 160);
            txtMesto.Name = "txtMesto";
            txtMesto.PlaceholderText = "Место проведения";
            txtMesto.Size = new Size(330, 23);
            txtMesto.TabIndex = 14;
            // 
            // EventNameCB
            // 
            EventNameCB.FormattingEnabled = true;
            EventNameCB.Location = new Point(12, 96);
            EventNameCB.Name = "EventNameCB";
            EventNameCB.Size = new Size(330, 23);
            EventNameCB.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(149, 17);
            label6.TabIndex = 16;
            label6.Text = "Название мероприятия";
            // 
            // NameCB
            // 
            NameCB.FormattingEnabled = true;
            NameCB.Location = new Point(13, 29);
            NameCB.Name = "NameCB";
            NameCB.Size = new Size(329, 23);
            NameCB.TabIndex = 17;
            // 
            // Events
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(354, 510);
            Controls.Add(NameCB);
            Controls.Add(label6);
            Controls.Add(EventNameCB);
            Controls.Add(txtMesto);
            Controls.Add(txtOsn);
            Controls.Add(txtKratko);
            Controls.Add(dtDate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Events";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Мероприятия";
            Load += Events_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public DateTimePicker dtDate;
        public TextBox txtKratko;
        public TextBox txtOsn;
        public TextBox txtMesto;
        public ComboBox EventNameCB;
        private Label label6;
        public ComboBox NameCB;
    }
}