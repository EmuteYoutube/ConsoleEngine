using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEngineLib
{
    public class ConsoleKeyInstance
    {
        public ConsoleKeyInstance(char character, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null)
        {
            Character = character;
            this.FgColor = fgColor;
            this.BgColor = bgColor;
        }

        public char Character { get; set; }
        public ConsoleColor? FgColor { get; set; }
        public ConsoleColor? BgColor { get; set; }
        public bool Equals(ConsoleKeyInstance inst)
        {
            return inst.Character == Character && inst.FgColor == FgColor && inst.BgColor == BgColor;
        }
    }
}
