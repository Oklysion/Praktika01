namespace Praktika01Uvarov
{
    partial class Users
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
            dataGridView1 = new DataGridView();
            id_user = new DataGridViewTextBoxColumn();
            DTLogin = new DataGridViewTextBoxColumn();
            RoleUser = new DataGridViewTextBoxColumn();
            txtLogin = new Label();
            txtPassw = new Label();
            txtRole = new Label();
            RoleCombBox = new ComboBox();
            txtPas = new TextBox();
            txtLLogin = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            txtFIO = new TextBox();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_user, DTLogin, RoleUser });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(247, 305);
            dataGridView1.TabIndex = 0;
            // 
            // id_user
            // 
            id_user.HeaderText = "id_user";
            id_user.Name = "id_user";
            id_user.ReadOnly = true;
            id_user.Visible = false;
            // 
            // DTLogin
            // 
            DTLogin.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DTLogin.HeaderText = "Логин";
            DTLogin.Name = "DTLogin";
            DTLogin.ReadOnly = true;
            // 
            // RoleUser
            // 
            RoleUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RoleUser.HeaderText = "Статус";
            RoleUser.Name = "RoleUser";
            RoleUser.ReadOnly = true;
            // 
            // txtLogin
            // 
            txtLogin.AutoSize = true;
            txtLogin.Font = new Font("Segoe UI", 9.75F);
            txtLogin.Location = new Point(265, 54);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(44, 17);
            txtLogin.TabIndex = 1;
            txtLogin.Text = "Логин";
            // 
            // txtPassw
            // 
            txtPassw.AutoSize = true;
            txtPassw.Font = new Font("Segoe UI", 9.75F);
            txtPassw.Location = new Point(265, 97);
            txtPassw.Name = "txtPassw";
            txtPassw.Size = new Size(54, 17);
            txtPassw.TabIndex = 2;
            txtPassw.Text = "Пароль";
            // 
            // txtRole
            // 
            txtRole.AutoSize = true;
            txtRole.Font = new Font("Segoe UI", 9.75F);
            txtRole.Location = new Point(265, 140);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(37, 17);
            txtRole.TabIndex = 3;
            txtRole.Text = "Роль";
            // 
            // RoleCombBox
            // 
            RoleCombBox.FormattingEnabled = true;
            RoleCombBox.Location = new Point(325, 139);
            RoleCombBox.Name = "RoleCombBox";
            RoleCombBox.Size = new Size(261, 23);
            RoleCombBox.TabIndex = 4;
            RoleCombBox.KeyPress += RoleCombBox_KeyPress;
            // 
            // txtPas
            // 
            txtPas.Location = new Point(325, 96);
            txtPas.Name = "txtPas";
            txtPas.PlaceholderText = "Пароль";
            txtPas.Size = new Size(261, 23);
            txtPas.TabIndex = 5;
            txtPas.KeyPress += txtPas_KeyPress;
            // 
            // txtLLogin
            // 
            txtLLogin.Location = new Point(325, 53);
            txtLLogin.Name = "txtLLogin";
            txtLLogin.PlaceholderText = "Логин";
            txtLLogin.Size = new Size(261, 23);
            txtLLogin.TabIndex = 6;
            txtLLogin.KeyPress += txtLLogin_KeyPress;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(265, 288);
            button1.Name = "button1";
            button1.Size = new Size(156, 29);
            button1.TabIndex = 7;
            button1.Text = "Сохранить изменения";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(430, 288);
            button2.Name = "button2";
            button2.Size = new Size(156, 29);
            button2.TabIndex = 8;
            button2.Text = "Удалить пользователя";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(265, 13);
            label4.Name = "label4";
            label4.Size = new Size(37, 17);
            label4.TabIndex = 9;
            label4.Text = "ФИО";
            // 
            // txtFIO
            // 
            txtFIO.Location = new Point(325, 12);
            txtFIO.Name = "txtFIO";
            txtFIO.PlaceholderText = "Фамилия Имя Отчество";
            txtFIO.Size = new Size(260, 23);
            txtFIO.TabIndex = 10;
            txtFIO.KeyPress += txtFIO_KeyPress;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(430, 183);
            button3.Name = "button3";
            button3.Size = new Size(113, 76);
            button3.TabIndex = 11;
            button3.Text = "Резервоне копирование";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(308, 183);
            button4.Name = "button4";
            button4.Size = new Size(113, 76);
            button4.TabIndex = 12;
            button4.Text = "Восстановление ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 337);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(txtFIO);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtLLogin);
            Controls.Add(txtPas);
            Controls.Add(RoleCombBox);
            Controls.Add(txtRole);
            Controls.Add(txtPassw);
            Controls.Add(txtLogin);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Users";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Пользователи";
            Load += Users_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label txtLogin;
        private Label txtPassw;
        private Label txtRole;
        private ComboBox RoleCombBox;
        private TextBox txtPas;
        private TextBox txtLLogin;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox txtFIO;
        private DataGridViewTextBoxColumn id_user;
        private DataGridViewTextBoxColumn DTLogin;
        private DataGridViewTextBoxColumn RoleUser;
        private Button button3;
        private Button button4;
    }
}