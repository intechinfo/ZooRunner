using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public class Zoo
    {
        readonly Dictionary<string, Animal> _animals;

        public Zoo()
        {
            _animals = new Dictionary<string, Animal>();
        }

        public Cat CreateCat(string name)
        {
            Cat cat = new Cat(this, name);
            _animals[name] = cat;
            return cat;
        }

        internal bool Rename(Animal a, string newName)
        {
            if (_animals.ContainsKey(newName)) return false;
            _animals.Remove(a.Name);
            _animals.Add(newName, a);
            return true;
        }

        public Bird CreateBird(string name)
        {
            Bird bird = new Bird(this, name);
            _animals[name] = bird;
            return bird;
        }

        public T Find<T>(string name) where T : Animal
        {
            // TODO: C# avancé montrer comment faire ça:
            // return _animals.GetWithDefault( name, null );
            Animal b;
            _animals.TryGetValue(name, out b);
            return b as T;
        }

        public void Update()
        {
            foreach (Animal a in _animals.Values) a.Update();
        }

        public double MeterDefinition => 0.001;
    }
}
