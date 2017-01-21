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
        int _zooWithInMeter;
        int _viewPortWidth;
        int _mapWidth;

        public Scale()
        {
            InitializeComponent();
        }

        public int ZooWithInMeter
        {
            set
            {
                _zooWithInMeter = value;
            }
        }

        public int MapWith
        {
            set
            {
                _mapWidth = value;
            }
        }

        public int ViewPortWidth
        {
            set
            {
                if (_viewPortWidth == value) return;
                _viewPortWidth = value;
                Invalidate();
            }
        }

        private void scale_Paint(object sender, PaintEventArgs e)
        {
            if (this.Enabled && _mapWidth != 0 && _viewPortWidth != 0)
            {
                Pen pen = new Pen(Color.Black);
                Font drawFont = new Font("Arial", 14);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                double left = 0;
                double middle = _zooWithInMeter / 4;
                double right = _zooWithInMeter / 2;

                double percentage = (double)_mapWidth / _viewPortWidth * 100;
                percentage = percentage / 2;

                while(percentage > 70)
                {

                    percentage = percentage / 2;
                    middle = middle / 2;
                    right = right / 2;

                }

                double sizeInPixel = (this.Size.Height / 100) * percentage;

                int medianeForm = this.Size.Height / 2;
                int medianeScale = (int)sizeInPixel / 2;

                Point a = new Point(5, medianeForm - medianeScale);
                Point b = new Point(5, medianeForm + medianeScale - 1);

                Point c = new Point(a.X + 5, a.Y);
                Point d = new Point(b.X + 5, b.Y);

                Point f = new Point(a.X, medianeForm);
                Point g = new Point(f.X + 5, medianeForm);

                e.Graphics.DrawLine(pen, a, b);
                e.Graphics.DrawLine(pen, a, c);
                e.Graphics.DrawLine(pen, b, d);
                e.Graphics.DrawLine(pen, f, g);

                e.Graphics.DrawString(left + " m", drawFont, drawBrush, a.X + 5, a.Y - 10);
                e.Graphics.DrawString(middle + " m", drawFont, drawBrush, f.X + 5, f.Y - 10);
                e.Graphics.DrawString(right + " m", drawFont, drawBrush, b.X + 5, b.Y - 10);

                e.Graphics.Dispose();
            }
        }
    }
}