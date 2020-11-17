using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using static System.Console;

namespace dr.ConsolePad
{
    public static class ConsoleExtensions
    {
        public static void Dump<T>(T[] x)
        {
            Dump<T>((IEnumerable<T>)x);
        }
        public static IEnumerable<T> Dump<T>(this IEnumerable<T> rows, string? title = null)
        {
            ConsoleTable? table = null;
            var rowsArray = rows as T[] ?? rows.ToArray();
            foreach (var o in rowsArray)
            {
                if (o == null)
                    continue;
                
                var obj = DeconstructedObject.From(o);
                if (table == null)
                {
                    table = new ConsoleTable(obj.ColumnNames);
                }

                table.AddRow(obj.Values);
            }

            return rowsArray;
        }
        
        public static T Dump<T>(this T o, string? title = null)
        {
            if (o == null)
            {
                WriteLine("<null>");
                return o;
            }

            title ??= o.GetType().Name;
            var obj = DeconstructedObject.From(o);

            WriteLine(title);
            var table = new ConsoleTable("Property", "Value");
            foreach (var p in obj.Type.Properties)
            {
                table.AddRow(p.Name, p.GetFrom(o));
            }
            table.Write();
            return o;
        } 
    }
}
