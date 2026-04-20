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
    public partial class ThisPlanVospitat : Form
    {
        public ThisPlanVospitat()
        {
            InitializeComponent();
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

        private void ThisPlanVospitat_Load(object sender, EventArgs e)
        {

        }
    }
}
