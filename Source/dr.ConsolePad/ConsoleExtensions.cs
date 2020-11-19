using System;
using System.Collections;
using ConsoleTables;
using static System.Console;

namespace dr.ConsolePad
{
    public static class ConsoleExtensions
    {
        private static readonly ConsoleTable Empty = new ConsoleTable();
        
        public static T Dump<T>(this T o, string? title = null)
        {
            var table = o switch
            {
                null => DumpResult.Empty,
                IEnumerable enumerable => DumpResult.BuildFromEnumerable(enumerable, title),
                IFormattable f => DumpResult.Formatted(f, title),
                _ => DumpResult.BuildFromObject(o, title)
            };

            table.Write(Out);
            return o;
        }
    }
}
