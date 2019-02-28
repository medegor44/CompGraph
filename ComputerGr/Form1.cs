using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            float q = (float)Math.Sqrt(2);

            var g = e.Graphics;
            g.Clear(Color.White);
            Figure f = new Figure(new PointF(200, 200), canvas.Height);
            Matrix3 M = new Matrix3(new float[3, 3] {
                { 1, 0, 10 },
                { 0, 1, 20 },
                { 0, 0, 1 }
            });

            Matrix3 M1 = new Matrix3(new float[3, 3] {
                { q/2, -q/2, 0 },
                { q/2, q/2, 0 },
                { 0, 0, 1 }
            });

            Matrix3 M3 = new Matrix3(new float[3, 3] {
                { 1, 0, -10 },
                { 0, 1, -20 },
                { 0, 0, 1 }
            });
        }
    }
}
