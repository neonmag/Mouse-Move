using Microsoft.VisualBasic.Devices;
using System.Linq.Expressions;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        int startX = 0;
        int startY = 0;
        Button button;
        bool clicked = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (e.X - startX < 0 && e.Y - startY < 0)
                {
                    button.Height = (e.Y - startY) * -1;
                    button.Width = (e.X - startX) * -1;
                    button.Location = new Point(e.X, e.Y);
                }
                else if (e.Y - startY < 0)
                {
                    button.Height = (e.Y - startY) * -1;
                    button.Width = e.X - startX;
                    button.Location = new Point(startX, e.Y);
                }
                else if (e.X - startX < 0)
                {
                    button.Height = e.Y - startY;
                    button.Width = (e.X - startX) * -1;
                    button.Location = new Point(e.X, startY);
                }
                else
                {
                    button.Height = e.Y - startY;
                    button.Width = e.X - startX;
                    button.Location = new Point(startX, startY);
                }
            }
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (e.X < startX && e.Y < startY)
                {
                    startX = e.X;
                    startY = e.Y;
                }
                else if (e.X < startX)
                {
                    startX = e.X;
                }
                else if (e.Y < startY)
                {
                    startY = e.Y;
                }
                this.Controls.Add(button);
                clicked = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
            clicked = true;
            button = new Button();
            this.Controls.Add(button);
        }
    }
}