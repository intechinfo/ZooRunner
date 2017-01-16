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
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                int left = 0;
                int middle = _zooWithInMeter / 4;
                int right = _zooWithInMeter / 2;

                double percentage = (double)_mapWidth / _viewPortWidth * 100;
                percentage = percentage / 2;

                if(percentage > 70)
                {
                    percentage = percentage / 2;
                    middle = middle / 2;
                    right = right / 2;
                }
                if(percentage > 70)
                {
                    percentage = percentage / 2;
                    middle = middle / 2;
                    right = right / 2;
                }

                double sizeInPixel = (this.Size.Width / 100) * percentage;

                int medianeForm = this.Size.Width / 2;
                int medianeScale = (int)sizeInPixel / 2;

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