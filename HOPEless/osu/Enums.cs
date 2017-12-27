using System;

namespace HOPEless.osu
{
    [Flags]
    public enum ButtonState
    {
        None = 0,
        LeftMouse = 1,
        RightMouse = 2,
        LeftKeyboard = 4,
        RightKeyboard = 8,
        Smoke = 16
    }
}
