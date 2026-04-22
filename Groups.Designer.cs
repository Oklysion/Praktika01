namespace Praktika01Uvarov
{
    partial class Groups
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
            txtFIO = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtNameGroup = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 128);
            button2.Name = "button2";
            button2.Size = new Size(160, 40);
            button2.TabIndex = 3;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(182, 128);
            button1.Name = "button1";
            button1.Size = new Size(160, 40);
            button1.TabIndex = 2;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtFIO
            // 
            txtFIO.Location = new Point(12, 29);
            txtFIO.Name = "txtFIO";
            txtFIO.PlaceholderText = "Фамилия Имя Отчество куратора*";
            txtFIO.Size = new Size(330, 23);
            txtFIO.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 17);
            label1.TabIndex = 5;
            label1.Text = "ФИО куратора";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(111, 17);
            label2.TabIndex = 6;
            label2.Text = "Название группы";
            // 
            // txtNameGroup
            // 
            txtNameGroup.Location = new Point(12, 90);
            txtNameGroup.Name = "txtNameGroup";
            txtNameGroup.PlaceholderText = "Название группы*";
            txtNameGroup.Size = new Size(330, 23);
            txtNameGroup.TabIndex = 7;
            // 
            // Groups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(354, 180);
            Controls.Add(txtNameGroup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFIO);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Groups";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Группы";
            Load += Groups_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label1;
        private Label label2;
        public TextBox txtFIO;
        public TextBox txtNameGroup;
    }
}