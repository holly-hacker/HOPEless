namespace HOPEless.osu
{
    public enum ReplayAction
    {
        /// <summary>
        /// We're playing bois
        /// </summary>
        Play,

        /// <summary>
        /// Song has just been changed
        /// </summary>
        SongChange,

        /// <summary>
        /// Song intro skipped
        /// </summary>
        Skip,

        /// <summary>
        /// Song completed
        /// </summary>
        Complete,

        /// <summary>
        /// User failed the map
        /// </summary>
        Fail,

        /// <summary>
        /// User paused
        /// </summary>
        Pause,

        /// <summary>
        /// User unpaused
        /// </summary>
        Unpause,

        /// <summary>
        /// User entered song select and is picking a new song.
        /// </summary>
        SongSelect,

        /// <summary>
        /// User is spectating another player.
        /// <para>
        /// The spectated player's id can be found in <seealso 
        /// cref="HOPEless.Bancho.Objects.BanchoReplayFrameBundle.SpectatedPlayerId"/>.
        /// </para>
        /// </summary>
        WatchingOther
    }
}
