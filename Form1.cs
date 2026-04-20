using ArchiveFund;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Utilities.Bzip2;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Praktika01Uvarov
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;
        void AddVospPlan()
        {
            ThisPlanVospitat thisPlanVospitat = new ThisPlanVospitat();
            if (thisPlanVospitat.ShowDialog() == DialogResult.OK)
            {
                if (thisPlanVospitat.txtNaprav.Text != "" || thisPlanVospitat.txtNazvan.Text != "" || thisPlanVospitat.txtSroki.Text != "" || thisPlanVospitat.txtFIOOtvet.Text != "")
                {
                    sqlCommand = @"INSERT INTO Educational_work_plan (The_direction_of_educational_work, Educational_work_plan.`EVENT`, Dates_event, FIO_responsible_person, A_note_about_the_event)
                VALUES ('" + thisPlanVospitat.txtNaprav.Text + "', '" + thisPlanVospitat.txtNazvan.Text + "', '" + thisPlanVospitat.txtSroki.Text + "', '" + thisPlanVospitat.txtFIOOtvet.Text + "', '" + thisPlanVospitat.dtTashkent.Value.ToString("yyyy-MM-dd") + "');";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable();
                }
                else
                {
                    MessageBox.Show("Заполните поля для ввода!");
                    thisPlanVospitat.ShowDialog();
                }
            }
        }
        void AddEvents()
        {
            Events events = new Events();
            if (events.ShowDialog() == DialogResult.OK)
            {
                string disableFK = "SET FOREIGN_KEY_CHECKS=0;";
                MySqlCommand cmdFK = new MySqlCommand(disableFK, conn);
                cmdFK.ExecuteNonQuery();

                sqlCommand = @"INSERT INTO `Event` (fk_Number_plan, fk_Group_Code, Event_Location, The_main_participants, Event_content, Date_Event) 
                VALUES (' " + events.NameCB.SelectedValue + "', '" + events.EventNameCB.SelectedValue + "', '" + events.txtMesto.Text + "', '" + events.txtOsn.Text + "', '" + events.txtKratko.Text + "', '" + events.dtDate.Value.ToString("yyyy-MM-dd") + "');";
                cmd = new MySqlCommand(sqlCommand, conn);
                cmd.ExecuteNonQuery();
                fillTable2();

                string enableFK = "SET FOREIGN_KEY_CHECKS=1;";
                MySqlCommand cmdFK2 = new MySqlCommand(enableFK, conn);
                cmdFK2.ExecuteNonQuery();
            }
        }
        void AddGroups()
        {
            Groups groups = new Groups();
            if (groups.ShowDialog() == DialogResult.OK)
            {
                if (groups.txtFIO.Text != "" || groups.txtNameGroup.Text != "")
                {
                    sqlCommand = @"INSERT INTO `group` (FIO_curator, Group_Name)
                VALUES ('" + groups.txtFIO.Text + "', '" + groups.txtNameGroup.Text + "');";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable3();
                }
                else
                {
                    MessageBox.Show("Заполните поля для ввода!");
                }
            }
        }
        void AddInvited()
        {
            AddInvitedPeople addInvitedPeople = new AddInvitedPeople();
            if (addInvitedPeople.ShowDialog() == DialogResult.OK)
            {
                sqlCommand = @"INSERT INTO Invited_participants (FIO_invited, Post, Org_name)
                VALUES ('" + addInvitedPeople.txtFIO.Text + "', '" + addInvitedPeople.txtPost.Text + "', '" + addInvitedPeople.txtOrgName.Text + "');";
                cmd = new MySqlCommand(sqlCommand, conn);
                cmd.ExecuteNonQuery();
                sqlCommand = @"INSERT INTO Inviting_participants (fk_Number_plan, fk_Code_player)
                VALUES ( " + addInvitedPeople.EventsCB.SelectedValue + ", " + "LAST_INSERT_ID())";
                cmd = new MySqlCommand(sqlCommand, conn);
                cmd.ExecuteNonQuery();
                fillTable4();
            }
        }
        void EditInvited()
        {
            if (dataGridView4.RowCount == 0)
            {
                MessageBox.Show("Нечего редактировать");
            }
            else
            {
                AddInvitedPeople addInvitedPeople = new AddInvitedPeople();
                string n2 = dataGridView4.SelectedCells[3].Value.ToString();
                string n3 = dataGridView4.SelectedCells[4].Value.ToString();
                string n4 = dataGridView4.SelectedCells[5].Value.ToString();
                addInvitedPeople.txtFIO.Text = n2.ToString();
                addInvitedPeople.txtPost.Text = n3.ToString();
                addInvitedPeople.txtOrgName.Text = n4.ToString();
                if (addInvitedPeople.ShowDialog() == DialogResult.OK)
                {
                    int indRow = dataGridView4.CurrentRow.Index;
                    int idPlayer = Convert.ToInt32(dataGridView4.Rows[indRow].Cells[1].Value);
                    int idNumberPlan = Convert.ToInt32(dataGridView4.Rows[indRow].Cells[0].Value);
                    string n1 = addInvitedPeople.EventsCB.SelectedValue.ToString();
                    n2 = addInvitedPeople.txtFIO.Text;
                    n3 = addInvitedPeople.txtPost.Text;
                    n4 = addInvitedPeople.txtOrgName.Text;
                    sqlCommand = "UPDATE Invited_participants SET ";
                    sqlCommand += "FIO_invited = '" + n2 + "', Post = '" + n3 + "', Org_name = '" + n4 + "'";
                    sqlCommand += " WHERE Code_player = '" + idPlayer.ToString() + "'";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    var sqlCommand2 = $"UPDATE Inviting_participants SET fk_Number_plan = '{n1?.ToString()}' WHERE fk_Number_plan = '{idNumberPlan.ToString()}' AND fk_Code_player = '{idPlayer.ToString()}'";
                    cmd = new MySqlCommand(sqlCommand2, conn);
                    cmd.ExecuteNonQuery();
                    fillTable4();
                }
            }
        }
        void EditGroup()
        {
            if (dataGridView3.RowCount == 0)
            {
                MessageBox.Show("Нечего редактировать");
            }
            else
            {
                Groups groups = new Groups();
                string n1 = dataGridView3.SelectedCells[1].Value.ToString();
                string n2 = dataGridView3.SelectedCells[2].Value.ToString();
                groups.txtFIO.Text = n1.ToString();
                groups.txtNameGroup.Text = n2.ToString(); ;
                if (groups.ShowDialog() == DialogResult.OK)
                {
                    int indRow = dataGridView3.CurrentRow.Index;
                    int idStud = Convert.ToInt32(dataGridView3.Rows[indRow].Cells[0].Value);
                    string n3 = groups.txtFIO.Text;
                    string n4 = groups.txtNameGroup.Text;
                    sqlCommand = "UPDATE `group` SET ";
                    sqlCommand += "FIO_curator = '" + n3 + "', Group_Name = '" + n4 + "'";
                    sqlCommand += "WHERE Group_code = '" + idStud.ToString() + "'";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable3();
                }
            }
        }
        void EditEvent()
        {
            if (dataGridView2.RowCount == 0)
            {
                MessageBox.Show("Нечего редактировать");
            }
            else
            {
                Events events = new Events();
                string n1 = dataGridView2.SelectedCells[0].Value.ToString();
                string n2 = dataGridView2.SelectedCells[3].Value.ToString();
                string n3 = dataGridView2.SelectedCells[4].Value.ToString();
                string n4 = dataGridView2.SelectedCells[5].Value.ToString();
                string n5 = dataGridView2.SelectedCells[6].Value.ToString();
                events.NameCB.Items.Add(n1.ToString());
                events.EventNameCB.Items.Add(n2.ToString());
                events.txtMesto.Text = n3.ToString();
                events.txtOsn.Text = n4.ToString();
                events.txtKratko.Text = n5.ToString();

                if (events.ShowDialog() == DialogResult.OK)
                {
                    int indRow = dataGridView2.CurrentRow.Index;
                    int idNumberPlan = Convert.ToInt32(dataGridView2.Rows[indRow].Cells[1].Value);
                    int idGroupCode = Convert.ToInt32(dataGridView2.Rows[indRow].Cells[0].Value);
                    n1 = events.NameCB.SelectedValue.ToString();
                    n2 = events.EventNameCB.SelectedValue.ToString();
                    n3 = events.txtMesto.Text;
                    n4 = events.txtOsn.Text;
                    n5 = events.txtKratko.Text;
                    sqlCommand = "UPDATE `Event` SET ";
                    sqlCommand += "fk_Number_plan = '" + n1 + "', " + "fk_Group_Code = '" + n2 + "', " + "Event_Location = '" + n3 + "', " + "The_main_participants = '" + n4 + "', " + "Event_content = '" + n5 + "', " + "Date_Event = '" + events.dtDate.Value.ToString("yyyy-MM-dd") + "'";
                    sqlCommand += " WHERE fk_Group_Code = " + idGroupCode.ToString() + " AND fk_Number_plan = " + idNumberPlan.ToString() + ";";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable2();
                }
            }
        }
        void EditVospPlan()
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Нечего редактировать");
            }
            else
            {
                ThisPlanVospitat thisPlanVospitat = new ThisPlanVospitat();
                string n1 = dataGridView1.SelectedCells[1].Value.ToString();
                string n2 = dataGridView1.SelectedCells[2].Value.ToString();
                string n3 = dataGridView1.SelectedCells[3].Value.ToString();
                string n4 = dataGridView1.SelectedCells[4].Value.ToString();
                thisPlanVospitat.txtNaprav.Text = n1.ToString();
                thisPlanVospitat.txtNazvan.Text = n2.ToString();
                thisPlanVospitat.txtSroki.Text = n3.ToString();
                thisPlanVospitat.txtFIOOtvet.Text = n4.ToString();

                if (thisPlanVospitat.ShowDialog() == DialogResult.OK)
                {
                    int indRow = dataGridView1.CurrentRow.Index;
                    int idStud = Convert.ToInt32(dataGridView1.Rows[indRow].Cells[0].Value);
                    n1 = thisPlanVospitat.txtNaprav.Text;
                    n2 = thisPlanVospitat.txtNazvan.Text;
                    n3 = thisPlanVospitat.txtSroki.Text;
                    n4 = thisPlanVospitat.txtFIOOtvet.Text;
                    sqlCommand = "UPDATE Educational_work_plan SET ";
                    sqlCommand += "The_direction_of_educational_work = '" + n1 + "', EVENT = '" + n2 + "', Dates_event = '" + n3 + "', FIO_responsible_person = '" + n4 + "', A_note_about_the_event = '" + thisPlanVospitat.dtTashkent.Value.ToString("yyyy-MM-dd") + "'";
                    sqlCommand += " WHERE Number_plan = " + idStud.ToString() + ";";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable();
                }
            }
        }
        void DeleteVospPlan()
        {

        }
        void DeleteGroup()
        {

        }
        struct tableStud
        {
            // План воспитательной работы.
            public string edNumber, edPlan, edName, edDate, edOtvetst, edDateProved;
        }
        struct tableStud2
        {
            // Мероприятия.
            public string evIDGroup, evIDNumber, evEvent, evGroup, evLocation, evUsers, evContent, evDateEvent;
        }
        struct tableStud3
        {
            // Группа.
            public string gCodeG, gFIO, gGroupName;
        }
        struct tableStud4
        {
            // Приглашённые участники.
            public string invNumber, invCodePlayer, invEvent, invFIO, invPost, invOrgName;
        }
        List<tableStud> getTable()
        {
            List<tableStud> tbStud = new List<tableStud>();
            tableStud tmp;
            tbStud.Clear();
            sqlCommand = "SELECT Number_plan, The_direction_of_educational_work, EVENT, Dates_event, FIO_responsible_person, A_note_about_the_event From Educational_work_plan";
            cmd = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp.edNumber = rdr["Number_plan"].ToString();
                tmp.edPlan = rdr["The_direction_of_educational_work"].ToString();
                tmp.edName = rdr["EVENT"].ToString();
                tmp.edDate = rdr["Dates_event"].ToString();
                tmp.edOtvetst = rdr["FIO_responsible_person"].ToString();
                tmp.edDateProved = rdr["A_note_about_the_event"].ToString();
                tbStud.Add(tmp);
            }
            rdr.Close();
            return tbStud;
        }
        List<tableStud2> vozvrat()
        {
            List<tableStud2> tbStud2 = new();
            tableStud2 tmp2;
            tbStud2.Clear();
            sqlCommand = @"SELECT fk_Number_plan, fk_Group_Code, Educational_work_plan.`EVENT` AS 'Мероприятие', `group`.Group_Name AS 'Группа', Event_Location AS 'Место проведения', The_main_participants AS 'Участники', Event_content 'Содержание мероприятия', Date_Event AS 'Дата проведения' FROM `Event` 
JOIN `group` ON `group`.Group_code = `Event`.fk_Group_Code 
JOIN Educational_work_plan ON Educational_work_plan.Number_plan = `Event`.fk_Number_plan;";
            cmd = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp2.evIDGroup = rdr["fk_Group_Code"].ToString();
                tmp2.evIDNumber = rdr["fk_Number_plan"].ToString();
                tmp2.evEvent = rdr["Мероприятие"].ToString();
                tmp2.evGroup = rdr["Группа"].ToString();
                tmp2.evLocation = rdr["Место проведения"].ToString();
                tmp2.evUsers = rdr["Участники"].ToString();
                tmp2.evContent = rdr["Содержание мероприятия"].ToString();
                tmp2.evDateEvent = rdr["Дата проведения"].ToString();
                tbStud2.Add(tmp2);
            }
            rdr.Close();
            return tbStud2;
        }
        List<tableStud3> groups()
        {
            List<tableStud3> tbStud3 = new();
            tableStud3 tmp3;
            tbStud3.Clear();
            sqlCommand = "SELECT * FROM `group`";
            cmd = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp3.gCodeG = rdr["Group_code"].ToString();
                tmp3.gFIO = rdr["FIO_curator"].ToString();
                tmp3.gGroupName = rdr["Group_Name"].ToString();
                tbStud3.Add(tmp3);
            }
            rdr.Close();
            return tbStud3;
        }
        List<tableStud4> invited()
        {
            List<tableStud4> tbStud4 = new();
            tableStud4 tmp4;
            tbStud4.Clear();
            sqlCommand = @"SELECT fk_Number_plan, Code_player, Educational_work_plan.`EVENT`, Invited_participants.FIO_invited, Invited_participants.Post, Invited_participants.Org_name FROM Educational_work_plan
JOIN Inviting_participants ON Educational_work_plan.Number_plan = Inviting_participants.fk_Number_plan
JOIN Invited_participants ON Inviting_participants.fk_Code_player = Invited_participants.Code_player;";
            cmd = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp4.invNumber = rdr["fk_Number_plan"].ToString();
                tmp4.invCodePlayer = rdr["Code_player"].ToString();
                tmp4.invEvent = rdr["EVENT"].ToString();
                tmp4.invPost = rdr["Post"].ToString();
                tmp4.invFIO = rdr["FIO_invited"].ToString();
                tmp4.invOrgName = rdr["Org_name"].ToString();
                tbStud4.Add(tmp4);
            }
            rdr.Close();
            return tbStud4;
        }
        void fillTable()
        {

            List<tableStud> tbStud = getTable();
            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = tbStud.Count;
            for (int i = 0; i < tbStud.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = tbStud[i].edNumber;
                dataGridView1.Rows[i].Cells[1].Value = tbStud[i].edPlan;
                dataGridView1.Rows[i].Cells[2].Value = tbStud[i].edName;
                dataGridView1.Rows[i].Cells[3].Value = tbStud[i].edDate;
                dataGridView1.Rows[i].Cells[4].Value = tbStud[i].edOtvetst;
                dataGridView1.Rows[i].Cells[5].Value = tbStud[i].edDateProved;
            }
        }
        void fillTable2()
        {
            List<tableStud2> tbStud2 = vozvrat();
            dataGridView2.Rows.Clear();

            dataGridView2.RowCount = tbStud2.Count;
            for (int i = 0; i < tbStud2.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = tbStud2[i].evIDGroup;
                dataGridView2.Rows[i].Cells[1].Value = tbStud2[i].evIDNumber;
                dataGridView2.Rows[i].Cells[2].Value = tbStud2[i].evEvent;
                dataGridView2.Rows[i].Cells[3].Value = tbStud2[i].evGroup;
                dataGridView2.Rows[i].Cells[4].Value = tbStud2[i].evLocation;
                dataGridView2.Rows[i].Cells[5].Value = tbStud2[i].evUsers;
                dataGridView2.Rows[i].Cells[6].Value = tbStud2[i].evContent;
                dataGridView2.Rows[i].Cells[7].Value = tbStud2[i].evDateEvent;
            }
        }
        void fillTable3()
        {
            List<tableStud3> tbStud3 = groups();
            dataGridView3.Rows.Clear();

            dataGridView3.RowCount = tbStud3.Count;
            for (int i = 0; i < tbStud3.Count; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = tbStud3[i].gCodeG;
                dataGridView3.Rows[i].Cells[1].Value = tbStud3[i].gFIO;
                dataGridView3.Rows[i].Cells[2].Value = tbStud3[i].gGroupName;
            }
        }
        void fillTable4()
        {
            List<tableStud4> tbStud4 = invited();
            dataGridView4.Rows.Clear();

            dataGridView4.RowCount = tbStud4.Count;
            for (int i = 0; i < tbStud4.Count; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = tbStud4[i].invNumber;
                dataGridView4.Rows[i].Cells[1].Value = tbStud4[i].invCodePlayer;
                dataGridView4.Rows[i].Cells[2].Value = tbStud4[i].invEvent;
                dataGridView4.Rows[i].Cells[3].Value = tbStud4[i].invFIO;
                dataGridView4.Rows[i].Cells[4].Value = tbStud4[i].invPost;
                dataGridView4.Rows[i].Cells[5].Value = tbStud4[i].invOrgName;
            }
        }

        public Form1(string ZRole, string OName)
        {
            InitializeComponent();

            string configPath = Path.Combine(Application.StartupPath, "config.ini");

            string[] lines = File.ReadAllLines(configPath);

            string server = "", database = "", user = "", password = "";

            foreach (string line in lines)
            {
                if (line.StartsWith("Server=")) server = line.Replace("Server=", "");
                if (line.StartsWith("Database=")) database = line.Replace("Database=", "");
                if (line.StartsWith("User=")) user = line.Replace("User=", "");
                if (line.StartsWith("Password=")) password = line.Replace("Password=", "");
            }

            string connString = $"Server={server};Database={database};Uid={user};Pwd={password};";

            try
            {
                conn = new MySqlConnection(connString);

                conn.Open();
                FIODayn.Text = OName;

                if (Convert.ToInt32(ZRole) != 1 && Convert.ToInt32(ZRole) != 2)
                {
                    // MessageBox.Show(Role);
                    администрированиеToolStripMenuItem.Visible = false;
                }
                else
                {
                    администрированиеToolStripMenuItem.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.BringToFront();
            pictureBox1.BringToFront();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            EditInvited();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddInvited();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddGroups();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddVospPlan();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EditVospPlan();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            EditGroup();
        }

        private void AddPlan_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                AddVospPlan();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                AddEvents();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                AddGroups();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                AddInvited();
            }
        }

        private void EditPlan_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                EditVospPlan();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                EditEvent();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                EditGroup();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                EditInvited();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.White;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.White;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.White;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.White;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.White;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.BackColor = Color.White;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.White;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.White;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.BackColor = Color.White;
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.BackColor = ColorTranslator.FromHtml("#e8e4e4");

        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.White;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.White;
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.BackColor = ColorTranslator.FromHtml("#e8e4e4");
        }

        private void администрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.ShowDialog();
        }

        private void сменитьУчётнуюЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Hide();
            authorization.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sqlCommand = @"SELECT fk_Number_plan, Code_player, Educational_work_plan.`EVENT`, Invited_participants.FIO_invited, Invited_participants.Post, Invited_participants.Org_name FROM Educational_work_plan
