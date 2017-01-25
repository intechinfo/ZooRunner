using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    public class ZooAdapter
    {
        readonly object _zoo;
        readonly Type _zooType;
        readonly List<AnimalType> _animalTypes;
        readonly MethodInfo _updateMethod;
        readonly MethodInfo _colorAtMethod;
        readonly double _meterDefinition;
        readonly int _widthInMeter;
        readonly int _mapSize;
        readonly MethodInfo _findMethod;
        bool _collectColorAtMethod;
        bool _collectFindMethod;

        ZooAdapter(object zoo, Type zooType)
        {
            Debug.Assert(zoo != null);
            _zoo = zoo;
            _zooType = zooType;
            _animalTypes = CreateAnimalTypes( zoo, zooType );
            _updateMethod = _zooType.GetMethod("Update");
            _colorAtMethod = RetrieveColorAt();
            _meterDefinition = RetrieveMeterDefinition(_zoo);        
            _widthInMeter = (int)(1 / _meterDefinition) * 2;
            _mapSize = _widthInMeter * 1000;
            _findMethod = RetrieveFind();
        }

        public static ZooAdapter Load( string fileName )
        {
            Assembly a = Assembly.LoadFile(fileName);
            var zooType = a.GetExportedTypes().Where( t => t.Name == "Zoo" ).Single();
            object zoo = Activator.CreateInstance(zooType);
            return new ZooAdapter(zoo, zooType);
        }

        static List<AnimalType> CreateAnimalTypes(object zoo, Type zooType )
        {
            List<AnimalType> result = new List<AnimalType>();
            var allMethods = zooType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var createMethods = allMethods.Where(m => m.Name.StartsWith("Create")
                                                       && m.ReturnType != typeof(void));
            foreach( var m in createMethods )
            {
                var parameters = m.GetParameters();
                if( parameters.Length == 1 && parameters[0].ParameterType == typeof(string) )
                {
                    Type animalType = m.ReturnType;
                    MethodInfo factoryMethod = m;
                    MethodInfo getName = animalType.GetProperty("Name").GetGetMethod();
                    MethodInfo getX = animalType.GetProperty("X").GetGetMethod();
                    MethodInfo getY = animalType.GetProperty("Y").GetGetMethod();
                    result.Add(new AnimalType(zoo, animalType, factoryMethod, getName, getX, getY));
                }
            }
            return result;
        }

        public IReadOnlyList<AnimalType> AnimalTypes => _animalTypes;

        public void Update() => _updateMethod.Invoke(_zoo, null);

        public Color ColorAt(double x, double y)
        {
            if (!_collectColorAtMethod) throw new Exception("You can't use ColorAt() without a ColorAt method in your zoo");
            var returnObject = _colorAtMethod.Invoke(_zoo, new object[] { x, y });
            Color color = (Color)returnObject;
            return color;
        }

        public bool Find(AnimalAdapter animal)
        {
            if (!_collectFindMethod) throw new Exception("You can't use Find() without a find method in your zoo");
            var returnObject = _findMethod.MakeGenericMethod(animal.AnimalType.Type).Invoke(_zoo, new object[] { animal.Name });
            if (returnObject == null) return false;
            return true;
        }

        private double RetrieveMeterDefinition(object zoo)
        {
            double meterDefinition;

            try
            {
                meterDefinition = (double)_zooType.GetProperty("MeterDefinition").GetGetMethod().Invoke(zoo, null);
            }
            catch (Exception)
            {
                meterDefinition = 0.01;
            }

            return meterDefinition;
        }

        private MethodInfo RetrieveColorAt()
        {
            MethodInfo colorAtMethod;

            colorAtMethod = _zooType.GetMethod("ColorAt");
            _collectColorAtMethod = true;

            if(colorAtMethod == null)
            {
                _collectColorAtMethod = false;
            }

            return colorAtMethod;
        }

        private MethodInfo RetrieveFind()
        {
            MethodInfo findMethod;
            findMethod = _zooType.GetMethod("Find");
            _collectFindMethod = true;

            if(findMethod == null)
            {
                _collectFindMethod = false;
            }
            return findMethod;
        }

        public int WithInMeter => _widthInMeter;

        public int MapSize => _mapSize;

        public double MeterDefinition => _meterDefinition;

        public bool CollectColorAtMethod => _collectColorAtMethod;

        public bool CollectFindMethod => _collectFindMethod;     
    }
}
