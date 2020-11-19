using System;
using System.Collections;
using System.Linq;
using ConsoleTables;

namespace dr.ConsolePad
{
    public static class DumpResult
    {
        public static IDumpResult Empty { get; } = new EmptyDumpResult();

        public static IDumpResult BuildFromEnumerable(IEnumerable rows, string? title = null, int maxCount = 100)
        {
            ConsoleTable? table = null;
            title ??= rows.GetType().ToString();
            var enumerable = rows as object[] ?? rows.Cast<object>().ToArray();
            foreach (var o in enumerable)
            {
                var obj = DeconstructedObject.From(o);
                if (table == null)
                {
                    table = new ConsoleTable(obj.ColumnNames);
                }

                table.AddRow(obj.Values);
            }

            return new TableDumpResult(table ?? new ConsoleTable(), new[] {title}, new string[0]);
        }

        public static IDumpResult BuildFromObject<T>(T obj, string? title = null)
        {
            if (obj == null)
                return Empty;
            
            title ??= obj.GetType().Name;
            var dec = DeconstructedObject.From(obj);
            var table = new ConsoleTable("Property", "Value");
            foreach (var p in dec.Type.Properties)
            {
                table.AddRow(p.Name, p.GetFrom(obj));
            }

            return new TableDumpResult(table, new[] {title}, new string[0]);
        }

        public static IDumpResult Formatted(IFormattable formattable, string? title = null)
        {
            string line = $"{formattable}";
            if (title != null)
                line = $"{title}: {line}";
            return new SimpleDumpResult(line);
        }
    }
}