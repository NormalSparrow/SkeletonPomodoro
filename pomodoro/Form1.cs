using System;
using System.Drawing;
using System.Windows.Forms;

namespace pomodoro
{
    public partial class Form1 : Form
    {

        private TimeSpan timeleft = TimeSpan.FromMinutes(25);

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            PomoTimer.Interval = 1000;
            PomoTimer.Tick += PomoTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = timeleft.ToString(@"mm\:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!PomoTimer.Enabled)
            {
                if (timeleft == TimeSpan.FromMinutes(0))
                {
                    timeleft = TimeSpan.FromMinutes(25);
                }
                PomoTimer.Start();
                button1.BackColor = Color.Teal;
                button1.Text = "Stop";
            }
            else
            {
                PomoTimer.Stop();
                button1.BackColor = Color.Red;
                button1.Text = "Start";
            }
        }

        private void PomoTimer_Tick(object sender, EventArgs e)
        {
            if (timeleft.TotalSeconds > 0)
            {
                timeleft = timeleft - TimeSpan.FromSeconds(1);
                label1.Text = timeleft.ToString(@"mm\:ss");
            }
            else
            {
                StopTimer();
                label1.Text = "Time Up";

            }
        }
        private void StopTimer()
        {
            PomoTimer.Stop();
            button1.BackColor = Color.Red;
            button1.Text = "Start";
        }
    }
}
