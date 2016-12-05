using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner
{
    public class ZooViewPortControl : Control
    {
        ZooAdapter _zoo;
        Map _map;
        ViewPort _viewPort;
        int _boxCount;

        public ZooViewPortControl()
        {
            DoubleBuffered = true;
            _boxCount = 20;
            _map = new Map(10, 11);
            _viewPort = new ViewPort(_map, 1);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
        }

        void _viewPort_AreaChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        public int BoxCount
        {
            get { return _boxCount; }
            set
            {
                if (value < 1 || value > 500) throw new ArgumentException( "BoxCount must be between 1 and 500." );
                if( _boxCount != value )
                {
                    _boxCount = value;
                    if(_zoo != null )
                    {
                        InitializeMap();
                    }
                }
            }
        }

        public void SetZoo( ZooAdapter zoo )
        {
            if (_zoo == zoo) return;
            if( zoo != null )
            {
                _zoo = zoo;
                InitializeMap();
            }
            else
            {
                _viewPort.AreaChanged -= _viewPort_AreaChanged;
                _viewPort = null;
                _map = null;
                _zoo = null;
                Invalidate();
            }
        }

        void InitializeMap()
        {
            if(_viewPort != null ) _viewPort.AreaChanged -= _viewPort_AreaChanged;
            _map = new Map(10, _boxCount);
            _viewPort = new ViewPort(_map, 5);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            Invalidate();

            // 10 => One box is 10 meter x 10 meter.
            // 20 => 20 x 20 boxes.
            // 5 => User will be able to see at most a quarter of a box.
            //_map = new Map(10, _boxCount);
            //_viewPort = new ViewPort(_map, 5);
        }

        public ViewPort ViewPort => _viewPort; 

        protected override void OnResize(EventArgs e)
        {
            _viewPort.SetClientSize(ClientSize);
            base.OnResize(e);
        }

        public bool ShowGridLines
        {
            get { return _viewPort.ShowGridLines; }
            set { _viewPort.ShowGridLines = value; }
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
