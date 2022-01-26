using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEngineLib
{
    public class Input
    {
        private static ConsoleKeyInfo[] lastKeys = new ConsoleKeyInfo[0];
        public static bool GetKey(ConsoleKey key) => lastKeys.FirstOrDefault(o => o.Key == key) != default;
        internal static void ClearKeys() => lastKeys = new ConsoleKeyInfo[0];
        internal static void SetKeys(ConsoleKeyInfo[] keys) => lastKeys = keys;

    }
}
