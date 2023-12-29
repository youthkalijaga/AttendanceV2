using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceV2
{
    public partial class ParticipantForm : Form
    {
        public ParticipantForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            timer1.Start();

        }

        private void Btn_attend_Click(object sender, EventArgs e)
        {

        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();
            label_currentTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
