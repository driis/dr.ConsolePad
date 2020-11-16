using System;

namespace dr.ConsolePad
{
    public class LightweightProperty
    {
        public string Name { get; }
        public Type Type { get; }
        private readonly Func<object, object> _getter;

        public LightweightProperty(Func<object, object> getter, string name, Type type)
        {
            _getter = getter;
            Name = name;
            Type = type;
        }

        public object GetFrom(object from) => _getter(from);
    }
}