namespace HOPEless.osu
{
    public enum BanchoAction
    {
        Idle,
        Afk,
        Playing,
        Editing,
        Modding,
        Multiplayer,
        Watching,
        Unknown,
        Testing,
        Submitting,
        Paused,
        Lobby,
        Multiplaying,
        OsuDirect
    }

    public enum UserQuitType
    {
        FullDisconnect,
        StillInClient,
        StillOnIrc
    }

    public enum PlayerListType
    {
        None = 0,
        All = 1,
        Friends = 2
    }
}
