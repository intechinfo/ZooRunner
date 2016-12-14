using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    class Driver : IBoxDriver
    {
        public Driver()
        {

        }
        public void Draw(Box box, Graphics g, Rectangle rectSource, float scaleFactor)
        {
            Brush b = new SolidBrush(Color.Blue);
            g.FillRectangle(b, rectSource);
        }
    }
}
