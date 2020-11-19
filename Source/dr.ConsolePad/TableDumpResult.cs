using System;
using System.Collections.Generic;
using System.IO;
using ConsoleTables;

namespace dr.ConsolePad
{
    public class TableDumpResult : IDumpResult
    {
        private readonly ConsoleTable _table;
        private readonly IReadOnlyCollection<string> _pre;
        private readonly IReadOnlyCollection<string> _post;

        public TableDumpResult(ConsoleTable table, IReadOnlyCollection<string> pre, IReadOnlyCollection<string> post)
        {
            _table = table;
            _pre = pre;
            _post = post;
        }

        public void Write(TextWriter? outWriter)
        {
            outWriter ??= Console.Out;
            WriteAll(outWriter,_pre);
            _table.Write();
            WriteAll(outWriter, _post);
            outWriter.WriteLine();
        }

        private void WriteAll(TextWriter outWriter, IEnumerable<string> lines)
        {
            foreach (string x in lines)
            {
                outWriter.WriteLine(x);
            }
        }
    }
}