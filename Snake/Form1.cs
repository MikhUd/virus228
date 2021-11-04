using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private int direction;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OKP);
            head.Visible = false;
        }

        private void OKP(object s, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString()) 
            {
                case "W":
                    direction = 2;
                    break;
                case "A":
                    direction = 3;
                    break;
                case "S":
                    direction = 4;
                    break;
                case "D":
                    direction = 1;
                    break;
            }

            switch (e.KeyCode.ToString())
            {
                case "Up":
                    direction = 2;
                    break;
                case "Left":
                    direction = 3;
                    break;
                case "Down":
                    direction = 4;
                    break;
                case "Right":
                    direction = 1;
                    break;
            }

            if (e.KeyCode.ToString() == "G") {
                MessageBox.Show(head.Location.X + " ");
            }

        }
            

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] == head)
                    continue;

                panel1.Controls[i].Enabled = false;
                panel1.Controls[i].Dispose();
                i--;
            }
            head.Visible = true;
            direction = 1;
            SetTimeout(kek, 170);
            SetTimeout(addVkusnyashka, 5000);
        }

        public void kek() 
        {
            for (var i = 0; i < vkus.Count; i++)
            {
                if (
                    head.Location.X == vkus[i].Location.X &&
                    head.Location.Y == vkus[i].Location.Y
                    ) {
                    vkus[i].Location = new Point(1000, 1000);
                    var b = new Button();
                    b.Size = new Size(40, 40);
                    b.BackColor = Color.Green;
                    b.Text = "";
   
                    b.Location = new Point(-50, -50);
                    panel1.Controls.Add(b);
                    body.Add(b);
                }
            }
            for (var i = 0; i < body.Count; i++)
            {
                if (
                   head.Location.X == body[i].Location.X &&
                   head.Location.Y == body[i].Location.Y
                   )
                {
                    MessageBox.Show("ПАШЕЛ НАХУЙЙЙЙ");
                }
            }
                for (var i = body.Count - 1; i > 0; i--)
            {
                body[i].Location = new Point(body[i - 1].Location.X, body[i - 1].Location.Y);
            }
            if (body.Count > 0)
            {
                body[0].Location = new Point(head.Location.X, head.Location.Y);
            }

            var vectorX = 0;
            var vectorY = 0;

            if (direction == 1) {
                vectorX = 50;
            }
            if (direction == 2)
            {
                vectorY = -50;
            }
            if (direction == 3)
            {
                vectorX = -50;
            }
            if (direction == 4)
            {
                vectorY = 50;
            }

            var pos  = new Point(head.Location.X + vectorX, head.Location.Y + vectorY);

            if (head.Location.X >= 900) {
                pos = new Point(head.Location.X - 900, head.Location.Y + vectorY);
            }
            if (head.Location.X < 0)
            {
                pos = new Point(head.Location.X + 900, head.Location.Y + vectorY);
            }
            if (head.Location.Y > 500)
            {
                pos = new Point(head.Location.X, head.Location.Y - 550);
            }
            if (head.Location.Y < 0)
            {
                pos = new Point(head.Location.X, head.Location.Y + 550);
            }

            head.Location = pos;
            SetTimeout(kek, 200);
        }
     

        public void SetTimeout(Action action, int timeout)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = timeout;
            timer.Tick += delegate (object sender, EventArgs args)
            {
                action();          
                timer.Stop();
            };
            timer.Start();
        }


        private void addVkusnyashka()
        {
            Random rnd = new Random();
            var x = rnd.Next(1, 16);
            var y = rnd.Next(1, 10);
            x *= 50;
            y *= 50;
            Button d = new Button();
            d.Text = "";
            d.Size = new Size(50, 50);
            d.Location = new Point(x, y);
            panel1.Controls.Add(d);
         
            vkus.Add(d);
            SetTimeout(addVkusnyashka, 5000);
        }
    }
}
