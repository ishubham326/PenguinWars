using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Penguin_Wars
{
    class KeyboardController
    {
        public event EventHandler KeyboardTick;
        private Timer timer;
        private HashSet<Keys> pressedKeys;
        private readonly object pressedKeysLock = new object();

        public KeyboardController(Form c)
        {
            c.KeyDown += WinKeyDown;
            c.KeyUp += WinKeyUp;
            pressedKeys = new HashSet<Keys>();

            timer = new Timer();
            timer.Tick += kbTimer_Tick;
            timer.Interval = 10;
            timer.Start();
        }

        public bool KeyDown(Keys key)
        {
            lock (pressedKeysLock)
            {
                return pressedKeys.Contains(key);
            }
        }

        private void WinKeyDown(object sender, KeyEventArgs e)
        {
            lock (pressedKeysLock)
            {
                pressedKeys.Add(e.KeyCode);
            }
        }

        private void WinKeyUp(object sender, KeyEventArgs e)
        {
            lock (pressedKeysLock)
            {
                pressedKeys.Remove(e.KeyCode);
            }
        }

        private void kbTimer_Tick(object sender, EventArgs e)
        {
            var handler = KeyboardTick;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}



