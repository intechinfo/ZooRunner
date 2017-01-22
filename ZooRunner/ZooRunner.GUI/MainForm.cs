using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnUserGivesDll(object sender, ZooAdapter e)
        {
            _zooViewPortControl.Enabled = true;
            _zooViewPortControl.SetZoo(e);
            _scale.ZooWithInMeter = e.WithInMeter;
            _scale.Enabled = true;
            _informations.Enabled = true;
        }


        private void OnBoxCountChange(object sender, int e)
        {
            _zooViewPortControl.BoxCount = e;
        }

        private void OnShowGridLines(object sender, bool e)
        {
            _zooViewPortControl.ShowGridLines = e;
        }

        private void OnMouseLeaveControl(object sender, EventArgs e)
        {
            _controlPanel.Focus();
        }

        private void OnTimerTick(object sender, List<AnimalAdapter> e)
        {
            _zooViewPortControl.TimerTick(e);
        }

        private void OnAnimalsRederingChange(object sender, AnimalsRedering e)
        {
            _zooViewPortControl.AnimalsShapes = e;
        }

        private void OnAreaChanged(object sender, string e)
        {
            _informations.DisplayInfos(e);
        }

        private void OnViewPortWidthChanged(object sender, int e)
        {
            _scale.ViewPortWidth = e;
        }

        private void OnMapWidthChanged(object sender, int e)
        {
            _scale.MapWith = e;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            _scale.Invalidate();
        }

        private void OnWatchsUpdates(object sender, string e)
        {
            _informations.DisplayWatchs(e);
        }
    }
}
