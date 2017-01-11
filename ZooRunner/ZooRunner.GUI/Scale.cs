using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner.GUI
{
    public partial class Scale : UserControl
    {
        double _clientScaleFactor;
        double _meterDefinition;

        public Scale()
        {
            InitializeComponent();
        }

        public double ClientScaleFactor
        {
            set
            {
                if (value == _clientScaleFactor) return;
                _clientScaleFactor = value;
                Invalidate();
            }
        }

        public double MeterDefinition
        {
            set
            {
                _meterDefinition = value;
            }
        }

        private void scale_Paint(object sender, PaintEventArgs e)
        {
            if (this.Enabled)
            {
                Pen pen = new Pen(Color.Black);
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                int sizeInMeter;
                string right;
                string left;
                string middle;

                if (_clientScaleFactor > 0.8)
                {
                    sizeInMeter = 5;
                    left = "0";
                    middle = "2.5";
                    right = "5";

                }
                else if (_clientScaleFactor > 0.3)
                {
                    sizeInMeter = 10;
                    left = "0";
                    middle = "5";
                    right = "10";

                }
                else if (_clientScaleFactor > 0.15)
                {
                    sizeInMeter = 20;
                    left = "0";
                    middle = "10";
                    right = "20";

                }
                else if (_clientScaleFactor > 0.05)
                {
                    sizeInMeter = 50;
                    left = "0";
                    middle = "25";
                    right = "50";
                }
                else if (_clientScaleFactor > 0.025)
                {
                    sizeInMeter = 100;
                    left = "0";
                    middle = "50";
                    right = "100";
                }
                else if (_clientScaleFactor > 0.012)
                {
                    sizeInMeter = 200;
                    left = "0";
                    middle = "100";
                    right = "200";
                }
                else
                {
                    sizeInMeter = 500;
                    left = "0";
                    middle = "250";
                    right = "500";
                }

                double step = sizeInMeter / 0.01;
                step = step * _clientScaleFactor;
                int sizeInPixel = (int)step;

                if (sizeInPixel > this.Size.Width)
                {
                    sizeInPixel = this.Size.Width;
                }

                int medianeForm = this.Size.Width / 2;
                int medianeScale = sizeInPixel / 2;


                Point a = new Point(medianeForm - medianeScale, this.Size.Height - 5);
                Point b = new Point(medianeForm + medianeScale - 1, this.Size.Height - 5);

                Point c = new Point(a.X, a.Y - 5);
                Point d = new Point(b.X, b.Y - 5);

                Point f = new Point(medianeForm, this.Size.Height - 5);
                Point g = new Point(f.X, f.Y - 5);


                e.Graphics.DrawLine(pen, a, b);
                e.Graphics.DrawLine(pen, a, c);
                e.Graphics.DrawLine(pen, b, d);
                e.Graphics.DrawLine(pen, f, g);

                e.Graphics.DrawString(left + " m", drawFont, drawBrush, a.X - 5, a.Y - 27);
                e.Graphics.DrawString(middle + " m", drawFont, drawBrush, f.X - 20, f.Y - 27);
                e.Graphics.DrawString(right + " m", drawFont, drawBrush, b.X - 50, b.Y - 27);

                e.Graphics.Dispose();
            }
        }
    }
}