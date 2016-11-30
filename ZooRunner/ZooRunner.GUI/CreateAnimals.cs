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
    public partial class CreateAnimals : Form
    {
        ZooAdapter _zoo;
        List<AnimalAdapter> _animals;

        public CreateAnimals(ZooAdapter zoo)
        {
            InitializeComponent();
            _zoo = zoo;
            _animals = new List<AnimalAdapter>();          
        }

        private void CreateAnimals_Load(object sender, EventArgs e)
        {
            for (int incre = 0; incre <= _zoo.AnimalTypes.Count - 1; incre++)
            {
                animalsComboBox.Items.Add(_zoo.AnimalTypes[incre].Name);

            }
            animalsComboBox.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int incre = 0; incre <= animalsNumericUpDown.Value - 1; incre++)
            {
                string guid = Guid.NewGuid().ToString();
                AnimalAdapter animal = _zoo.AnimalTypes[animalsComboBox.SelectedIndex].CreateInstance(guid);
                _animals.Add(animal);
            }
        }

        public List<AnimalAdapter> Animals => _animals;

    }
}
