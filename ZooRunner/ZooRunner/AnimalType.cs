using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    public class AnimalType
    {
        readonly Type _animalType;
        readonly MethodInfo _factoryMethod;
        readonly MethodInfo _getNameMethod;
        readonly MethodInfo _getPositionXMethod;
        readonly MethodInfo _getPositionYMethod;
        readonly MethodInfo _isAliveMethod;
        readonly object _zoo;

        public AnimalType(
            object zoo,
            Type animalType,
            MethodInfo factoryMethod,
            MethodInfo getNameMethod,
            MethodInfo getPositionXMethod,
            MethodInfo getPositionYMethod,
            MethodInfo isAliveMethod )
        {
            _zoo = zoo;
            _animalType = animalType;
            _factoryMethod = factoryMethod;
            _getNameMethod = getNameMethod;
            _getPositionXMethod = getPositionXMethod;
            _getPositionYMethod = getPositionYMethod;
            _isAliveMethod = isAliveMethod;
        }

        internal string GetNameFor( object animal )
        {
            return ( string )_getNameMethod.Invoke( animal, null );
        }

        internal double GetPositionXFor( object animal )
        {
            return ( double )_getPositionXMethod.Invoke( animal, null );
        }

        internal double GetPositionYFor( object animal )
        {
            return ( double )_getPositionYMethod.Invoke( animal, null );
        }

        public string Name => _animalType.Name;

        public AnimalAdapter CreateInstance( string name )
        {
            object a = _factoryMethod.Invoke( _zoo, new[] { name } );
            return new AnimalAdapter( a, this );
        }

        public Type Type => _animalType;

        internal bool GetIsAliveFor( object animal )
        {
            return ( bool )_isAliveMethod.Invoke( animal, null );
        }
    }
}
