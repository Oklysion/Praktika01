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
    public partial class Groups : Form
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Groups_Load(object sender, EventArgs e)
        {

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
    }
}
