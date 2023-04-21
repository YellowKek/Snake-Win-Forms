using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamee
{
    public partial class Form1 : Form
    {
        //private bool inGame = true;
        private Snake snake = new Snake();
        private bool appleExist = false;
        private int[] appleCoords = createApple();
        private Brush headBrush = new SolidBrush(Color.Tan);
        private Brush segBrush = new SolidBrush(Color.Yellow);
        private Brush appleBrush = new SolidBrush(Color.Red);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private static int[] createApple()
        {
            Random random = new Random();
            int randomNumberX = random.Next(0, 441);
            int roundedNumberX = (int)Math.Round(randomNumberX / 10.0) * 10;
            int randomNumberY = random.Next(0, 281);
            int roundedNumberY = (int)Math.Round(randomNumberY / 10.0) * 10;
            // [apple x, apple y]
            return new int[] { roundedNumberX , roundedNumberY };
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // graphic
            Graphics g = e.Graphics;
            Score.Text = $"Score: {snake.score}";
            
            g.FillEllipse(appleBrush, appleCoords[0], appleCoords[1], 10, 10);
            for (int i = 0; i < snake.segments.Count; i++)
            {
                if (i == 0)
                {
                    g.FillRectangle(headBrush, snake.segments[i].x, snake.segments[i].y, 10, 10);
                }
                else
                {
                    g.FillRectangle(segBrush, snake.segments[i].x, snake.segments[i].y, 10, 10);
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
               snake.direction = "Down";
            }
            else if (e.KeyCode == Keys.Up)
            {
                snake.direction = "Up";
            }
            else if (e.KeyCode == Keys.Right)
            {
                snake.direction = "Right";
            }
            else if (e.KeyCode == Keys.Left)
            {
                snake.direction = "Left";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (snake.appleCheck(appleCoords))
            {
                appleCoords = createApple();
                snake.score++;
                snake.addSegment();
            }
            snake.move();
            if (snake.checkDeath())
            {
                timer1.Stop();
                death_label.Visible = true;
            }
                
            panel1.Invalidate();
        }
    }
}
