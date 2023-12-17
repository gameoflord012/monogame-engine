using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ
{
    internal partial class CruZ
    {
        public void Input_Update(GameTime gameTime)
        {
            _prevMouseState = _curMouseState;
            _curMouseState = Mouse.GetState();
            _keyboardState = Keyboard.GetState();
        }

        public int Input_ScrollDeltaValue()
        {
            return _curMouseState.ScrollWheelValue - _prevMouseState.ScrollWheelValue;
        }

        MouseState _prevMouseState;
        MouseState _curMouseState;
        KeyboardState _keyboardState;
    }
}
