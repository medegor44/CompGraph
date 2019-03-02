using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Math;

namespace ComputerGr
{
    public partial class Form1 : Form
    {
        private PointF origin;
        private Matrix3 transform;
        private Figure f;
        private int oldRotation;
        private float oldXStretch;
        private float oldYStretch;

        public Form1()
        {
            InitializeComponent();

            oldRotation = 0;
            oldXStretch = 1;
            oldYStretch = 1;

            transform = new Matrix3();
            origin = new PointF(canvas.Width / 2.0f, canvas.Height / 2.0f);
            f = new Figure(origin, canvas.Height);
        }

        private void DrawAxes(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black), origin.X, 0, origin.X, canvas.Height);
            g.DrawLine(new Pen(Color.Black), 0, origin.Y, canvas.Width, origin.Y);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            DrawAxes(g);

            g.DrawFigure(new Pen(Color.Gray), f);
            g.DrawFigure(new Pen(Color.Blue), transform*f);
        }

        private void angleTb_Scroll(object sender, EventArgs e)
        {
            int d = angleTb.Value - oldRotation;
            oldRotation += d;
            float a = 2*(float)PI * d / angleTb.Maximum;

            var rotate = new Matrix3(new float[3, 3] {
                { (float)Cos(a), -(float)Sin(a), 0 },
                { (float)Sin(a),  (float)Cos(a), 0 },
                { 0, 0, 1}
            });

            var move1 = new Matrix3();
            var move2 = new Matrix3();

            float x, y;
            if (ptCheckBox.Checked && float.TryParse(ptXtextBox.Text, out x) && float.TryParse(ptYtextBox.Text, out y))
            {
                move1.A[0, 2] = x;
                move1.A[1, 2] = y;

                move2.A[0, 2] = -x;
                move2.A[1, 2] = -y;
            }

            transform = move1 * rotate * move2 * transform;

            canvas.Refresh();
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            var dxt = dxtextBox.Text;
            var dyt = dytextBox.Text;
            float dx, dy;

            if (float.TryParse(dxt, out dx) && float.TryParse(dyt, out dy))
            {
                var move = new Matrix3(new float[3, 3] {
                    { 1, 0, dx },
                    { 0, 1, dy },
                    { 0, 0, 1 }
                });

                transform = move * transform;

                canvas.Refresh();
            }
        }

        private void xStretchTb_Scroll(object sender, EventArgs e)
        {
            float s = xStretchTb.Value / ((float)xStretchTb.Maximum / 2);

            var sOld = new Matrix3(new float[2, 2] {
                { 1 / oldXStretch, 0 },
                { 0, 1 }
            });

            var sNew = new Matrix3(new float[2, 2] {
                { s, 0 },
                { 0, 1 }
            });

            transform = sNew * sOld * transform;

            oldXStretch = s;

            canvas.Refresh();
        }

        private void yStretchTb_Scroll(object sender, EventArgs e)
        {
            float s = yStretchTb.Value / ((float)yStretchTb.Maximum / 2);

            var sOld = new Matrix3(new float[2, 2] {
                { 1, 0 },
                { 0, 1 / oldYStretch }
            });

            var sNew = new Matrix3(new float[2, 2] {
                { 1, 0 },
                { 0, s }
            });

            transform = sNew * sOld * transform;

            oldYStretch = s;

            canvas.Refresh();
        }

        private void reflectXBtn_Click(object sender, EventArgs e)
        {
            var m = new Matrix3(new float[2, 2] {
                { -1, 0 },
                { 0, 1 }
            });

            transform = m * transform;
            canvas.Refresh();
        }

        private void reflectYBtn_Click(object sender, EventArgs e)
        {
            var m = new Matrix3(new float[2, 2] {
                { 1, 0 },
                { 0, -1 }
            });

            transform = m * transform;
            canvas.Refresh();
        }

        private void reflectXYBtn_Click(object sender, EventArgs e)
        {
            var m = new Matrix3(new float[2, 2] {
                { 0, 1 },
                { 1, 0 }
            });

            transform = m * transform;
            canvas.Refresh();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            transform = new Matrix3();

            dxtextBox.Clear();
            dytextBox.Clear();

            angleTb.Value = 0;

            xStretchTb.Value = (xStretchTb.Maximum + xStretchTb.Minimum) / 2;
            yStretchTb.Value = (yStretchTb.Maximum + yStretchTb.Minimum) / 2;

            ptXtextBox.Enabled = false;
            ptYtextBox.Enabled = false;

            ptXtextBox.Text = ptYtextBox.Text = "0";
            ptCheckBox.Checked = false;

            oldRotation = 0;
            oldXStretch = 1;
            oldYStretch = 1;

            canvas.Refresh();
        }

        private void ptCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            ptXtextBox.Enabled = ptCheckBox.Checked;
            ptYtextBox.Enabled = ptCheckBox.Checked;
        }
    }
}
