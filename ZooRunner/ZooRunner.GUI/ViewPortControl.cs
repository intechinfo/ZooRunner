using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner
{
    public class ViewPortControl : Control
    {
        readonly Map _map;
        readonly ViewPort _viewPort;

        public ViewPortControl()
        {
            DoubleBuffered = true;
            _map = new Map(10, 11);
            _viewPort = new ViewPort(_map, 1);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
        }

        void _viewPort_AreaChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        public ViewPort ViewPort
        {
            get { return _viewPort; }
        }

        protected override void OnResize(EventArgs e)
        {
            _viewPort.SetClientSize(ClientSize);
            base.OnResize(e);
        }

        public void ScrollTo(int x, int y)
        {
            _viewPort.MoveTo(x, y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_viewPort == null || this.IsInDesignMode())
            {
                e.Graphics.FillRectangle(Brushes.Yellow, e.ClipRectangle);
            }
            else
            {
                _viewPort.Draw(e.Graphics);
            }
            base.OnPaint(e);
        }
    }
}
