using System;

namespace HOPEless.osu
{
    public enum MultiTypes
    {
        Standard = 0,
        Powerplay = 1   //according to a reasonable source, api docs just say "couldn't find"
    }

    public enum MultiWinConditions
    {
        Score = 0,
        Accuracy = 1,
        Combo = 2,
        ScoreV2 = 3,
    }

    public enum MultiTeamTypes
    {
        HeadToHead = 0,
        TagCoop = 1,
        TeamVs = 2,
        TagTeamVs = 3
    }

    [Flags]
    public enum MultiSlotStatus
    {
        Open = 1,
        Locked = 2,
        NotReady = 4,
        Ready = 8,
        NoMap = 16,
        Playing = 32,
        Complete = 64,
        Quit = 128
    }

    [Flags]
    public enum MultiSpecialModes
    {
        None = 0,
        FreeMod = 1
    }

    public enum SlotTeams
    {
        Neutral,
        Blue,
        Red
    }
}
