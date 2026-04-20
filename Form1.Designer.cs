namespace Praktika01Uvarov
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            txtSearch = new TextBox();
            dataGridView1 = new DataGridView();
            IDNumber = new DataGridViewTextBoxColumn();
            Направление = new DataGridViewTextBoxColumn();
            Название = new DataGridViewTextBoxColumn();
            Срокипроведения = new DataGridViewTextBoxColumn();
            Ответственный = new DataGridViewTextBoxColumn();
            Датапроведения = new DataGridViewTextBoxColumn();
            AddEditDelete = new ContextMenuStrip(components);
            AddPlan = new ToolStripMenuItem();
            EditPlan = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            DeletePlan = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            contextFilterItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            PlanRabot = new TabPage();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            button10 = new Button();
            button2 = new Button();
            button9 = new Button();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Event = new TabPage();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            button11 = new Button();
            button12 = new Button();
            button6 = new Button();
            button3 = new Button();
            dataGridView2 = new DataGridView();
            EventIDGroup = new DataGridViewTextBoxColumn();
            EventIDNumber = new DataGridViewTextBoxColumn();
            Мероприятие = new DataGridViewTextBoxColumn();
            Группа = new DataGridViewTextBoxColumn();
            Местопроведения = new DataGridViewTextBoxColumn();
            Участники = new DataGridViewTextBoxColumn();
            Содержаниемероприятия = new DataGridViewTextBoxColumn();
            ДатапроведенияИвент = new DataGridViewTextBoxColumn();
            Group = new TabPage();
            pictureBox15 = new PictureBox();
            pictureBox12 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            button13 = new Button();
            button14 = new Button();
            button7 = new Button();
            button4 = new Button();
            dataGridView3 = new DataGridView();
            IDGroup = new DataGridViewTextBoxColumn();
            ФИОКуратора = new DataGridViewTextBoxColumn();
            Названиегруппы = new DataGridViewTextBoxColumn();
            InvitedParty = new TabPage();
            pictureBox16 = new PictureBox();
            pictureBox14 = new PictureBox();
            pictureBox13 = new PictureBox();
            pictureBox11 = new PictureBox();
            button15 = new Button();
            button16 = new Button();
            button8 = new Button();
            button5 = new Button();
            dataGridView4 = new DataGridView();
            IDNumberInv = new DataGridViewTextBoxColumn();
            IDplayer = new DataGridViewTextBoxColumn();
            МероприятиеПРИГ = new DataGridViewTextBoxColumn();
            ФИОПриглашённого = new DataGridViewTextBoxColumn();
            Должность = new DataGridViewTextBoxColumn();
            Названиеорганизации = new DataGridViewTextBoxColumn();
            GLMenu = new MenuStrip();
            UchetZapis = new ToolStripMenuItem();
            сменитьУчётнуюЗаписьToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            администрированиеToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            FIODayn = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            AddEditDelete.SuspendLayout();
            tabControl1.SuspendLayout();
            PlanRabot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Event.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            InvitedParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            GLMenu.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(2, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск";
            txtSearch.Size = new Size(794, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IDNumber, Направление, Название, Срокипроведения, Ответственный, Датапроведения });
            dataGridView1.ContextMenuStrip = AddEditDelete;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(792, 272);
            dataGridView1.TabIndex = 1;
            // 
            // IDNumber
            // 
            IDNumber.HeaderText = "IDNumber";
            IDNumber.Name = "IDNumber";
            IDNumber.ReadOnly = true;
            IDNumber.Visible = false;
            // 
            // Направление
            // 
            Направление.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Направление.HeaderText = "Направление";
            Направление.Name = "Направление";
            Направление.ReadOnly = true;
            // 
            // Название
            // 
            Название.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Название.HeaderText = "Название";
            Название.Name = "Название";
            Название.ReadOnly = true;
            // 
            // Срокипроведения
            // 
            Срокипроведения.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Срокипроведения.HeaderText = "Сроки проведения";
            Срокипроведения.Name = "Срокипроведения";
            Срокипроведения.ReadOnly = true;
            // 
            // Ответственный
            // 
            Ответственный.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Ответственный.HeaderText = "Ответственный";
            Ответственный.Name = "Ответственный";
            Ответственный.ReadOnly = true;
            // 
            // Датапроведения
            // 
            Датапроведения.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Датапроведения.HeaderText = "Дата проведения";
            Датапроведения.Name = "Датапроведения";
            Датапроведения.ReadOnly = true;
            // 
            // AddEditDelete
            // 
            AddEditDelete.Items.AddRange(new ToolStripItem[] { AddPlan, EditPlan, toolStripSeparator1, DeletePlan, toolStripSeparator2, contextFilterItem });
            AddEditDelete.Name = "contextMenuStrip1";
            AddEditDelete.RenderMode = ToolStripRenderMode.Professional;
            AddEditDelete.Size = new Size(155, 104);
            // 
            // AddPlan
            // 
            AddPlan.BackColor = Color.Transparent;
            AddPlan.ForeColor = Color.Black;
            AddPlan.Image = Properties.Resources._1490129329_rounded38_82203;
            AddPlan.ImageTransparentColor = Color.White;
            AddPlan.Name = "AddPlan";
            AddPlan.Size = new Size(154, 22);
            AddPlan.Text = "Добавить";
            AddPlan.Click += AddPlan_Click;
            // 
            // EditPlan
            // 
            EditPlan.BackColor = Color.Transparent;
            EditPlan.Image = Properties.Resources._353430_checkbox_edit_pen_pencil_107516;
            EditPlan.ImageTransparentColor = Color.White;
            EditPlan.Name = "EditPlan";
            EditPlan.Size = new Size(154, 22);
            EditPlan.Text = "Редактировать";
            EditPlan.Click += EditPlan_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor = Color.Transparent;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(151, 6);
            // 
            // DeletePlan
            // 
            DeletePlan.BackColor = Color.Transparent;
            DeletePlan.Image = Properties.Resources.waste_bin_delete_remove_recycle_icon_123840;
            DeletePlan.ImageTransparentColor = Color.White;
            DeletePlan.Name = "DeletePlan";
            DeletePlan.Size = new Size(154, 22);
            DeletePlan.Text = "Удалить ";
            DeletePlan.Click += DeletePlan_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(151, 6);
            // 
            // contextFilterItem
            // 
            contextFilterItem.Image = Properties.Resources.free_icon_filter_2676824;
            contextFilterItem.Name = "contextFilterItem";
            contextFilterItem.Size = new Size(154, 22);
            contextFilterItem.Text = "Фильтр";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(PlanRabot);
            tabControl1.Controls.Add(Event);
            tabControl1.Controls.Add(Group);
            tabControl1.Controls.Add(InvitedParty);
            tabControl1.Location = new Point(0, 56);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 392);
            tabControl1.TabIndex = 2;
            // 
            // PlanRabot
            // 
            PlanRabot.BackColor = Color.White;
            PlanRabot.Controls.Add(pictureBox4);
            PlanRabot.Controls.Add(dataGridView1);
            PlanRabot.Controls.Add(pictureBox3);
            PlanRabot.Controls.Add(button10);
            PlanRabot.Controls.Add(button2);
            PlanRabot.Controls.Add(button9);
            PlanRabot.Controls.Add(button1);
            PlanRabot.Controls.Add(pictureBox2);
            PlanRabot.Controls.Add(pictureBox1);
            PlanRabot.Location = new Point(4, 24);
            PlanRabot.Name = "PlanRabot";
            PlanRabot.Padding = new Padding(3);
            PlanRabot.Size = new Size(792, 364);
            PlanRabot.TabIndex = 0;
            PlanRabot.Text = "План воспитательной работы";
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = Properties.Resources.waste_bin_delete_remove_recycle_icon_123840;
            pictureBox4.InitialImage = null;
            pictureBox4.Location = new Point(606, 304);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(27, 27);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = Properties.Resources._353430_checkbox_edit_pen_pencil_107516;
            pictureBox3.Location = new Point(414, 304);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // button10
            // 
            button10.BackColor = Color.White;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(596, 299);
            button10.Name = "button10";
            button10.Size = new Size(172, 35);
            button10.TabIndex = 5;
            button10.Text = "Удалить";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            button10.MouseEnter += button10_MouseEnter;
            button10.MouseLeave += button10_MouseLeave;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(213, 299);
            button2.Name = "button2";
            button2.Size = new Size(172, 35);
            button2.TabIndex = 3;
            button2.Text = "Добавить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseEnter += button2_MouseEnter;
            button2.MouseLeave += button2_MouseLeave;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.FlatStyle = FlatStyle.Flat;
            button9.ForeColor = SystemColors.ControlText;
            button9.Location = new Point(404, 299);
            button9.Name = "button9";
            button9.Size = new Size(172, 35);
            button9.TabIndex = 4;
            button9.Text = "Редактировать";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            button9.MouseEnter += button9_MouseEnter;
            button9.MouseLeave += button9_MouseLeave;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(21, 299);
            button1.Name = "button1";
            button1.Size = new Size(172, 35);
            button1.TabIndex = 2;
            button1.Text = "Информация ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.circle_customer_help_info_information_service_support_icon_123208;
            pictureBox2.Location = new Point(31, 304);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources._1904677_add_addition_calculate_charge_create_new_plus_122527;
            pictureBox1.Location = new Point(223, 304);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Event
            // 
            Event.Controls.Add(pictureBox8);
            Event.Controls.Add(pictureBox7);
            Event.Controls.Add(pictureBox6);
            Event.Controls.Add(pictureBox5);
            Event.Controls.Add(button11);
            Event.Controls.Add(button12);
            Event.Controls.Add(button6);
            Event.Controls.Add(button3);
            Event.Controls.Add(dataGridView2);
            Event.Location = new Point(4, 24);
            Event.Name = "Event";
            Event.Padding = new Padding(3);
            Event.Size = new Size(792, 364);
            Event.TabIndex = 1;
            Event.Text = "Мероприятия";
            Event.UseVisualStyleBackColor = true;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources._1904677_add_addition_calculate_charge_create_new_plus_122527;
            pictureBox8.Location = new Point(223, 304);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(26, 26);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 11;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.waste_bin_delete_remove_recycle_icon_123840;
            pictureBox7.Location = new Point(606, 304);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(27, 27);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources._353430_checkbox_edit_pen_pencil_107516;
            pictureBox6.Location = new Point(414, 304);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(27, 27);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 9;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.circle_customer_help_info_information_service_support_icon_123208;
            pictureBox5.Location = new Point(31, 304);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(27, 27);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // button11
            // 
            button11.BackColor = Color.White;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(596, 299);
            button11.Name = "button11";
            button11.Size = new Size(172, 35);
            button11.TabIndex = 7;
            button11.Text = "Удалить";
            button11.UseVisualStyleBackColor = false;
            button11.MouseEnter += button11_MouseEnter;
            button11.MouseLeave += button11_MouseLeave;
            // 
            // button12
            // 
            button12.BackColor = Color.White;
            button12.FlatStyle = FlatStyle.Flat;
            button12.ForeColor = SystemColors.ControlText;
            button12.Location = new Point(404, 299);
            button12.Name = "button12";
            button12.Size = new Size(172, 35);
            button12.TabIndex = 6;
            button12.Text = "Редактировать";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            button12.MouseEnter += button12_MouseEnter;
            button12.MouseLeave += button12_MouseLeave;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(213, 299);
            button6.Name = "button6";
            button6.Size = new Size(172, 35);
            button6.TabIndex = 4;
            button6.Text = "Добавить";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            button6.MouseEnter += button6_MouseEnter;
            button6.MouseLeave += button6_MouseLeave;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(21, 299);
            button3.Name = "button3";
            button3.Size = new Size(172, 35);
            button3.TabIndex = 3;
            button3.Text = "Информация ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;
            button3.MouseLeave += button3_MouseLeave;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { EventIDGroup, EventIDNumber, Мероприятие, Группа, Местопроведения, Участники, Содержаниемероприятия, ДатапроведенияИвент });
            dataGridView2.ContextMenuStrip = AddEditDelete;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(792, 272);
            dataGridView2.TabIndex = 2;
            // 
            // EventIDGroup
            // 
            EventIDGroup.HeaderText = "EventIDGroup";
            EventIDGroup.Name = "EventIDGroup";
            EventIDGroup.ReadOnly = true;
            EventIDGroup.Visible = false;
            // 
            // EventIDNumber
            // 
            EventIDNumber.HeaderText = "EventIDNumber";
            EventIDNumber.Name = "EventIDNumber";
            EventIDNumber.ReadOnly = true;
            EventIDNumber.Visible = false;
            // 
            // Мероприятие
            // 
            Мероприятие.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Мероприятие.HeaderText = "Мероприятие";
            Мероприятие.Name = "Мероприятие";
            Мероприятие.ReadOnly = true;
            // 
            // Группа
            // 
            Группа.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Группа.HeaderText = "Группа";
            Группа.Name = "Группа";
            Группа.ReadOnly = true;
            // 
            // Местопроведения
            // 
            Местопроведения.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Местопроведения.HeaderText = "Место проведения";
            Местопроведения.Name = "Местопроведения";
            Местопроведения.ReadOnly = true;
            // 
            // Участники
            // 
            Участники.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Участники.HeaderText = "Участники";
            Участники.Name = "Участники";
            Участники.ReadOnly = true;
            // 
            // Содержаниемероприятия
            // 
            Содержаниемероприятия.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Содержаниемероприятия.HeaderText = "Содержание мероприятия";
            Содержаниемероприятия.Name = "Содержаниемероприятия";
            Содержаниемероприятия.ReadOnly = true;
            // 
            // ДатапроведенияИвент
            // 
            ДатапроведенияИвент.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ДатапроведенияИвент.HeaderText = "Дата проведения";
            ДатапроведенияИвент.Name = "ДатапроведенияИвент";
            ДатапроведенияИвент.ReadOnly = true;
            // 
            // Group
            // 
            Group.Controls.Add(pictureBox15);
            Group.Controls.Add(pictureBox12);
            Group.Controls.Add(pictureBox10);
            Group.Controls.Add(pictureBox9);
            Group.Controls.Add(button13);
            Group.Controls.Add(button14);
            Group.Controls.Add(button7);
            Group.Controls.Add(button4);
            Group.Controls.Add(dataGridView3);
            Group.Location = new Point(4, 24);
            Group.Name = "Group";
            Group.Size = new Size(792, 364);
            Group.TabIndex = 2;
            Group.Text = "Группы";
            Group.UseVisualStyleBackColor = true;
            // 
            // pictureBox15
            // 
            pictureBox15.Image = Properties.Resources.person_add_icon_icons_com_50077;
            pictureBox15.Location = new Point(223, 304);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(27, 27);
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.TabIndex = 12;
            pictureBox15.TabStop = false;
            // 
            // pictureBox12
            // 
            pictureBox12.Image = Properties.Resources.waste_bin_delete_remove_recycle_icon_123840;
            pictureBox12.Location = new Point(606, 304);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(26, 26);
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.TabIndex = 11;
            pictureBox12.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = Properties.Resources._353430_checkbox_edit_pen_pencil_107516;
            pictureBox10.Location = new Point(414, 304);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(27, 27);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 10;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Properties.Resources.circle_customer_help_info_information_service_support_icon_123208;
            pictureBox9.Location = new Point(31, 304);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(27, 27);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 9;
            pictureBox9.TabStop = false;
            // 
            // button13
            // 
            button13.BackColor = Color.White;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Location = new Point(596, 299);
            button13.Name = "button13";
            button13.Size = new Size(172, 35);
            button13.TabIndex = 7;
            button13.Text = "Удалить";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            button13.MouseEnter += button13_MouseEnter;
            button13.MouseLeave += button13_MouseLeave;
            // 
            // button14
            // 
            button14.BackColor = Color.White;
            button14.FlatStyle = FlatStyle.Flat;
            button14.ForeColor = SystemColors.ControlText;
            button14.Location = new Point(404, 299);
            button14.Name = "button14";
            button14.Size = new Size(172, 35);
            button14.TabIndex = 6;
            button14.Text = "Редактировать";
            button14.UseVisualStyleBackColor = false;
            button14.Click += button14_Click;
            button14.MouseEnter += button14_MouseEnter;
            button14.MouseLeave += button14_MouseLeave;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(213, 299);
            button7.Name = "button7";
            button7.Size = new Size(172, 35);
            button7.TabIndex = 4;
            button7.Text = "Добавить";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            button7.MouseEnter += button7_MouseEnter;
            button7.MouseLeave += button7_MouseLeave;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(21, 299);
            button4.Name = "button4";
            button4.Size = new Size(172, 35);
            button4.TabIndex = 3;
            button4.Text = "Информация ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            button4.MouseEnter += button4_MouseEnter;
            button4.MouseLeave += button4_MouseLeave;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.BackgroundColor = Color.White;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { IDGroup, ФИОКуратора, Названиегруппы });
            dataGridView3.ContextMenuStrip = AddEditDelete;
            dataGridView3.Location = new Point(0, 0);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Size = new Size(792, 272);
            dataGridView3.TabIndex = 2;
            // 
            // IDGroup
            // 
            IDGroup.HeaderText = "ID";
            IDGroup.Name = "IDGroup";
            IDGroup.ReadOnly = true;
            IDGroup.Visible = false;
            // 
            // ФИОКуратора
            // 
            ФИОКуратора.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ФИОКуратора.HeaderText = "ФИО Куратора";
            ФИОКуратора.Name = "ФИОКуратора";
            ФИОКуратора.ReadOnly = true;
            // 
            // Названиегруппы
            // 
            Названиегруппы.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Названиегруппы.HeaderText = "Название группы";
            Названиегруппы.Name = "Названиегруппы";
            Названиегруппы.ReadOnly = true;
            Названиегруппы.Width = 117;
            // 
            // InvitedParty
            // 
            InvitedParty.Controls.Add(pictureBox16);
            InvitedParty.Controls.Add(pictureBox14);
            InvitedParty.Controls.Add(pictureBox13);
            InvitedParty.Controls.Add(pictureBox11);
            InvitedParty.Controls.Add(button15);
            InvitedParty.Controls.Add(button16);
            InvitedParty.Controls.Add(button8);
            InvitedParty.Controls.Add(button5);
            InvitedParty.Controls.Add(dataGridView4);
            InvitedParty.Location = new Point(4, 24);
            InvitedParty.Name = "InvitedParty";
            InvitedParty.Size = new Size(792, 364);
            InvitedParty.TabIndex = 3;
            InvitedParty.Text = "Приглашённые участники";
            InvitedParty.UseVisualStyleBackColor = true;
            // 
            // pictureBox16
            // 
            pictureBox16.Image = Properties.Resources.person_add_icon_icons_com_50077;
            pictureBox16.Location = new Point(223, 304);
            pictureBox16.Name = "pictureBox16";
            pictureBox16.Size = new Size(27, 27);
            pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox16.TabIndex = 14;
            pictureBox16.TabStop = false;
            // 
            // pictureBox14
            // 
            pictureBox14.Image = Properties.Resources.circle_customer_help_info_information_service_support_icon_123208;
            pictureBox14.Location = new Point(31, 304);
            pictureBox14.Name = "pictureBox14";
            pictureBox14.Size = new Size(27, 27);
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.TabIndex = 13;
            pictureBox14.TabStop = false;
            // 
            // pictureBox13
            // 
            pictureBox13.Image = Properties.Resources._353430_checkbox_edit_pen_pencil_107516;
            pictureBox13.Location = new Point(414, 304);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(27, 27);
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.TabIndex = 12;
            pictureBox13.TabStop = false;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = Properties.Resources.waste_bin_delete_remove_recycle_icon_123840;
            pictureBox11.Location = new Point(606, 304);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(27, 27);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 11;
            pictureBox11.TabStop = false;
            // 
            // button15
            // 
            button15.BackColor = Color.White;
            button15.FlatStyle = FlatStyle.Flat;
            button15.Location = new Point(596, 299);
            button15.Name = "button15";
            button15.Size = new Size(172, 35);
            button15.TabIndex = 7;
            button15.Text = "Удалить";
            button15.UseVisualStyleBackColor = false;
            button15.Click += button15_Click;
            button15.MouseEnter += button15_MouseEnter;
            button15.MouseLeave += button15_MouseLeave;
            // 
            // button16
            // 
            button16.BackColor = Color.White;
            button16.FlatStyle = FlatStyle.Flat;
            button16.ForeColor = SystemColors.ControlText;
            button16.Location = new Point(404, 299);
            button16.Name = "button16";
            button16.Size = new Size(172, 35);
            button16.TabIndex = 6;
            button16.Text = "Редактировать";
            button16.UseVisualStyleBackColor = false;
            button16.Click += button16_Click;
            button16.MouseEnter += button16_MouseEnter;
            button16.MouseLeave += button16_MouseLeave;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(213, 299);
            button8.Name = "button8";
            button8.Size = new Size(172, 35);
            button8.TabIndex = 5;
            button8.Text = "Добавить";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            button8.MouseEnter += button8_MouseEnter;
            button8.MouseLeave += button8_MouseLeave;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(21, 299);
            button5.Name = "button5";
            button5.Size = new Size(172, 35);
            button5.TabIndex = 4;
            button5.Text = "Информация ";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            button5.MouseEnter += button5_MouseEnter;
            button5.MouseLeave += button5_MouseLeave;
            // 
            // dataGridView4
            // 
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.BackgroundColor = Color.White;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Columns.AddRange(new DataGridViewColumn[] { IDNumberInv, IDplayer, МероприятиеПРИГ, ФИОПриглашённого, Должность, Названиеорганизации });
            dataGridView4.ContextMenuStrip = AddEditDelete;
            dataGridView4.Location = new Point(0, 0);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.Size = new Size(792, 272);
            dataGridView4.TabIndex = 3;
            // 
            // IDNumberInv
            // 
            IDNumberInv.HeaderText = "IDNumberInv";
            IDNumberInv.Name = "IDNumberInv";
            IDNumberInv.ReadOnly = true;
            IDNumberInv.Visible = false;
            // 
            // IDplayer
            // 
            IDplayer.HeaderText = "IDplayer";
            IDplayer.Name = "IDplayer";
            IDplayer.ReadOnly = true;
            IDplayer.Visible = false;
            // 
            // МероприятиеПРИГ
            // 
            МероприятиеПРИГ.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            МероприятиеПРИГ.HeaderText = "Мероприятие";
            МероприятиеПРИГ.Name = "МероприятиеПРИГ";
            МероприятиеПРИГ.ReadOnly = true;
            // 
            // ФИОПриглашённого
            // 
            ФИОПриглашённого.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ФИОПриглашённого.HeaderText = "ФИО Приглашённого";
            ФИОПриглашённого.Name = "ФИОПриглашённого";
            ФИОПриглашённого.ReadOnly = true;
            // 
            // Должность
            // 
            Должность.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Должность.HeaderText = "Должность";
            Должность.Name = "Должность";
            Должность.ReadOnly = true;
            // 
            // Названиеорганизации
            // 
            Названиеорганизации.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Названиеорганизации.HeaderText = "Название организации";
            Названиеорганизации.Name = "Названиеорганизации";
            Названиеорганизации.ReadOnly = true;
            // 
            // GLMenu
            // 
            GLMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            GLMenu.Items.AddRange(new ToolStripItem[] { UchetZapis, toolStripMenuItem1, администрированиеToolStripMenuItem, оПрограммеToolStripMenuItem });
            GLMenu.Location = new Point(0, 0);
            GLMenu.Name = "GLMenu";
            GLMenu.Size = new Size(800, 25);
            GLMenu.TabIndex = 10;
            GLMenu.Text = "menuStrip1";
            // 
            // UchetZapis
            // 
            UchetZapis.DropDownItems.AddRange(new ToolStripItem[] { сменитьУчётнуюЗаписьToolStripMenuItem });
            UchetZapis.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UchetZapis.Image = Properties.Resources.masculine_avatar_user_with_suit_icon_icons_com_68296;
            UchetZapis.Name = "UchetZapis";
            UchetZapis.Size = new Size(127, 21);
            UchetZapis.Text = "Учётная запись";
            // 
            // сменитьУчётнуюЗаписьToolStripMenuItem
            // 
            сменитьУчётнуюЗаписьToolStripMenuItem.BackColor = Color.White;
            сменитьУчётнуюЗаписьToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            сменитьУчётнуюЗаписьToolStripMenuItem.Image = Properties.Resources.sign_out_option_icon_icons_com_73413;
            сменитьУчётнуюЗаписьToolStripMenuItem.Name = "сменитьУчётнуюЗаписьToolStripMenuItem";
            сменитьУчётнуюЗаписьToolStripMenuItem.Size = new Size(213, 22);
            сменитьУчётнуюЗаписьToolStripMenuItem.Text = "Сменить учётную запись";
            сменитьУчётнуюЗаписьToolStripMenuItem.Click += сменитьУчётнуюЗаписьToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = Properties.Resources.reporting_noun_report_document_file_icon_148360;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(70, 21);
            toolStripMenuItem1.Text = "Отчёт";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // администрированиеToolStripMenuItem
            // 
            администрированиеToolStripMenuItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            администрированиеToolStripMenuItem.Image = Properties.Resources.group_profile_users_icon_icons_com_73540__1_;
            администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            администрированиеToolStripMenuItem.Size = new Size(158, 21);
            администрированиеToolStripMenuItem.Text = "Администрирование";
            администрированиеToolStripMenuItem.Click += администрированиеToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            оПрограммеToolStripMenuItem.Image = Properties.Resources.question_sign_icon_178767;
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(118, 21);
            оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // FIODayn
            // 
            FIODayn.AutoSize = true;
            FIODayn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FIODayn.ForeColor = SystemColors.ControlText;
            FIODayn.Location = new Point(580, 55);
            FIODayn.Name = "FIODayn";
            FIODayn.Size = new Size(0, 17);
            FIODayn.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FIODayn);
            Controls.Add(GLMenu);
            Controls.Add(tabControl1);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = GLMenu;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Проведение мероприятий";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            AddEditDelete.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            PlanRabot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Event.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            InvitedParty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox16).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            GLMenu.ResumeLayout(false);
            GLMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage PlanRabot;
        private TabPage Event;
        private TabPage Group;
        private TabPage InvitedParty;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox9;
        private PictureBox pictureBox12;
        private PictureBox pictureBox10;
        private PictureBox pictureBox13;
        private PictureBox pictureBox11;
        private PictureBox pictureBox14;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private ContextMenuStrip AddEditDelete;
        private ToolStripMenuItem AddPlan;
        private ToolStripMenuItem EditPlan;
        private ToolStripMenuItem DeletePlan;
        private ToolStripSeparator toolStripSeparator1;
        private MenuStrip GLMenu;
        private ToolStripMenuItem администрированиеToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem UchetZapis;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem сменитьУчётнуюЗаписьToolStripMenuItem;
        private Label FIODayn;
        private DataGridViewTextBoxColumn IDGroup;
        private DataGridViewTextBoxColumn ФИОКуратора;
        private DataGridViewTextBoxColumn Названиегруппы;
        private DataGridViewTextBoxColumn IDNumber;
        private DataGridViewTextBoxColumn Направление;
        private DataGridViewTextBoxColumn Название;
        private DataGridViewTextBoxColumn Срокипроведения;
        private DataGridViewTextBoxColumn Ответственный;
        private DataGridViewTextBoxColumn Датапроведения;
        private DataGridViewTextBoxColumn IDNumberInv;
        private DataGridViewTextBoxColumn IDplayer;
        private DataGridViewTextBoxColumn МероприятиеПРИГ;
        private DataGridViewTextBoxColumn ФИОПриглашённого;
        private DataGridViewTextBoxColumn Должность;
        private DataGridViewTextBoxColumn Названиеорганизации;
        private DataGridViewTextBoxColumn EventIDGroup;
        private DataGridViewTextBoxColumn EventIDNumber;
        private DataGridViewTextBoxColumn Мероприятие;
        private DataGridViewTextBoxColumn Группа;
        private DataGridViewTextBoxColumn Местопроведения;
        private DataGridViewTextBoxColumn Участники;
        private DataGridViewTextBoxColumn Содержаниемероприятия;
        private DataGridViewTextBoxColumn ДатапроведенияИвент;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem contextFilterItem;
    }
}
