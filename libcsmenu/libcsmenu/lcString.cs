using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcsmenu
{
    public class lcString
    {
        public string Text { get; set; } = "";

        public ConsoleColor ForegroundColor { get; set; } = lcGlobal.ForegroundColor;

        public ConsoleColor BackgroundColor { get; set; } = lcGlobal.BackgroundColor;

        public lcString()
        {
        }

        public lcString(string text)
        {
            Text = text;
        }

        public lcString(string text, ConsoleColor fore, ConsoleColor back)
        {
            Text = text;
            ForegroundColor = fore;
            BackgroundColor = back;
        }

        public static implicit operator lcString(string s)
        {
            return new lcString(s);
        }

        public static explicit operator string(lcString s)
        {
            return s.Text;
        }

        public static lcString operator +(string s0, lcString s1)
        {
            return new lcString(s0 + s1.Text, s1.ForegroundColor, s1.BackgroundColor);
        }

        public static lcString operator +(lcString s1, string s0)
        {
            return new lcString(s1.Text + s0, s1.ForegroundColor, s1.BackgroundColor);
        }

        public static lcString operator +(lcString s0, lcString s1)
        {
            return s0 + s1.Text;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Text;
        }

        public lcString Clone()
        {
             return new lcString(Text, ForegroundColor, BackgroundColor);
        }
    }
}
