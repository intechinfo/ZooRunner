using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Bird : Animal
    {
        Point _direction;
         
        internal Bird(Zoo ctx, string name)
            : base(ctx, name)
        {
        }

        public void MoveTo(Point destination, double percentSpeed)
        {
            _direction = new Point();
        }

        public void MoveRandom()
        {
            double randX = GetRandomNumber(-1, 1);
            double randY = GetRandomNumber(-1, 1);
            _direction = new Point(randX, randY);
            SetPosition(_direction);
        }

        internal override void Update()
        {
            MoveRandom();
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return Context.Randomizer.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
