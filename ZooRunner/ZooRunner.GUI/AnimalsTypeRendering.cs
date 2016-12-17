using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    public class AnimalsTypeRendering
    {
        string _figure;
        Color _color;

        public AnimalsTypeRendering(string figure, Color color)
        {
            _figure = figure;
            _color = color;
        }

        public Color ChangeColor
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Figure
        {
            get { return _figure; }
            set { _figure = value; }
        }
    }
}
