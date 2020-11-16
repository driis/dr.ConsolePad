using System.Collections.Generic;
using ConsoleTables;
using static System.Console;

namespace dr.ConsolePad
{
    public static class ConsoleExtensions
    {
        public static void Dump<T>(this IEnumerable<T> rows, string title = null)
        {
            
        }
        
        public static void Dump(this object? o, string? title = null)
        {
            if (o == null)
                return;

            title ??= o.GetType().Name;
            var obj = DeconstructedObject.From(o);

            WriteLine(title);
            var table = new ConsoleTable("Property", "Value");
            foreach (var p in obj.Type.Properties)
            {
                table.AddRow(p.Name, p.GetFrom(o));
            }
            table.Write();
        } 
    }
}
