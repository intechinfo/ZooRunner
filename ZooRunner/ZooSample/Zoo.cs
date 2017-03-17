using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Zoo
    {
        readonly Dictionary<string, Animal> _animals;
        readonly List<Animal> _animalsThatWillDie;
        readonly Random _random;

        public Zoo()
            : this( new Random() )
        {
        }

        public Zoo( int randomSeed )
            : this( new Random( randomSeed ) )
        {
        }

        Zoo( Random random )
        {
            _random = random;
            _animals = new Dictionary<string, Animal>();
            _animalsThatWillDie = new List<Animal>();
        }

        internal bool Probability( double p )
        {
            return _random.NextDouble() < p;
        }

        internal Random Randomizer => _random;

        public Cat CreateCat( string name )
        {
            Cat cat = new Cat( this, name );
            _animals[ name ] = cat;
            return cat;
        }

        internal bool Rename( Animal a, string newName )
        {
            if( _animals.ContainsKey( newName ) ) return false;
            _animals.Remove( a.Name );
            _animals.Add( newName, a );
            return true;
        }

        public Bird CreateBird( string name )
        {
            Bird bird = new Bird( this, name );
            _animals[ name ] = bird;
            return bird;
        }

        public T Find<T>( string name ) where T : Animal
        {
            Animal b;
            _animals.TryGetValue( name, out b );
            return b as T;
        }

        public void Die( Animal a )
        {
            _animalsThatWillDie.Add( a );
        }

        public void Update()
        {
            foreach( Animal a in _animals.Values ) a.Update();

            foreach( Animal a in _animalsThatWillDie )
            {
                _animals.Remove( a.Name );
            }
        }

        public double MeterDefinition => 0.0001;

        public Color ColorAt( double x, double y )
        {
            //Color myColor = new Color();
            //if (y > Math.Cos(x) - 0.4)
            //{
            //    myColor = Color.Blue;
            //}
            //else if (y <= Math.Tan(x))
            //{
            //    myColor = Color.Chartreuse;
            //}
            //else
            //{
            //    myColor = Color.Brown;
            //}

            x *= Math.PI;
            y *= Math.PI;

            return Color.FromArgb( ( int )( ( Math.Sin( x ) * 255 ) + 255 ) / 2, ( int )( ( Math.Cos( y ) * 255 ) + 255 ) / 2, ( int )( ( Math.Sin( x * y ) * 255 ) + 255 ) / 2 );
        }

    }
}
