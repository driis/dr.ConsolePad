using System;
using System.IO;

namespace dr.ConsolePad
{
    public class SimpleDumpResult : IDumpResult
    {
        private readonly string _line;

        public SimpleDumpResult(string line)
        {
            _line = line;
        }


        public void Write(TextWriter? outWriter)
        {
            outWriter ??= Console.Out;
            outWriter.WriteLine(_line);
        }
    }
}