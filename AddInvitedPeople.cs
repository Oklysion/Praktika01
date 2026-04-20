using Google.Protobuf.WellKnownTypes;
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

namespace Praktika01Uvarov
{
    public partial class AddInvitedPeople : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        public string sqlCommand;
        public AddInvitedPeople()
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

        private void button2_Click(object sender, EventArgs e)
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

        private void AddInvitedPeople_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                var sql = "select * from Educational_work_plan";
                MySqlCommand my = new(sql, conn);
                MySqlDataAdapter dd = new(my);
                DataTable dt = new();
                dd.Fill(dt);
                EventsCB.DataSource = dt;
                EventsCB.ValueMember = "Number_plan";
                EventsCB.DisplayMember = "EVENT";
                
            }
        }
    }
}
