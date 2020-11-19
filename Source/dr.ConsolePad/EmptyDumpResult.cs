using System.IO;

namespace dr.ConsolePad
{
    public class EmptyDumpResult : IDumpResult
    {
        public void Write(TextWriter? outWriter = null) { }
    }
}