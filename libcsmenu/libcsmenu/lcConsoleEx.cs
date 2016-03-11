using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcsmenu
{
    public class ConsoleEx
    {
        public static void Write(lcString s)
        {
            var bg = Console.BackgroundColor;
            var fg = Console.ForegroundColor;
            Console.BackgroundColor = s.BackgroundColor;
            Console.ForegroundColor = s.ForegroundColor;
            Console.Write(s);
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
        }

        public static void WriteLine(lcString s)
        {
            Write(s);
            Write("\n");
        }

        public static string Input()
        {
            return Console.ReadLine();
        }

        public static string Input(lcString prefix)
        {
            Write(prefix);
            return Input();
        }

        public static KeyValuePair<int, lcString> Select(Dictionary<int, lcString> entriesDict, ConsoleColor selectFg,
            ConsoleColor selectBg, bool showID = true, int pad = 0, bool sort = false, int def = 0)
        {
            if (entriesDict.Count == 0)
                throw new ArgumentException("There must be at least one entry.", nameof(entriesDict));
            var y = Console.CursorTop;
            var x = Console.CursorLeft;
            var selected = 0;

            var entries = entriesDict.ToList();
            if (sort)
            {
                entries.Sort((pair, valuePair) => pair.Key.CompareTo(valuePair.Key));
            }

            ConsoleKey k = 0;

            do
            {
                switch (k)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(entries.Count - 1, selected + 1);
                        break;
                }

                Console.CursorTop = y;
                Console.CursorLeft = x;

                var i = 0;

                foreach (var kvp in entries)
                {
                    var tc = kvp.Value.Clone();

                    if (showID)
                    {
                        tc = "[" + kvp.Key + "] " + tc;
                    }
                    tc = new string(' ', pad) + tc;

                    if (i == selected)
                    {
                        tc.ForegroundColor = selectFg;
                        tc.BackgroundColor = selectBg;
                    }

                    WriteLine(tc);

                    i++;
                }


            } while ((k = Console.ReadKey().Key) != ConsoleKey.Enter);

            return entries[selected];
        }
    }
}
