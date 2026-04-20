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
    public partial class Events : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;
        public Events()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show
                (
                "Вы действительно хотите сохранить?",
                "Сохранение записи",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );
            if (DialogResult == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
            }
            if (DialogResult == DialogResult.No)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Events_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                sqlCommand = "SELECT * FROM Educational_work_plan";
                cmd = new(sqlCommand, conn);
                MySqlDataAdapter adapter = new(cmd);
                DataTable dt = new();
                adapter.Fill(dt);
                NameCB.DataSource = dt;
                NameCB.ValueMember = "Number_plan";
                NameCB.DisplayMember = "EVENT";

                sqlCommand = "SELECT * FROM `group`";
                cmd = new(sqlCommand, conn);
                MySqlDataAdapter adapter2 = new(cmd);
                DataTable dt2 = new();
                adapter2.Fill(dt2);
                EventNameCB.DataSource = dt2;
                EventNameCB.ValueMember = "Group_code";
                EventNameCB.DisplayMember = "Group_Name";
            }
        }
    }
}
