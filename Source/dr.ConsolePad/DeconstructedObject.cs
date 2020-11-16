namespace dr.ConsolePad
{
    public class DeconstructedObject
    {
        public object Original { get; }
        public TypeDescriptor Type { get; }

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