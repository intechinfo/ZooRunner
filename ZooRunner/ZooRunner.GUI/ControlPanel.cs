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
    public partial class ControlPanel : UserControl
    {
        ZooAdapter _zoo;
        List<AnimalAdapter> _animals;
        bool _timer;

        public ControlPanel()
        {
            InitializeComponent();
            _animals = new List<AnimalAdapter>();
            _timer = false;
        }

        private void _dllBouton_Click(object sender, EventArgs e)
        {
            if (_dllOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _zoo = ZooAdapter.Load(_dllOpenFileDialog.FileName);
                this.Text = _dllOpenFileDialog.FileName;
                _createAnimalsBouton.Enabled = true;
                _gameLoopBouton.Enabled = true;
            }
        }

        private void _createAnimalsBouton_Click(object sender, EventArgs e)
        {
            CreateAnimals createAnimals = new CreateAnimals(_zoo);
            if (createAnimals.ShowDialog() == DialogResult.OK)
            {
                _animals.AddRange(createAnimals.Animals);
            }
            createAnimals.Dispose();
        }

        private void _gameLoopBouton_Click(object sender, EventArgs e)
        {
            if (_timer == false)
            {
                _gameLoopTimer.Start();
                _timer = true;
                _timerTrackBar.Enabled = true;
                _slowLabel.Enabled = true;
                _fastLabel.Enabled = true;
            }
            else
            {
                _timer = false;
                _gameLoopTimer.Stop();
                _timerTrackBar.Value = 1;
                _timerTrackBar.Enabled = false;
                _slowLabel.Enabled = false;
                _fastLabel.Enabled = false;
            }
        }

        private void _timerTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _gameLoopTimer.Interval = 10000 / _timerTrackBar.Value;
        }

        private void _gameLoopTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Tick");
            _zoo.Update();
        }
    }
}
