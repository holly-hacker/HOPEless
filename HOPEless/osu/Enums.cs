using System;

namespace HOPEless.osu
{
    //TODO: move into different files

    [Flags]
    public enum Mods
    {
        None        = 0x0,
        NoFail      = 0x1,
        Easy        = 0x2,
        NoVideo     = 0x4,
        Hidden      = 0x8,
        HardRock    = 0x10,
        SuddenDeath = 0x20,
        DoubleTime  = 0x40,
        Relax       = 0x80,
        HalfTime    = 0x100,
        Nightcore   = 0x200,
        Flashlight  = 0x400,
        Autoplay    = 0x800,
        SpunOut     = 0x1000,
        Relax2      = 0x2000,
        Perfect     = 0x4000,
        Key4        = 0x8000,
        Key5        = 0x10000,
        Key6        = 0x20000,
        Key7        = 0x40000,
        Key8        = 0x80000,
        FadeIn      = 0x100000,
        Random      = 0x200000,
        Cinema      = 0x400000,
        Target      = 0x800000,
        Key9        = 0x1000000,
        KeyCoop     = 0x2000000,
        Key1        = 0x4000000,
        Key3        = 0x8000000,
        Key2        = 0x10000000,
        LastMod     = 0x20000000,
    }
    
    public enum PlayModes
    {
        Osu,
        Taiko,
        CatchTheBeat,
        OsuMania
    }

    [Flags]
    public enum UserPermissions
    {
        None       = 0x0,
        Normal     = 0x1,
        BAT        = 0x2,
        Supporter  = 0x4,
        Friend     = 0x8,
        Peppy      = 0x10,
        Tournament = 0x20
    }

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
