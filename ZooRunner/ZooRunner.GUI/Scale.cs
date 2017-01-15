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
        double _userZoomFactor;
        double _meterDefinition;
        int _mapWithInMeter;

        public Scale()
        {
            InitializeComponent();
        }

        public double UserZoomFactor
        {
            set
            {
                if (value == _userZoomFactor) return;
                _userZoomFactor = value;
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

        public int MapWithInMeter
        {
            set
            {
                _mapWithInMeter = value;
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

                sizeInMeter = this.Width / 2;
                left = "0";
                middle = "500";
                right = "1000";

                double step = sizeInMeter * _userZoomFactor;
                int sizeInPixel = (int)step;

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