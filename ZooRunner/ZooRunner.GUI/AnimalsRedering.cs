using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    public class AnimalsRedering
    {
        readonly Dictionary<string, AnimalsTypeRendering> _animalsRedering;

        public AnimalsRedering()
        {
            _animalsRedering = new Dictionary<string, AnimalsTypeRendering>();
        }

        public void Add(string typeName, string figure, Color color)
        {
            if(!_animalsRedering.ContainsKey(typeName))
            {
                AnimalsTypeRendering newtype = new AnimalsTypeRendering(figure, color);
                _animalsRedering.Add(typeName, newtype); 
            }
            else
            {
                _animalsRedering[typeName].ChangeColor = color;
                _animalsRedering[typeName].Figure = figure;
            }
        }
        public Dictionary<string, AnimalsTypeRendering> AnimalsRepresentation => _animalsRedering;
    }
}
