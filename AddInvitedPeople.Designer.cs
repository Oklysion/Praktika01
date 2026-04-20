namespace Praktika01Uvarov
{
    partial class AddInvitedPeople
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
            txtFIO = new TextBox();
            txtPost = new TextBox();
            txtOrgName = new TextBox();
            label4 = new Label();
            EventsCB = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(182, 265);
            button1.Name = "button1";
            button1.Size = new Size(160, 40);
            button1.TabIndex = 0;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 265);
            button2.Name = "button2";
            button2.Size = new Size(160, 40);
            button2.TabIndex = 1;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(41, 17);
            label1.TabIndex = 2;
            label1.Text = "ФИО ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(74, 17);
            label2.TabIndex = 3;
            label2.Text = "Должность";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 135);
            label3.Name = "label3";
            label3.Size = new Size(145, 17);
            label3.TabIndex = 4;
            label3.Text = "Название организации";
            // 
            // txtFIO
            // 
            txtFIO.Location = new Point(12, 38);
            txtFIO.Name = "txtFIO";
            txtFIO.Size = new Size(330, 23);
            txtFIO.TabIndex = 5;
            // 
            // txtPost
            // 
            txtPost.Location = new Point(12, 97);
            txtPost.Name = "txtPost";
            txtPost.Size = new Size(330, 23);
            txtPost.TabIndex = 6;
            // 
            // txtOrgName
            // 
            txtOrgName.Location = new Point(12, 155);
            txtOrgName.Name = "txtOrgName";
            txtOrgName.Size = new Size(330, 23);
            txtOrgName.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 195);
            label4.Name = "label4";
            label4.Size = new Size(91, 17);
            label4.TabIndex = 8;
            label4.Text = "Мероприятие";
            // 
            // EventsCB
            // 
            EventsCB.FormattingEnabled = true;
            EventsCB.Location = new Point(12, 215);
            EventsCB.Name = "EventsCB";
            EventsCB.Size = new Size(330, 23);
            EventsCB.TabIndex = 9;
            // 
            // AddInvitedPeople
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(354, 317);
            Controls.Add(EventsCB);
            Controls.Add(label4);
            Controls.Add(txtOrgName);
            Controls.Add(txtPost);
            Controls.Add(txtFIO);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddInvitedPeople";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Приглашённые участники";
            Load += AddInvitedPeople_Load;
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
        public ComboBox EventsCB;
        public TextBox txtFIO;
        public TextBox txtPost;
        public TextBox txtOrgName;
    }
}