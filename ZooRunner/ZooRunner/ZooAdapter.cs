using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        readonly double _meterDefinition;
        readonly int _withInMeter;
        readonly int _mapSize;

        ZooAdapter(object zoo, Type zooType)
        {
            Debug.Assert(zoo != null);
            _zoo = zoo;
            _zooType = zooType;
            _animalTypes = CreateAnimalTypes( zoo, zooType );
            _updateMethod = _zooType.GetMethod("Update");
            _meterDefinition = (double)_zooType.GetProperty("MeterDefinition").GetGetMethod().Invoke(zoo,null);
            _withInMeter = (int)(1 / _meterDefinition) * 2;
            _mapSize = _withInMeter * 1000;
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

        public int WithInMeter => _withInMeter;

        public int MapSize => _mapSize;

        public double MeterDefinition => _meterDefinition;

         
    }
}
