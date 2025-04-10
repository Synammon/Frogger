using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace Frogger
{
    public enum MouseButtons
    {
        Left,
        Right,
        Center
    }

    public class Xin : GameComponent
    {
        private static KeyboardState currentKeyboardState = Keyboard.GetState();
        private static KeyboardState previousKeyboardState = Keyboard.GetState();

        private static MouseState currentMouseState = Mouse.GetState();
        private static MouseState previousMouseState = Mouse.GetState();

        private static TouchCollection touchPanelState = TouchPanel.GetState();
        private static TouchCollection lastTouchPanelState = TouchPanel.GetState();

        public static MouseState MouseState
        {
            get { return currentMouseState; }
        }

        public static KeyboardState KeyboardState
        {
            get { return currentKeyboardState; }
        }

        public static KeyboardState PreviousKeyboardState
        {
            get { return previousKeyboardState; }
        }

        public static bool Tapped()
        {
            TouchCollection tc = touchPanelState;
            TouchCollection tcl = lastTouchPanelState;

            return tc.Count > tcl.Count;
        }

        public static MouseState PreviousMouseState
        {
            get { return previousMouseState; }
        }

        public static TouchCollection TouchPanelState
        {
            get { return touchPanelState; }
        }

        public static TouchCollection LastTouchPanelState
        {
            get { return lastTouchPanelState; }
        }
        public static bool CheckAnyKeyPressed()
        {
            return (currentKeyboardState.GetPressedKeys().Length > 0 && previousKeyboardState.GetPressedKeys().Length == 0);
        }

        public static bool CheckAnyKeyReleased()
        {
            return currentKeyboardState.GetPressedKeys().Length < previousKeyboardState.GetPressedKeys().Length;
        }

        public static bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public static Point MouseAsPoint { get; internal set; }

        public static Vector2 MouseAsVector
        {
            get { return new Vector2(MouseAsPoint.X, MouseAsPoint.Y); }
        }

        public static Vector2 TouchLocation
        {
            get
            {
                Vector2 result = Vector2.Zero;

                if (touchPanelState.Count > 0)
                {
                    if (touchPanelState[0].State == TouchLocationState.Pressed ||
                        touchPanelState[0].State == TouchLocationState.Moved)
                    {
                        result = touchPanelState[0].Position;
                    }
                }

                return result;
            }
        }

        public Xin(Game game)
            : base(game)
        {
            TouchPanel.EnableMouseTouchPoint = true;
        }

        public override void Update(GameTime gameTime)
        {
            Xin.lastTouchPanelState = Xin.TouchPanelState;
            Xin.touchPanelState = TouchPanel.GetState();

            Xin.previousKeyboardState = Xin.currentKeyboardState;
            Xin.currentKeyboardState = Keyboard.GetState();

            Xin.previousMouseState = Xin.currentMouseState;
            Xin.currentMouseState = Mouse.GetState();

            MouseAsPoint = new Point(currentMouseState.X, currentMouseState.Y);

            base.Update(gameTime);
        }

        public static void FlushInput()
        {
            currentMouseState = previousMouseState;
            currentKeyboardState = previousKeyboardState;
        }

        public static bool CheckKeyReleased(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
        }

        public static bool CheckMouseReleased(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => (currentMouseState.LeftButton == ButtonState.Released) && (previousMouseState.LeftButton == ButtonState.Pressed),
                MouseButtons.Right => (currentMouseState.RightButton == ButtonState.Released) && (previousMouseState.RightButton == ButtonState.Pressed),
                MouseButtons.Center => (currentMouseState.MiddleButton == ButtonState.Released) && (previousMouseState.MiddleButton == ButtonState.Pressed),
                _ => false
            };
        }

        public static bool CheckKeyPressed(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        public static bool CheckMousePressed(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => (currentMouseState.LeftButton == ButtonState.Pressed) && (previousMouseState.LeftButton == ButtonState.Released),
                MouseButtons.Right => (currentMouseState.RightButton == ButtonState.Pressed) && (previousMouseState.RightButton == ButtonState.Released),
                MouseButtons.Center => (currentMouseState.MiddleButton == ButtonState.Pressed) && (previousMouseState.MiddleButton == ButtonState.Released),
                _ => false
            };
        }
    }
}
