using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Praktika01Uvarov
{
    public partial class Users : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;
        struct tableStud
        {
            public string uID, uLogin, uRole;
        }
        public string SSSR;
        List<tableStud> getTable()
        {
            List<tableStud> tbStud = new List<tableStud>();
            tableStud tmp;
            tbStud.Clear();
            sqlCommand = "SELECT id_user, username, roles.roleName FROM Users JOIN roles ON Users.role_FK = roles.id_role;";
            cmd = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp.uID = rdr["id_user"].ToString();
                tmp.uLogin = rdr["username"].ToString();
                tmp.uRole = rdr["roleName"].ToString();
                tbStud.Add(tmp);
            }
            SSSR = tmp.uLogin = rdr["username"].ToString();
            rdr.Close();
            return tbStud;
        }
        void fillTable()
        {

            List<tableStud> tbStud = getTable();
            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = tbStud.Count;
            for (int i = 0; i < tbStud.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = tbStud[i].uID;
                dataGridView1.Rows[i].Cells[1].Value = tbStud[i].uLogin;
                dataGridView1.Rows[i].Cells[2].Value = tbStud[i].uRole;
            }
        }

        public Users()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения!" + ex.Message);
            }
        }
        private void Users_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                sqlCommand = "SELECT id_user, username, roles.roleName FROM Users JOIN roles ON Users.role_FK = roles.id_role;";
                cmd = new MySqlCommand(sqlCommand, conn);
                cmd.ExecuteNonQuery();
                fillTable();

                var sql = "select * from roles";
                MySqlCommand my = new(sql, conn);
                MySqlDataAdapter dd = new(my);
                DataTable dt = new();
                dd.Fill(dt);
                RoleCombBox.DataSource = dt;
                RoleCombBox.ValueMember = "id_role";
                RoleCombBox.DisplayMember = "roleName";
            }
        }

        public bool ExportToFile(string filePath, string? database = null)
        {
            try
            {
                using var mySqlBackup = new MySqlBackup(conn.CreateCommand());
                mySqlBackup.ExportInfo.AddCreateDatabase = true;
                mySqlBackup.ExportToFile(filePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}");
                return false;
            }
        }

        public bool ImportFromFile(string filePath)
        {
            try
            {
                using var mySqlBackup = new MySqlBackup(conn.CreateCommand());
                mySqlBackup.ImportFromFile(filePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: {ex.Message}");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFIO.Text == "" || txtFIO.Text == " " || txtLLogin.Text == "" || txtLLogin.Text == " " || txtPas.Text == "" || txtPas.Text == " " || RoleCombBox.SelectedItem == "" || RoleCombBox.SelectedItem == " " || RoleCombBox.Text == "" || RoleCombBox.SelectedItem == "" || RoleCombBox.SelectedItem == " ")
                {
                    MessageBox.Show("Заполните поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtLLogin.Text != "SSSR")
                    {
                        sqlCommand = $"INSERT INTO Users (fullName, username, PASSWORD, role_FK) VALUES ('{txtFIO.Text}', '{txtLLogin.Text}', SHA2(@pass, 512), {RoleCombBox.SelectedValue.ToString()});";
                        cmd = new(sqlCommand, conn);
                        cmd.Parameters.AddWithValue("@pass", txtPas.Text.Trim().ToString());
                        cmd.ExecuteNonQuery();
                        fillTable();
                    }
                    else
                    {
                        MessageBox.Show($"Невозможно добавить пользователя: {SSSR}");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                            "Вы действительно хотите удалить запись?",
                            "Удаление записей",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (SSSR != "SSSR")
                {
                    int indRow = dataGridView1.CurrentRow.Index;
                    int idUsers = Convert.ToInt32(dataGridView1.Rows[indRow].Cells[0].Value);
                    sqlCommand = $"DELETE FROM Users WHERE id_user = '{idUsers.ToString()}'";
                    cmd = new(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    fillTable();
                }
                else
                {
                    MessageBox.Show($"Невозможно удалить пользователя: {SSSR}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Выберите место сохранения резервной копии",
                FileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите создать резервную копию?\n\nПуть сохранения: {saveDialog.FileName}",
                    "Подтверждение создания резервной копии",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = ExportToFile(saveDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show(
                            "Резервная копия успешно создана!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Произошла ошибка при создании резервной копии.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Выберите файл резервной копии для восстановления"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите восстановить базу данных из выбранной копии?\n\nФайл: {openDialog.FileName}\n\nВнимание: все текущие данные могут быть перезаписаны!",
                    "Подтверждение восстановления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = ImportFromFile(openDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show(
                            "Восстановление завершено успешно!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Произошла ошибка при восстановлении базы данных.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void txtPas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void txtLLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void RoleCombBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }
    }
}

