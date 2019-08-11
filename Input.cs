using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Penguin_Wars
{
    class Input
    {
        private static Hashtable keys = new Hashtable();

        public static void ChangeState(Keys key, bool state)
        {
            keys[key] = state;
        }

        public static bool Pressed(Keys key)
        {
            if (keys[key] == null)
                return false;
            return (bool)keys[key];
        }
    }
}
