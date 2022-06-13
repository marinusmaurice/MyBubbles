using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBubbles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool started = false;
        List<PPAF> bubbleList = new List<PPAF>();

        public void CreateAllBubbles()
        {
            CreateBubble(Properties.Resources.Blue, "Blue");
            CreateBubble(Properties.Resources.Green, "Green");
            CreateBubble(Properties.Resources.Orange, "Orange");
            CreateBubble(Properties.Resources.Other1, "Other1");
            CreateBubble(Properties.Resources.Other2, "Other2");
            CreateBubble(Properties.Resources.Pink, "Pink");
            CreateBubble(Properties.Resources.Red, "Red");
            CreateBubble(Properties.Resources.Violate, "Violate");
            CreateBubble(Properties.Resources.Yellow, "Yellow");
        }

        public void CreateBubble(Bitmap bitmap, string name)
        {
            PPAF p = new PPAF();
            System.Random a = new System.Random();
            double d = a.NextDouble();
            p.UpdateLayeredWindow(bitmap, name);
            p.Ang = 1.57 * a.NextDouble();            
            p.PerPixelAlphaForm_Load(null, new EventArgs());
            p.Timer.Interval = (int)numericUpDown1.Value;
            //  p = null;
            bubbleList.Add(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void Start()
        {
            button1.Text = "Stop";
            foreach (var item in bubbleList)
            {
                item.Timer.Interval = (int)numericUpDown1.Value;
                item.Timer.Start();
            }
            started = true;
        }

        private void Stop()
        {
            button1.Text = "Start";
            foreach (var item in bubbleList)
            {
                item.Timer.Stop();
            }
            started = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stop();
            CreateAllBubbles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stop();
            foreach (var item in bubbleList)
            {
                item.Dispose();
            }
            bubbleList.Clear();
        }
    }
}
