using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ComputerGr;

namespace ComputerGrPlane
{
    public partial class Form1 : Form
    {
        RectangleF lRect, rRect, planeRect;
        RectangleF[] cloudRect;
        Random rand;

        bool shrink;
        const int planeSpeed = 5;
        const int cloudSpeed = 2;
        const double L = 2;
        const double R = 5;

        Bitmap bladeL, bladeR, plane, cloud;

        public Form1()
        {
            InitializeComponent();
            
            bladeL = new Bitmap("animation/bladel.png");
            bladeR = new Bitmap("animation/blader.png");
            plane = new Bitmap("animation/plane.png");
            cloud = new Bitmap("animation/cloud.png");

            int dx = 100, dy = 100;
            lRect = new RectangleF(plane.Width / 2 - 10 + dx, plane.Height / 8 + dy, 20, plane.Height / 8);
            rRect = new RectangleF(plane.Width / 2 - 10 + dx, plane.Height / 4 + dy, 20, plane.Height / 8);
            planeRect = new RectangleF(0 + dx, 0 + dy, plane.Width / 2, plane.Height / 2);

            cloudRect = new RectangleF[5];
            rand = new Random();

            for (int i = 0; i < cloudRect.Length; i++)
            {
                float k = (float)(rand.NextDouble()*(R - L) + L);
                cloudRect[i] = new RectangleF(i * canvas.Width / cloudRect.Length, rand.Next(0, canvas.Height / 2), cloud.Width / k, cloud.Height / k);
            }

            shrink = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (shrink)
            {
                lRect.Y += planeSpeed;
                lRect.Height -= planeSpeed;

                rRect.Height -= planeSpeed;

                if (lRect.Height <= 0)
                    shrink = false;
            }
            else
            {
                lRect.Y -= planeSpeed;
                lRect.Height += planeSpeed;

                rRect.Height += planeSpeed;

                if (lRect.Height >= plane.Height / 8)
                    shrink = true;
            }

            for (int i = 0; i < cloudRect.Length; i++)
            {
                cloudRect[i].X -= cloudSpeed;
                if (cloudRect[i].X < 0 && -cloudRect[i].X > cloudRect[i].Width)
                {
                    float k = (float)(rand.NextDouble()*(R - L) + L);
                    cloudRect[i].X = canvas.Width;
                    cloudRect[i].Y = rand.Next(0, canvas.Height / 2);
                    cloudRect[i].Width = cloud.Width / k;
                    cloudRect[i].Height = cloud.Height / k;
                }
            }

            canvas.Refresh();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.DrawImage(plane, planeRect);
            for (int i = 0; i < cloudRect.Length; i++)
                g.DrawImage(cloud, cloudRect[i]);

            g.DrawImage(bladeL, lRect);
            g.DrawImage(bladeR, rRect);
        }
    }
}
