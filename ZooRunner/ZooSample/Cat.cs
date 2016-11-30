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
        }

        public void MoveTo(Point destination, double percentSpeed)
        {
            _direction = new Point();
        }

        public void MoveRandom()
        {

        }

        internal override void Update()
        {
            SetPosition(new Point(Position.X + _direction.X, Position.Y + _direction.Y));
            if (_isRandomWalking)
            {
                _direction = new Point();
            }
            //_pos += _direction;
        }
    }
}
