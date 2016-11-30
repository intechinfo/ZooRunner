using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Bird : Animal
    {

        internal Bird(Zoo ctx, string name)
            : base(ctx, name)
        {
        }

        internal override void Update()
        {

        }
    }
}
