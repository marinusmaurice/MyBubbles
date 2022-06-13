using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyBubbles
{ 
    public class PPAF : FW
    {
        #region Variables
        private SolidBrush _brush;
        private System.Drawing.StringFormat _stringFormat;
        private Rectangle _rScreen;
        private System.Windows.Forms.Timer _viewClock;
        private Font _textFont;
        private string _text;
        private AnimateMode _mode;
        private uint _time;
        private GraphicsPath _gp;
        #endregion

    

        #region Overrided Drawing & Path Creation
        protected override void PerformPaint(PaintEventArgs e)
        {
            base.Show();
        }
       
            #endregion

            #region Timers
        protected void viewTimer(object sender, System.EventArgs e)
        {
            UpdatePosition();

            this.UpdateLayeredWindow();
            this.Show();
        }

        private void UpdatePosition()
        {
            if ((Left <= 0) || ((Left + (ballRadius * 2)) >= Screen.PrimaryScreen.Bounds.Width))
            {
                dx = -dx;
            }

            if ((Top <= 0) || ((Top + (ballRadius * 2)) >= Screen.PrimaryScreen.Bounds.Height))
            {
                dy = -dy;
            }

            x += dx;
            y += dy;
            this.Left = (int)x;
            this.Top = (int)y;
        }

        double ballRadius=0;
        double x = 0; //Screen.PrimaryScreen.Bounds.Width / 2;
        double y = 0;// Screen.PrimaryScreen.Bounds.Height - (225 / 2);
        double dx = 5;
        double dy = -5;


        public double Ang;
        private Timer _tim;

        public Timer Timer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tim;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tim != null)
                {
                    _tim.Tick -= viewTimer;
                }

                _tim = value;
                if (_tim != null)
                {
                    _tim.Tick += viewTimer;
                }
            }
        }
        public PPAF( )
        {
            Timer = new Timer();
            Timer.Interval = 5;
            Random random = new Random();
            ballRadius = 182 / 2;  //If one measures the ball in the picture then the diameter is around 182. The full image is around 225
            int inc = 10;
            x = random.Next(((int)ballRadius*2 + inc), (int)(Screen.PrimaryScreen.Bounds.Width - (ballRadius+ inc)));
            y = random.Next(((int)ballRadius*2 + inc), (int)(Screen.PrimaryScreen.Bounds.Height - (ballRadius+inc)));
            Left = (int)x;
            Top = (int)y;

            UpdatePosition();
        }

        public void PerPixelAlphaForm_Load(System.Object sender, System.EventArgs e)
        {
            //Timer.Enabled = true;
             
           
            base.Alpha = 100;
            base.Size = new Size((int)Math.Ceiling((decimal)todo.Width), (int)Math.Ceiling((decimal)todo.Height));
            
            base.Show();
        }


        #endregion


          
    }

}
