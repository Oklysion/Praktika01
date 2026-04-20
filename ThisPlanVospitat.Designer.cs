namespace Praktika01Uvarov
{
    partial class ThisPlanVospitat
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNaprav = new TextBox();
            txtNazvan = new TextBox();
            txtSroki = new TextBox();
            txtFIOOtvet = new TextBox();
            label5 = new Label();
            dtTashkent = new DateTimePicker();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(182, 342);
            button1.Name = "button1";
            button1.Size = new Size(160, 40);
            button1.TabIndex = 6;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Location = new Point(12, 342);
            button2.Name = "button2";
            button2.Size = new Size(160, 40);
            button2.TabIndex = 7;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(236, 17);
            label1.TabIndex = 8;
            label1.Text = "Направление воспитательной работы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(149, 17);
            label2.TabIndex = 9;
            label2.Text = "Название мероприятия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(12, 137);
            label3.Name = "label3";
            label3.Size = new Size(121, 17);
            label3.TabIndex = 10;
            label3.Text = "Сроки проведения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(12, 204);
            label4.Name = "label4";
            label4.Size = new Size(133, 17);
            label4.TabIndex = 11;
            label4.Text = "ФИО ответственного";
            // 
            // txtNaprav
            // 
            txtNaprav.Location = new Point(12, 29);
            txtNaprav.Name = "txtNaprav";
            txtNaprav.Size = new Size(330, 23);
            txtNaprav.TabIndex = 12;
            // 
            // txtNazvan
            // 
            txtNazvan.Location = new Point(12, 92);
            txtNazvan.Name = "txtNazvan";
            txtNazvan.Size = new Size(330, 23);
            txtNazvan.TabIndex = 13;
            // 
            // txtSroki
            // 
            txtSroki.Location = new Point(12, 157);
            txtSroki.Name = "txtSroki";
            txtSroki.Size = new Size(330, 23);
            txtSroki.TabIndex = 14;
            // 
            // txtFIOOtvet
            // 
            txtFIOOtvet.Location = new Point(12, 224);
            txtFIOOtvet.Name = "txtFIOOtvet";
            txtFIOOtvet.Size = new Size(330, 23);
            txtFIOOtvet.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(112, 17);
            label5.TabIndex = 16;
            label5.Text = "Дата проведения";
            // 
            // dtTashkent
            // 
            dtTashkent.Location = new Point(12, 289);
            dtTashkent.Name = "dtTashkent";
            dtTashkent.Size = new Size(330, 23);
            dtTashkent.TabIndex = 17;
            // 
            // ThisPlanVospitat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(354, 394);
            Controls.Add(dtTashkent);
            Controls.Add(label5);
            Controls.Add(txtFIOOtvet);
            Controls.Add(txtSroki);
            Controls.Add(txtNazvan);
            Controls.Add(txtNaprav);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ThisPlanVospitat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "План воспитательной работы";
            Load += ThisPlanVospitat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public TextBox txtNaprav;
        public TextBox txtNazvan;
        public TextBox txtSroki;
        public TextBox txtFIOOtvet;
        public DateTimePicker dtTashkent;
    }
}