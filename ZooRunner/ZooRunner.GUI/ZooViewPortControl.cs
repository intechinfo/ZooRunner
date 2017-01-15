using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooRunner.GUI;

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
        bool _mousePressed;
        Point _mouseDown;
        bool _showGridLines;

        public ZooViewPortControl()
        {
            DoubleBuffered = true;
            _boxCount = 10;
            _map = new Map(10, 11);
            _viewPort = new ViewPort(_map, 1);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _zoomMax = 1000;
            _zoomMin = 100;
            _zoomValue = 1000;
            _zoomScale = 25;
            _mousePressed = false;
            _mouseDown = new Point();
        }

        public event EventHandler MouseLeaveControl;
        public event EventHandler<string> AreaChanged;
        public event EventHandler<double> UserZoomFactorChanged;


        void _viewPort_AreaChanged(object sender, EventArgs e)
        {
            DisplayInfo();
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
                        UserZoomFactorChanged?.Invoke(this, _viewPort.UserZoomFactor);
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
            _viewPort.ShowGridLines = _showGridLines;
            _viewPort.SetClientSize(ClientSize);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            UserZoomFactorChanged?.Invoke(this, _viewPort.UserZoomFactor);
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
            set
            {
                _viewPort.ShowGridLines = value;
                _showGridLines = value;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
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
            if(e.Button == MouseButtons.Left)
            {
                if (!_mousePressed)
                {
                    this.Cursor = Cursors.SizeAll;
                    _mousePressed = true;
                    _mouseDown = e.Location;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Hand;
                _mousePressed = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePositionNow = e.Location;
                int deltaX = _mouseDown.X - mousePositionNow.X;
                int deltaY = _mouseDown.Y - mousePositionNow.Y;
                _viewPort.MouseMove(e.Location, this.Size);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            MouseLeaveControl?.Invoke(this, EventArgs.Empty);
            base.OnLeave(e);
        }

        public void TimerTick(List<AnimalAdapter> animals)
        {
            _viewPort.DriversAssignment(_zoo, animals, AnimalsRepresentation);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_viewPort == null || _zoo == null || this.IsInDesignMode())
            {
                e.Graphics.FillRectangle(Brushes.Yellow, e.ClipRectangle);
            }
            else
            {
                _viewPort.Draw(e.Graphics);
            }
            base.OnPaint(e);
        }

        public AnimalsRedering AnimalsRepresentation { get; set; }

        void DisplayInfo()
        {
            if (this.Enabled == true)
            {
                StringBuilder b = new StringBuilder();
                b.Append("ViewPort: ").AppendLine();
                b.Append(_viewPort.Area.Size).AppendLine();
                b.Append(_viewPort.Area.Location).AppendLine();
                b.Append("Zoom: ").AppendLine();
                b.Append(_viewPort.UserZoomFactor * 100 + "%").AppendLine();
                b.Append("ClientSize: ").AppendLine();
                b.Append(this.ClientSize).AppendLine();
                string informations = b.ToString();
                AreaChanged?.Invoke(this, informations);
                UserZoomFactorChanged?.Invoke(this, _viewPort.UserZoomFactor);
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            DisplayInfo();
            base.OnEnabledChanged(e);
        }
    }
}
