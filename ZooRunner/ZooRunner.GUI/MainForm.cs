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
            _zooViewPortControl.SetZoo(e);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _zooViewPortControl.BoxCount = 50;
        }

        private void OnBoxCountChange(object sender, int e)
        {
            _zooViewPortControl.BoxCount = e;
        }
    }
}
