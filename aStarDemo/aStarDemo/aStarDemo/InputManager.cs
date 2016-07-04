using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace aStarDemo
{
    public static class InputManager
    {
        static MouseState ms;
        public static MouseState CurrentMouse
        {
            get
            {
                return ms;
            }
        }

        static MouseState lastMs;
        public static MouseState LastMouse
        {
            get
            {
                return lastMs;
            }
        }

        static KeyboardState ks;
        public static KeyboardState CurrentKeyboard
        {
            get
            {
                return ks;
            }
        }

        static KeyboardState lastKs;
        public static KeyboardState LastKeyboard
        {
            get
            {
                return lastKs;
            }
        }

        public static void Update()
        {
            lastKs = ks;
            lastMs = ms;

            ms = Mouse.GetState();
            ks = Keyboard.GetState();
        }
        
        public static bool IsKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }
        public static bool IsKeyReleased(Keys key)
        {
            return ks.IsKeyUp(key);
        }
        public static bool IsKeyPressed(Keys key)
        {
            return ks.IsKeyDown(key) && lastKs.IsKeyUp(key);
        }
        public static bool IsMouseDown()
        {
            return ms.LeftButton == ButtonState.Pressed;
        }
        public static bool IsMouseDown(Rectangle bounds)
        {
            return ms.LeftButton == ButtonState.Pressed && bounds.Contains(ms.X, ms.Y);
        }
        public static bool IsMouseReleased()
        {
            return ms.LeftButton == ButtonState.Released;
        }

        internal static bool IsMouseReleased(Rectangle bounds)
        {
            return ms.LeftButton == ButtonState.Released && bounds.Contains(ms.X, ms.Y);
        }

        public static bool IsMouseClicked(Rectangle bounds)
        {
            return ms.LeftButton == ButtonState.Pressed && lastMs.LeftButton == ButtonState.Released && bounds.Contains(ms.X, ms.Y);
        }
        public static bool IsMouseClicked()
        {
            return ms.LeftButton == ButtonState.Pressed && lastMs.LeftButton == ButtonState.Released;
        }
        public static bool IsMouseMovedOutOfBounds(Rectangle bounds)
        {
            return bounds.Contains(lastMs.X, lastMs.Y) && !bounds.Contains(ms.X, ms.Y);
        }
        public static void ResetLastMouseState()
        {
            lastMs = new MouseState(lastMs.X, lastMs.Y, lastMs.ScrollWheelValue, ButtonState.Released, lastMs.MiddleButton, lastMs.RightButton, lastMs.XButton1, lastMs.XButton2);
        }
        public static bool IsMouseMovedIntoBounds(Rectangle bounds)
        {
            return  bounds.Contains(ms.X, ms.Y) && !bounds.Contains(lastMs.X, lastMs.Y);
        }
        public static bool IsMouseOverBounds(Rectangle bounds)
        {
            return bounds.Contains(ms.X, ms.Y);
        }
    }
}
