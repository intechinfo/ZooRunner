using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        Cursor _grab;
        Cursor _grabbing;
        Stopwatch _drawWatch;
        Stopwatch _zooWatch;
        System.Timers.Timer _timer;

        public ZooViewPortControl()
        {
            DoubleBuffered = true;
            _boxCount = 10;
            _map = new Map(10, 11);
            _viewPort = new ViewPort(_map, 1);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _zoomMax = 1000;
            _zoomMin = 0;
            _zoomValue = 1000;
            _zoomScale = 50;
            _mousePressed = false;
            _mouseDown = new Point();
            _grab = new Cursor("ifm_grab.cur");
            _grabbing = new Cursor("ifm_move.cur");
            _drawWatch = new Stopwatch();
            _zooWatch = new Stopwatch();
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Interval = 1000;
            _timer.Start();
        }

        public event EventHandler MouseLeaveControl;
        public event EventHandler<string> AreaChanged;
        public event EventHandler<int> ViewPortHeightChanged;
        public event EventHandler<int> MapWidthChanged;
        public event EventHandler<string> WatchsUpdates;
        public event EventHandler<string> EngineInformationsChanged;


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
                if (value < 1 || value > 10) throw new ArgumentException( "BoxCount must be between 1 and 10." );
                if( _boxCount != value )
                {
                    _boxCount = value;
                    if(_zoo != null )
                    {
                        InitializeMap();
                        ViewPortHeightChanged?.Invoke(this, _viewPort.Area.Height);
                    }
                }
            }
        }

        public void SetZoo( ZooAdapter zoo )
        {
            if (_zoo == zoo) return;
            if( zoo != null )
            {
                if (_zooWatch.IsRunning) _zooWatch.Reset();
                if (_drawWatch.IsRunning) _drawWatch.Reset();
                _zooWatch.Start();
                _drawWatch.Reset();
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
            _zoomValue = 1000;
            _map = new Map(10, _boxCount);
            _viewPort = new ViewPort(_map, 5);
            _viewPort.ShowGridLines = _showGridLines;
            _viewPort.SetClientSize(ClientSize);
            _viewPort.AreaChanged += _viewPort_AreaChanged;
            _viewPort.SetDriver(_zoo);
            DisplayInfo();
            MapWidthChanged?.Invoke(this, _viewPort.Map.MapWidth);
            Invalidate();
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
            this.Cursor = _grabbing;
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
                    this.Cursor = _grab;
                    _mousePressed = true;
                    _mouseDown = e.Location;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Cursor = _grabbing;
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
            MouseLeaveControl?.Invoke(this, EventArgs.Empty);
            base.OnLeave(e);
        }

        public void TimerTick(List<AnimalAdapter> animals)
        {           
            _viewPort.DriversAssignment(_zoo, animals, AnimalsShapes);
            Invalidate();
            DisplayInfo();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_viewPort == null || _zoo == null || this.IsInDesignMode())
            {
                e.Graphics.FillRectangle(Brushes.Yellow, e.ClipRectangle);
            }
            else
            {
                _drawWatch.Start();
                _viewPort.Draw(e.Graphics);
                _drawWatch.Stop();
            }
            base.OnPaint(e);
        }

        public AnimalsRedering AnimalsShapes { get; set; }

        void DisplayInfo()
        {
            if (this.Enabled == true)
            {               
                StringBuilder b = new StringBuilder();
                b.Append("Zoom: ").AppendLine();
                b.Append(_viewPort.UserZoomFactor * 100 + "%").AppendLine();
                string informations = b.ToString();
                AreaChanged?.Invoke(this, informations);
                StringBuilder b2 = new StringBuilder();
                b2.Append("ViewPort: ").Append(_viewPort.Area).AppendLine();
                b2.Append("ClientScaleFactor: ").Append(_viewPort.ClientScaleFactor).AppendLine();
                b2.Append("Client size : ").Append(this.ClientSize);
                string engineinfos = b2.ToString();
                EngineInformationsChanged?.Invoke(this, engineinfos);
                ViewPortHeightChanged?.Invoke(this, _viewPort.Area.Height);
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            DisplayInfo();
            base.OnEnabledChanged(e);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(this.Enabled)
            {
                StringBuilder b = new StringBuilder();
                b.Append("Zoo runtime :").AppendLine();
                b.Append(TimeFormat(_zooWatch)).AppendLine();
                b.Append("Draw runtime :").AppendLine();
                b.Append(TimeFormat(_drawWatch)).AppendLine();
                string watchs = b.ToString();
                WatchsUpdates?.Invoke(this, watchs);
            }
        }

        private string TimeFormat(Stopwatch watch)
        {
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            return elapsedTime;
        }

    }
}
