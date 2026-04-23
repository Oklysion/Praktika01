using ArchiveFund;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Text;

namespace Praktika01Uvarov
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;

        public static Form1 Instance;
        void InfoInvited()
        {
            sqlCommand = @"SELECT fk_Number_plan, Code_player, Educational_work_plan.`EVENT`, Invited_participants.FIO_invited, Invited_participants.Post, Invited_participants.Org_name FROM Educational_work_plan
JOIN Inviting_participants ON Educational_work_plan.Number_plan = Inviting_participants.fk_Number_plan
JOIN Invited_participants ON Inviting_participants.fk_Code_player = Invited_participants.Code_player;";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable4();
            ContextFilter.ResetFilter(dataGridView4, contextFilterItem);
        }
        void InfoEvent()
        {
            sqlCommand = @"SELECT fk_Number_plan, fk_Group_Code, Educational_work_plan.`EVENT` AS 'Мероприятие', `group`.Group_Name AS 'Группа', Event_Location AS 'Место проведения', The_main_participants AS 'Участники', Event_content 'Содержание мероприятия', Date_Event AS 'Дата проведения' FROM `Event` 
JOIN `group` ON `group`.Group_code = `Event`.fk_Group_Code 
JOIN Educational_work_plan ON Educational_work_plan.Number_plan = `Event`.fk_Number_plan;";
            cmd = new MySqlCommand(sqlCommand, conn);
            cmd.ExecuteNonQuery();
            fillTable2();
            ContextFilter.ResetFilter(dataGridView2, contextFilterItem);
        }

        public void AddVospPlan()
        {
            try
            {
                ThisPlanVospitat thisPlanVospitat = new ThisPlanVospitat();
                if (thisPlanVospitat.ShowDialog() == DialogResult.OK)
                {
                    if (thisPlanVospitat.txtNaprav.Text == "" || thisPlanVospitat.txtNazvan.Text == "" || thisPlanVospitat.txtSroki.Text == "" || thisPlanVospitat.txtFIOOtvet.Text == "" || thisPlanVospitat.txtNaprav.Text == " " || thisPlanVospitat.txtNazvan.Text == " " || thisPlanVospitat.txtSroki.Text == " " || thisPlanVospitat.txtFIOOtvet.Text == " ")
                    {
                        MessageBox.Show("Заполните поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddVospPlan();
                    }
                    else
                    {
                        sqlCommand = @"START TRANSACTION; INSERT INTO Educational_work_plan (The_direction_of_educational_work, Educational_work_plan.`EVENT`, Dates_event, FIO_responsible_person, A_note_about_the_event)
                VALUES ('" + thisPlanVospitat.txtNaprav.Text + "', '" + thisPlanVospitat.txtNazvan.Text + "', '" + thisPlanVospitat.txtSroki.Text + "', '" + thisPlanVospitat.txtFIOOtvet.Text + "', '" + thisPlanVospitat.dtTashkent.Value.ToString("yyyy") + "'); COMMIT;";
                        cmd = new MySqlCommand(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable();
                    }
                }
            }
            catch { }
        }
        public void AddEvents()
        {
            try
            {
                Events events = new Events();
                if (events.ShowDialog() == DialogResult.OK)
                {
                    if (events.NameCB.SelectedItem == "" || events.NameCB.SelectedItem == " " || events.EventNameCB.SelectedItem == "" || events.EventNameCB.SelectedItem == " " || events.txtMesto.Text == " " || events.txtMesto.Text == " " || events.txtOsn.Text == "" || events.txtOsn.Text == " " || events.txtKratko.Text == "" || events.txtKratko.Text == " ")
                    {
                        MessageBox.Show("Заполните поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddEvents();
                    }
                    else
                    {
                        sqlCommand = @"START TRANSACTION; INSERT INTO `Event` (fk_Number_plan, fk_Group_Code, Event_Location, The_main_participants, Event_content, Date_Event) 
                VALUES (' " + events.NameCB.SelectedValue + "', '" + events.EventNameCB.SelectedValue + "', '" + events.txtMesto.Text + "', '" + events.txtOsn.Text + "', '" + events.txtKratko.Text + "', '" + events.dtDate.Value.ToString("yyyy-MM-dd") + "'); COMMIT;";
                        cmd = new MySqlCommand(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable2();
                    }
                }
            }
            catch { }
        }
        public void AddGroups()
        {
            try
            {
                Groups groups = new Groups();
                if (groups.ShowDialog() == DialogResult.OK)
                {
                    if (groups.txtFIO.Text == "" || groups.txtNameGroup.Text == "")
                    {
                        MessageBox.Show("Заполните поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddGroups();
                    }
                    else
                    {
                        sqlCommand = @"START TRANSACTION; INSERT INTO `group` (FIO_curator, Group_Name)
                VALUES ('" + groups.txtFIO.Text + "', '" + groups.txtNameGroup.Text + "'); COMMIT;";
                        cmd = new MySqlCommand(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable3();
                    }
                }
            }
            catch { }
        }
        public void AddInvited()
        {
            try
            {
                AddInvitedPeople addInvitedPeople = new AddInvitedPeople();
                if (addInvitedPeople.ShowDialog() == DialogResult.OK)
                {
                    if (addInvitedPeople.txtFIO.Text == "" || addInvitedPeople.txtFIO.Text == " " || addInvitedPeople.txtPost.Text == "" || addInvitedPeople.txtPost.Text == " " || addInvitedPeople.txtOrgName.Text == "" || addInvitedPeople.txtOrgName.Text == " " || addInvitedPeople.EventsCB.SelectedItem == " " || addInvitedPeople.EventsCB.SelectedItem == "")
                    {
                        MessageBox.Show("Заполните поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddInvited();
                    }
                    else
                    {
                        sqlCommand = @"START TRANSACTION; INSERT INTO Invited_participants (FIO_invited, Post, Org_name)
                VALUES ('" + addInvitedPeople.txtFIO.Text + "', '" + addInvitedPeople.txtPost.Text + "', '" + addInvitedPeople.txtOrgName.Text + "'); COMMIT;";
                        cmd = new MySqlCommand(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        sqlCommand = @"START TRANSACTION; INSERT INTO Inviting_participants (fk_Number_plan, fk_Code_player)
                VALUES ( " + addInvitedPeople.EventsCB.SelectedValue + ", " + "LAST_INSERT_ID()); COMMIT;";
                        cmd = new MySqlCommand(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable4();
                    }
                }
            }
            catch { }
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
        public void EditGroup()
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
                    sqlCommand += "The_direction_of_educational_work = '" + n1 + "', EVENT = '" + n2 + "', Dates_event = '" + n3 + "', FIO_responsible_person = '" + n4 + "', A_note_about_the_event = '" + thisPlanVospitat.dtTashkent.Value.ToString("yyyy") + "'";
                    sqlCommand += " WHERE Number_plan = " + idStud.ToString() + ";";
                    cmd = new MySqlCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable();
                }
            }
        }
        void DeleteVospPlan()
        {
            try
            {
                if (dataGridView1.RowCount == 0)
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
                        InfoEvent();
                        InfoInvited();
                        int indRow = dataGridView1.CurrentRow.Index;
                        int idNumberPlan = Convert.ToInt32(dataGridView1.Rows[indRow].Cells[0].Value);
                        if (dataGridView2.RowCount != 0 || dataGridView4.RowCount != 0)
                        {
                            if(dataGridView2.RowCount != 0 && indRow >= dataGridView2.RowCount)
                            {
                            int idNumberPlanEvent = Convert.ToInt32(dataGridView2.Rows[indRow].Cells["EventIDNumber"].Value);
                            sqlCommand = $"DELETE FROM `event` WHERE fk_Number_plan = {idNumberPlanEvent.ToString()};";
                            cmd = new(sqlCommand, conn);
                            cmd.ExecuteNonQuery();
                            fillTable2();
                            }
                            if (dataGridView4.RowCount != 0 && indRow >= dataGridView4.RowCount)
                            {
                                sqlCommand = $"DELETE FROM `inviting_participants` WHERE fk_Number_plan = {idNumberPlan.ToString()};";
                                cmd = new(sqlCommand, conn);
                                cmd.ExecuteNonQuery();
                                int idPlayer = Convert.ToInt32(dataGridView4.Rows[indRow].Cells[1].Value);
                                sqlCommand = $"DELETE FROM Invited_participants WHERE Code_player = '{idPlayer.ToString()}';";
                                cmd = new(sqlCommand, conn);
                                cmd.ExecuteNonQuery();
                                fillTable4();
                            }
                            sqlCommand = $"DELETE FROM Educational_work_plan WHERE Number_plan = {idNumberPlan.ToString()}";
                            cmd = new(sqlCommand, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                fillTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteGroup()
        {
            try
            {
                if (dataGridView3.RowCount == 0)
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
                        int indRow = dataGridView3.CurrentRow.Index;
                        int idGroup = Convert.ToInt32(dataGridView3.Rows[indRow].Cells[0].Value);
                        sqlCommand = $"DELETE FROM `event` WHERE fk_Group_Code = '{idGroup.ToString()}';";
                        cmd = new(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        sqlCommand = $"DELETE FROM `group` WHERE Group_code = '{idGroup.ToString()}';";
                        cmd = new(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable3();

                    }
                }
            }
            catch { }
        }
        void DeleteInvited()
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
                    sqlCommand = $"DELETE FROM Inviting_participants WHERE fk_Number_plan = '{idNumberPlan.ToString()}' AND fk_Code_player = '{idPlayer.ToString()}';";
                    cmd = new(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    sqlCommand = $"DELETE FROM Invited_participants WHERE Code_player = '{idPlayer.ToString()}';";
                    cmd = new(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable4();
                }
            }
        }
        void DeleteEvent()
        {
            try
            {
                if (dataGridView2.RowCount == 0)
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
                        int indRow = dataGridView2.CurrentRow.Index;
                        int idGroup = Convert.ToInt32(dataGridView2.Rows[indRow].Cells[0].Value);
                        int idNumber = Convert.ToInt32(dataGridView2.Rows[indRow].Cells[1].Value);
                        sqlCommand = $"DELETE FROM `event` WHERE fk_Group_Code = '{idGroup.ToString()}' AND fk_Number_plan = '{idNumber.ToString()}';";
                        cmd = new(sqlCommand, conn);
                        cmd.ExecuteNonQuery();
                        fillTable2();

                    }
                }
            }
            catch { }
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
                dataGridView1.Rows[i].Cells[5].Value = tbStud[i].edDateProved.ToString();
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
                dataGridView2.Rows[i].Cells[7].Value = DateTime.Parse(tbStud2[i].evDateEvent).ToString("dd.MM.yyyy");
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
                fullNameUSER.Text = OName;

                Instance = this;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 1000 };
                timer.Tick += (sender, e) =>
                {
                    DateTS.Text = $"{DateTime.Now.ToLocalTime()}";
                };
                timer.Start();

                if (Convert.ToInt32(ZRole) != 1 && Convert.ToInt32(ZRole) != 2)
                {
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
                DeleteEvent();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                DeleteGroup();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                DeleteInvited();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DeleteInvited();
        }

        void SearchVospPlan()
        {
            string search = txtSearch.Text.Trim();

            string sql = @"SELECT
    E.Number_plan AS 'Номер плана',
    E.The_direction_of_educational_work AS 'Направление_образовательной_работы',
    E.EVENT AS 'Мероприятие',
    E.Dates_event AS 'Дата_мероприятия',
    E.FIO_responsible_person AS 'ФИО_ответственного',
    E.A_note_about_the_event AS 'Примечание_о_мероприятии'
FROM `Event` p
JOIN `group` g ON g.Group_code = p.fk_Group_Code
JOIN `Educational_work_plan` E ON E.Number_plan = p.fk_Number_plan
WHERE
    @Search = ''
    OR (
        CONCAT(
            E.The_direction_of_educational_work, ' ',
            E.EVENT, ' ',
            E.Dates_event, ' ',
            E.FIO_responsible_person, ' ',
            E.A_note_about_the_event
        ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(@Search, ',', 1)), '%')
        AND
        CONCAT(
            E.The_direction_of_educational_work, ' ',
            E.EVENT, ' ',
            E.Dates_event, ' ',
            E.FIO_responsible_person, ' ',
            E.A_note_about_the_event
        ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(SUBSTRING_INDEX(@Search, ',', 2), ',', -1)), '%')
        AND
        CONCAT(
            E.The_direction_of_educational_work, ' ',
            E.EVENT, ' ',
            E.Dates_event, ' ',
            E.FIO_responsible_person, ' ',
            E.A_note_about_the_event
        ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(SUBSTRING_INDEX(@Search, ',', 3), ',', -1)), '%')
    )
ORDER BY E.Number_plan DESC;

";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Search", search);

            MySqlDataReader reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[1].Value = reader["Направление_образовательной_работы"].ToString();
                dataGridView1.Rows[row].Cells[2].Value = reader["Мероприятие"].ToString();
                dataGridView1.Rows[row].Cells[5].Value = reader["Примечание_о_мероприятии"].ToString();
                dataGridView1.Rows[row].Cells[4].Value = reader["ФИО_ответственного"].ToString();
                dataGridView1.Rows[row].Cells[3].Value = reader["Дата_мероприятия"].ToString();
            }
            reader.Close();
        }
        void SearchEvent()
        {
            string search = txtSearch.Text.Trim();

            string sql = @"SELECT
     E.`EVENT` AS 'Мероприятие',
     g.Group_Name AS 'Группа',
     p.Event_Location,
     p.The_main_participants,
     p.Event_content,
     p.Date_Event
 FROM `Event` p
 JOIN `group` g ON g.Group_code = p.fk_Group_Code
 JOIN Educational_work_plan E ON E.Number_plan = p.fk_Number_plan
 WHERE
     @Search = ''
     OR (
         CONCAT(
             g.Group_Name, ' ',
             p.Event_Location, ' ',
             p.The_main_participants, ' ',
             p.Event_content, ' ',
             E.`EVENT`, ' ',
             p.Date_Event
         ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(@Search, ',', 1)), '%')
         AND
         CONCAT(
             g.Group_Name, ' ',
             p.Event_Location, ' ',
             p.The_main_participants, ' ',
             p.Event_content, ' ',
             E.`EVENT`, ' ',
             p.Date_Event
         ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(SUBSTRING_INDEX(@Search, ',', 2), ',', -1)), '%')
         AND
         CONCAT(
             g.Group_Name, ' ',
             p.Event_Location, ' ',
             p.The_main_participants, ' ',
             p.Event_content, ' ',
             E.`EVENT`, ' ',
             p.Date_Event
         ) LIKE CONCAT('%', TRIM(SUBSTRING_INDEX(SUBSTRING_INDEX(@Search, ',', 3), ',', -1)), '%')
     )
 ORDER BY p.fk_Number_plan DESC;";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Search", search);

            rdr = cmd.ExecuteReader();

            dataGridView2.Rows.Clear();

            while (rdr.Read())
            {
                int row = dataGridView2.Rows.Add();
                dataGridView2.Rows[row].Cells[2].Value = rdr["Мероприятие"].ToString();
                dataGridView2.Rows[row].Cells[3].Value = rdr["Группа"].ToString();
                dataGridView2.Rows[row].Cells[4].Value = rdr["Event_Location"].ToString();
                dataGridView2.Rows[row].Cells[5].Value = rdr["The_main_participants"].ToString();
                dataGridView2.Rows[row].Cells[6].Value = rdr["Event_content"].ToString();
                dataGridView2.Rows[row].Cells[7].Value = Convert.ToDateTime(rdr["Date_Event"]).ToString("yyyy.MM.dd");
            }
            rdr.Close();
        }
        void SearchGroup()
        {
            string search = txtSearch.Text.Trim();

            string sql = @"
SELECT
t.Group_code,
t.FIO_curator,
t.Group_Name
FROM `group` t
WHERE
(@Search = '' OR
t.FIO_curator LIKE CONCAT('%', @Search, '%') OR
t.Group_Name LIKE CONCAT('%', @Search, '%'))
ORDER BY t.Group_code DESC";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Search", search);

            rdr = cmd.ExecuteReader();

            dataGridView3.Rows.Clear();

            while (rdr.Read())
            {
                int row = dataGridView3.Rows.Add();
                dataGridView3.Rows[row].Cells[1].Value = rdr["FIO_curator"].ToString();
                dataGridView3.Rows[row].Cells[2].Value = rdr["Group_Name"].ToString();
            }
            rdr.Close();
        }
        void SearchInvited()
        {
            string search = txtSearch.Text.Trim();

            string sql = @"SELECT
    t.Code_player,
    E.`EVENT`,
    t.FIO_invited,
    t.Post,
    t.Org_name
FROM `Invited_participants` t
JOIN Inviting_participants ig ON t.Code_player = ig.fk_Code_player
JOIN Educational_work_plan E ON E.Number_plan = ig.fk_Number_plan
WHERE
    (@Search = '' OR
    E.`EVENT` LIKE CONCAT('%', @Search, '%') OR
    t.FIO_invited LIKE CONCAT('%', @Search, '%') OR
    t.Post LIKE CONCAT('%', @Search, '%') OR
    t.Org_name LIKE CONCAT('%', @Search, '%'))
ORDER BY t.Code_player DESC;";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Search", search);

            rdr = cmd.ExecuteReader();

            dataGridView4.Rows.Clear();

            while (rdr.Read())
            {
                int row = dataGridView4.Rows.Add();
                dataGridView4.Rows[row].Cells[2].Value = rdr["EVENT"].ToString();
                dataGridView4.Rows[row].Cells[3].Value = rdr["FIO_invited"].ToString();
                dataGridView4.Rows[row].Cells[4].Value = rdr["Post"].ToString();
                dataGridView4.Rows[row].Cells[5].Value = rdr["Org_name"].ToString();
            }
            rdr.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                SearchVospPlan();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                SearchEvent();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                SearchGroup();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                SearchInvited();
            }

        }

        private string GenerateHTMLReport()
        {
            StringBuilder html = new StringBuilder();


            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=\"ru\">");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset=\"UTF-8\">");
            html.AppendLine("<title>Отчёт куратора</title>");
            html.AppendLine("<style>");


            html.AppendLine("body { font-family: 'Times New Roman', serif; font-size: 14pt; }");

            html.AppendLine("table { border-collapse: collapse; width: 100%; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".curator-info { margin-top: 30px; }");

            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");


            string curatorFIO = "Не выбран";
            string groupName = "Не выбрана";
            string selectRabota = "Не выбрано";

            if (dataGridView3.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView3.SelectedRows[0];
                curatorFIO = selectedRow.Cells[1].Value?.ToString() ?? "Не указан";
                groupName = selectedRow.Cells[2].Value?.ToString() ?? "Не указана";
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                selectRabota = selectedRow.Cells[3].Value?.ToString() ?? "Не указано";
            }

            html.AppendLine($"Отчёт куратора {curatorFIO} группы {groupName} о проделанной работе с {selectRabota}");

            html.AppendLine("<table>");
            html.AppendLine("<thead>");
            html.AppendLine("<tr><th>№</th><th>Название мероприятия</th><th>Дата проведения</th><th>Краткое содержание</th></tr>");
            html.AppendLine("</thead>");
            html.AppendLine("<tbody>");

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string eventGroupName = row.Cells[3].Value?.ToString() ?? "";

                if (eventGroupName == groupName)
                {
                    html.AppendLine("<tr>");

                    string col1 = row.Cells[1].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + col1 + "</td>");

                    string col2 = row.Cells[2].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + col2 + "</td>");

                    string col3 = row.Cells[7].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + col3 + "</td>");

                    string col4 = row.Cells[6].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + col4 + "</td>");

                    html.AppendLine("</tr>");
                }
            }

            html.AppendLine("</tbody>");
            html.AppendLine("</table>");


            html.AppendLine("<div class=\"curator-info\">");
            html.AppendLine(@"Дополнительная информация о проведенной воспитательной работе: При этом еженедельно
                              проводились беседы из цикла «Разговоры о важном» по следующим темам: 1. 165-летие со дня 
                              рождения К.Э. Циолковского; 2. День пожилых людей; 3. День учителя; 4. День отца; 5. День
                              музыки; 6. Россия — мировой лидер атомной отрасли; 7. День народного единства; 8. Мы разные,
                              мы вместе; 9. День матери; 10. Символы России; 11. Волонтёры России; 12. День Конституции; 13.
                              День Героев Отечества; 14. Новый год. Семейные праздники и мечты.");


            html.AppendLine("<pre>Куратор___________________\t\t\t\t\t\t\tПодпись___________________</pre>");
            DateTime dateTime = DateTime.Now;
            html.AppendLine("<p>" + dateTime.ToString("dd.MM.yyyy") + "</p>");

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string htmlContent = GenerateHTMLReport();
            string filePath = @"Report.html"; // Укажите путь к файлу

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.Write(htmlContent);
            }

            MessageBox.Show("Отчёт сохранён в " + filePath);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }
    }
}