JOIN Inviting_participants ON Educational_work_plan.Number_plan = Inviting_participants.fk_Number_plan
JOIN Invited_participants ON Inviting_participants.fk_Code_player = Invited_participants.Code_player;";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable4();
            ContextFilter.ResetFilter(dataGridView4, contextFilterItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCommand = "SELECT Number_plan, The_direction_of_educational_work AS 'Направление', Event AS 'Название', Dates_event AS 'Сроки проведения', FIO_responsible_person AS 'Ответственный', A_note_about_the_event AS 'Дата проведения' FROM Educational_work_plan";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable();
            ContextFilter.ResetFilter(dataGridView1, contextFilterItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCommand = @"SELECT fk_Number_plan, fk_Group_Code, Educational_work_plan.`EVENT` AS 'Мероприятие', `group`.Group_Name AS 'Группа', Event_Location AS 'Место проведения', The_main_participants AS 'Участники', Event_content 'Содержание мероприятия', Date_Event AS 'Дата проведения' FROM `Event` 
JOIN `group` ON `group`.Group_code = `Event`.fk_Group_Code 
JOIN Educational_work_plan ON Educational_work_plan.Number_plan = `Event`.fk_Number_plan;";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable2();
            ContextFilter.ResetFilter(dataGridView2, contextFilterItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlCommand = "SELECT Group_code, FIO_curator, Group_Name FROM `group`";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable3();
            ContextFilter.ResetFilter(dataGridView3, contextFilterItem);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeleteVospPlan();
        }

        private void DeletePlan_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DeleteVospPlan();
            }
            if (tabControl1.SelectedIndex == 1)
            {
            }
            if (tabControl1.SelectedIndex == 2)
            {
                DeleteGroup();
            }
            if (tabControl1.SelectedIndex == 3)
            {
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount == 0)
            {
                MessageBox.Show("Нечего удалять");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Вы действительно хотите удалить запись?",
                    "Удаление записей",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int indRow = dataGridView4.CurrentRow.Index;
                    int idNumberPlan = Convert.ToInt32(dataGridView4.Rows[indRow].Cells[0].Value);
                    int idPlayer = Convert.ToInt32(dataGridView4.Rows[indRow].Cells[1].Value);
                    sqlCommand = $"DELETE FROM Invited_participants WHERE Code_player = '{idPlayer.ToString()}';";
                    sqlCommand = $"DELETE FROM Inviting_participants WHERE fk_Number_plan = '{idNumberPlan.ToString()}' AND fk_Code_player = '{idPlayer.ToString()}'";
                    cmd = new(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable4();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}