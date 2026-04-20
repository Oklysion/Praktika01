using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Praktika01Uvarov
{
    public partial class Authorization : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;

        public bool CheckedDB()
        {
            string configPath = Path.Combine(Application.StartupPath, "mrcheck.ini");

            if (!File.Exists(configPath))
            {
                string createFile = @"[Database]

Server=localhost
Database=information_schema
User=root
Password=";

                string filePath = "mrcheck.ini";
                File.WriteAllText(filePath, createFile);

            }
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

            //  метод для проверки существует ли база данных (по её имени).
            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                sqlCommand = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'OtdelVospitat';";
                cmd = new MySqlCommand(sqlCommand, conn);
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        void Check()
        {
            string backupFileData = "OtdelVospitatData.sql";
            string backupFileNoData = "OtdelVospitatNoData.sql";

            if (Convert.ToInt32(CheckedDB()) == 0)
            {
                string configPath = Path.Combine(Application.StartupPath, "mrcheck.ini");

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

                using (conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        DialogResult r = MessageBox.Show
                                (
                                "Нажмите ДА - чтобы создать заполненную базу данных, Нажмите НЕТ - чтобы создать пустую базу данных",
                                "Выбор действий",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                                );

                        if (r == DialogResult.Yes)
                        {
                            DialogResult r2 = MessageBox.Show
                                (
                                "Вы действительно хотите создать заполненную базу данных?",
                                "Выбор действий",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                                );
                            if (r2 == DialogResult.Yes)
                            {
                                mb.ImportFromFile(backupFileData);
                            }
                            if (r2 == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (r == DialogResult.No)
                        {
                            DialogResult r3 = MessageBox.Show
                                (
                                "Вы действительно хотите создать пустую базу данных?",
                                "Выбор действий",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                                );
                            if (r3 == DialogResult.Yes)
                            {
                                mb.ImportFromFile(backupFileNoData);
                            }
                            if (r3 == DialogResult.No)
                            {
                                return;
                            }
                        }

                    }
                }
            }

            if (Convert.ToInt32(CheckedDB()) == 1)
            {
            }
        }

        public Authorization()
        {
            InitializeComponent();
            Check();

            string configPath = Path.Combine(Application.StartupPath, "config.ini");

            if (!File.Exists(configPath))
            {
                string createFile = @"[Database]

Server=localhost
Database=OtdelVospitat
User=root
Password=";

                string filePath = "config.ini";
                File.WriteAllText(filePath, createFile);

            }
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
            catch
            {
                MessageBox.Show("Ошибка подключения!");
            }
        }
        public string Z, O;
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                string fName = "", fLogin = "", fPassword = "", fRole = "";
                sqlCommand = "SELECT * FROM Users WHERE username = '" + txtLogin.Text + "';";
                cmd = new MySqlCommand(sqlCommand, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fName = rdr["fullName"].ToString();
                    fLogin = rdr["username"].ToString();
                    fPassword = rdr["password"].ToString();
                    fRole = rdr["role_FK"].ToString();

                }
                Z = fRole;
                O = fName;
                rdr.Close();
                cmd = new MySqlCommand("SELECT SHA2(@pass, 512)", conn);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text.Trim());

                string hashedInputPassword = cmd.ExecuteScalar().ToString();
                if (txtLogin.Text == "" && txtPass.Text == "")
                {

                }
                else
                {
                    if (fLogin != txtLogin.Text || fPassword != hashedInputPassword)
                    {
                        MessageBox.Show("Неверный логин или пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Form1 form = new Form1(Z,O);
                        this.Hide();
                        form.Show();
                        conn.Close();
                    }
                }
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("ShowOKO.jpg");
            txtPass.PasswordChar = '\0';
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("ZakritoOKO.jpg");
            txtPass.PasswordChar = '*';
        }
    }
}
