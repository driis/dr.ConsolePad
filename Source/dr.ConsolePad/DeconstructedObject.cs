using System.Linq;

namespace dr.ConsolePad
{
    public class DeconstructedObject
    {
        public object Original { get; }
        public TypeDescriptor Type { get; }

        public string[] ColumnNames => Type.Properties.Select(x => x.Name).ToArray();
        public object[] Values => Type.Properties.Select(x => x.GetFrom(Original)).ToArray();
        
        private DeconstructedObject(object original, TypeDescriptor type)
        {
            Original = original;
            Type = type;
        }

        public static DeconstructedObject From(object o)
        {
            return new DeconstructedObject(o, TypeDescriptor.Describe(o.GetType()));
        }
    }
}