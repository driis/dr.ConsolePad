using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace dr.ConsolePad
{
    public class TypeDescriptor
    {
        [ThreadStatic]
        private static Dictionary<Type, TypeDescriptor>? _typeDescriptors;

        private static readonly Type ObjectType = typeof(object);

        public static TypeDescriptor Describe(Type t)
        {
            if(_typeDescriptors == null)
                _typeDescriptors = new Dictionary<Type, TypeDescriptor>();

            if (!_typeDescriptors.TryGetValue(t, out var descriptor))
            {
                descriptor = DescribeType(t);
                _typeDescriptors[t] = descriptor;
            }

            return descriptor;
        }

        private static TypeDescriptor DescribeType(Type t)
        {
            var props = t.GetProperties().Where(x => x.CanRead).ToArray();
            var lightweight = props.Select(p => new LightweightProperty(GetFunc(p), p.Name, p.PropertyType)).ToArray();
            return new TypeDescriptor(t, lightweight);
        }

        private static Func<object, object> GetFunc(PropertyInfo property)
        {
            var method = property.GetMethod!;
            var objectParameter = Expression.Parameter(ObjectType, "o");
            var parameterCastToType = Expression.Convert(objectParameter, property.DeclaringType!);
            var propertyGet = Expression.Property(parameterCastToType, method);
            var body = Expression.Convert(propertyGet, ObjectType);
            var lambda = Expression.Lambda<Func<object,object>>(body, objectParameter);
            return lambda.Compile();
        }
        
        public TypeDescriptor(Type originalType, IReadOnlyCollection<LightweightProperty> properties)
        {
            OriginalType = originalType;
            Properties = properties;
        }

        public Type OriginalType { get; }
        public IReadOnlyCollection<LightweightProperty> Properties { get; }
    }
}