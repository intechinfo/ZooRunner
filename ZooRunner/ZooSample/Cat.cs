using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Cat : Animal
    {
        Point _direction;
        bool _isRandomWalking;

        internal Cat(Zoo ctx, string name)
            : base(ctx, name)
        {
            _isRandomWalking = true;
        }

        public void MoveTo(Point destination, double percentSpeed)
        {
            Point intermediate = new Point();

            if (X < _direction.X)
            {
                intermediate.X = X + destination.X * percentSpeed;
                
            }
            else if(X > _direction.X)
            {
                intermediate.X = X - destination.X * percentSpeed;
            }
            if(Y < _direction.Y)
            {
                intermediate.Y = Y + destination.Y * percentSpeed;
            }
            else if(Y > _direction.Y)
            {
                intermediate.Y = Y - destination.Y * percentSpeed;
            }

            SetPosition(intermediate);
            if (Math.Round(intermediate.X, 3) == Math.Round(_direction.X, 3) && Math.Round(intermediate.Y, 3) == Math.Round(_direction.Y, 3))
            {
                _isRandomWalking = true;
            }
        }

        public void MoveRandom()
        {
            double rand = GetRandomNumber(0, 1);
            _direction = new Point(rand, rand);
        }

        internal override void Update()
        {
            if(_isRandomWalking)
            {
                MoveRandom();
                _isRandomWalking = false;
            }
            MoveTo(_direction, 0.5);
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return Context.Randomizer.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
