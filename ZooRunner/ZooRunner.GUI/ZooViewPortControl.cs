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
        int _zoomMax;
        int _zoomMin;
        int _zoomValue;
        int _zoomScale;

        public ZooViewPortControl()
        {
            DoubleBuffered = true;
            _boxCount = 20;
            _map = new Map(10, 11);
            _viewPort = new ViewPort(_map, 1);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _zoomMax = 1000;
            _zoomMin = 0;
            _zoomValue = 1000;
            _zoomScale = 50;
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

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.White;
            this.Focus();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (_zoomValue - _zoomScale < _zoomMin) _zoomValue = _zoomMin;
                else _zoomValue -= _zoomScale;
            }
            else
            {
                if (_zoomValue + _zoomScale > _zoomMax) _zoomValue = _zoomMax;
                else _zoomValue += _zoomScale;
            }
            _viewPort.UserZoomFactor = (double)(_zoomMax - _zoomValue) / (double)_zoomMax;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            BackColor = Color.Tomato;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            BackColor = Color.Green;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            MessageBox.Show(this.Parent.Name+"         "+this.Parent.CanFocus.ToString());
            base.OnLeave(e);
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
