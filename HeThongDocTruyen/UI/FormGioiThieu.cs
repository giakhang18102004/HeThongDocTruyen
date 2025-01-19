using HeThongDocTruyen.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongDocTruyen
{
    public partial class FormGioiThieu : Form
    {
        public FormGioiThieu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 9;
            if (panel2.Width >= 1201)
            {
                timer1.Stop();

                FormDangNhap dangNhap = new FormDangNhap(); 
                dangNhap.ShowDialog();
                this.Hide();
            }
        }

        private void FormGioiThieu_Load(object sender, EventArgs e)
        {
            panel2.Width = 0;
            timer1.Enabled = true;
            timer1.Interval = 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
