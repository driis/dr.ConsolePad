using System.IO;

namespace dr.ConsolePad
{
    public interface IDumpResult
    {
        void Write(TextWriter? outWriter = null);
    }
}