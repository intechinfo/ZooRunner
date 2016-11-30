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
        ZooAdapter _zoo;
        List<AnimalAdapter> _animals;
        bool _timer;

        public MainForm()
        {
            InitializeComponent();
            _animals = new List<AnimalAdapter>();
            _timer = false;
        }

        private void DllPath_Click(object sender, EventArgs e)
        {
            if (openDllDialog.ShowDialog() == DialogResult.OK)
            {
                _zoo = ZooAdapter.Load(openDllDialog.FileName);
                this.Text = openDllDialog.FileName;
                createAnimals.Enabled = true;
                gameLoop.Enabled = true;
            }
        }

        private void CreateAnimals_Click(object sender, EventArgs e)
        {
            CreateAnimals createAnimals = new CreateAnimals(_zoo);           

            if (createAnimals.ShowDialog() == DialogResult.OK)
            {
                _animals.AddRange(createAnimals.Animals);
            }
            createAnimals.Dispose();    
        }

        private void gameLoop_Click(object sender, EventArgs e)
        {
            if (_timer == false)
            {
                gameLoopTimer.Start();
                _viewPortDemoControl.Visible = true;
                _timer = true;
                trackBar.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
            }
            else
            {
                _timer = false;
                gameLoopTimer.Stop();
                _viewPortDemoControl.Visible = false;
                trackBar.Value = 1;
                trackBar.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            gameLoopTimer.Interval = 10000 / trackBar.Value;
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show("Tick");
            _zoo.Update();
        }
    }
}
