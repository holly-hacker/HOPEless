using HOPEless.Bancho.Objects;

namespace HOPEless.Bancho
{
    public enum PacketType : short
    {
        //TODO: if data is a simple type, document what it means?

        /// <summary>
        /// Sends the current status of the user to the server.
        /// <para>Data: <see cref="BanchoUserStatus"/></para>
        /// </summary>
        ClientUserStatus,

        /// <summary>
        /// Sends a chat message in a channel.
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ClientChatMessagePublic,

        /// <summary>
        /// Close the Bancho connection
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientDisconnect,

        /// <summary>
        /// Ask the server for our own user data
        /// <para>Expected response: TODO</para>
        /// </summary>
        ClientStatusRequestOwn,

        /// <summary>
        /// Respond to Bancho's ping command.
        /// <para>Response to: <see cref="ServerPing"/></para>
        /// </summary>
        ClientPong,

        /// <summary>
        /// Reply to initial login. Contains an integer: positive means valid 
        /// login, negative is an error code.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerLoginReply,

        /// <summary>
        /// Originally meant for errors, now unused.
        /// </summary>
        ServerUnused1,

        /// <summary>
        /// Client receives a chat message. Can be in either a channel or PM.
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ServerChatMessage,

        /// <summary>
        /// Ask the client for a pong response.
        /// <para>Expected response: <see cref="ClientPong"/></para>
        /// </summary>
        ServerPing,

        /// <summary>
        /// Informs client that somebody's username has changed
        /// <para>Data: TODO</para>
        /// </summary>
        ServerUserNameChanged,

        /// <summary>
        /// Originally meant for name changes, now unused.
        /// </summary>
        ServerUnused2,

        /// <summary>
        /// Tell the client data about a certain user, including Rank, 
        /// Accuracy, Score, <seealso cref="BanchoUserStatus"/>, and more.
        /// <para>Data: <see cref="BanchoUserData"/></para> TODO: proper newline instead of 2 para's 
        /// <para>Response to: TODO</para>
        /// </summary>
        ServerUserData,

        /// <summary>
        /// Inform client that a user has disconnected.
        /// <para>Data: <see cref="BanchoUserQuit"/></para>
        /// </summary>
        ServerUserQuit,

        /// <summary>
        /// Inform the client that a spectator has joined.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerSpectateSpectatorJoined,

        /// <summary>
        /// Inform the client that a spectator has left.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerSpectateSpectatorLeft,

        /// <summary>
        /// Inform the client of what the spectated user is doing. This can
        /// include replay frames if the spectated user is playing.
        /// <para>Data: <see cref="BanchoReplayFrameBundle"/></para>
        /// </summary>
        ServerSpectateData,

        /// <summary>
        /// Inform the server that we started spectating.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientSpectateStart,

        /// <summary>
        /// Inform the server that we stopped spectating.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientSpectateStop,

        /// <summary>
        /// Inform the server of what we're doing. This can include replay 
        /// frames if we're playing.
        /// <para>Data: <see cref="BanchoReplayFrameBundle"/></para>
        /// </summary>
        ClientSpectateData,

        /// <summary>
        /// Tell the client that they should check for client updates.
        /// </summary>
        ServerUpdateCheck,

        /// <summary>
        /// Originally used for error reports, now unused.
        /// </summary>
        ClientUnused3,

        /// <summary>
        /// Tell the server we don't have the beatmap that the spectated user
        /// is playing.
        /// </summary>
        ClientSpectateNoBeatmap,

        /// <summary>
        /// Inform the client that a spectator does not have your beatmap.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerSpectateNoBeatmap,

        /// <summary>
        /// Tell client to open the chat window.
        /// </summary>
        ServerChatFocus,

        /// <summary>
        /// Creates a notification bubble in the client.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerNotification,

        /// <summary>
        /// Sends a chat message to a user..
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ClientChatMessagePrivate,

        /// <summary>
        /// Informs the client that the details of a multiplayer match have
        /// been updated.
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// </summary>
        ServerMultiMatchUpdate,

        /// <summary>
        /// Informs the client that a new multiplayer match has been created.
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// </summary>
        ServerMultiMatchNew,

        /// <summary>
        /// Informs the client that a multiplayer match has been deleted.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerMultiMatchDelete,

        /// <summary>
        /// Inform bancho that we left the lobby, so stop sending us match
        /// updates already!
        /// </summary>
        ClientLobbyLeave,

        /// <summary>
        /// Informs bancho that we joined the lobby, so it can send us match
        /// information.
        /// </summary>
        ClientLobbyJoin,

        /// <summary>
        /// Tell bancho we created a multiplayer match.
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// </summary>
        ClientMultiMatchCreate,

        /// <summary>
        /// Tell bancho we want to join a match.
        /// <para>Data: TODO create BanchoMultiplayerJoin, which is int32 id, string pass</para>
        /// </summary>
        ClientMultiMatchJoin,

        /// <summary>
        /// Tell bancho we left the match.
        /// </summary>
        ClientMultiMatchLeave,

        /// <summary>
        /// Originally for joining the multiplayer lobby, now unused.
        /// </summary>
        ServerUnused4,

        /// <summary>
        /// Originally for leaving the multiplayer lobby, now unused.
        /// </summary>
        ServerUnused5,

        /// <summary>
        /// Tell the client they joined the match.
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// TODO: response to what
        /// </summary>
        ServerMultiMatchJoinSuccess,

        /// <summary>
        /// Tell the client they failed to join the match.
        /// TODO: response to what
        /// </summary>
        ServerMultiMatchJoinFail,

        /// <summary>
        /// Tell bancho we changed to a different slot.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiSlotChange,

        /// <summary>
        /// Tell Bancho we're set to Ready.
        /// </summary>
        ClientMultiReady,

        /// <summary>
        /// Tell bancho we locked a slot
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiSlotLock,

        /// <summary>
        /// Tell bancho we changed the multiplayer settings
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// </summary>
        ClientMultiSettingsChange,

        /// <summary>
        /// Inform the client that another spectator joined.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerSpectateOtherSpectatorJoined,

        /// <summary>
        /// Inform the client that another spectator left.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerSpectateOtherSpectatorLeft,

        /// <summary>
        /// Tell bancho that we started the game.
        /// </summary>
        ClientMultiMatchStart,

        /// <summary>
        /// Unused, unknown, likely intended as <seealso cref="ServerMultiAllPlayersLoaded"/>
        /// </summary>
        UnknwnUnused6,

        /// <summary>
        /// Tell the client that the multiplayer match has started.
        /// <para>Data: <see cref="BanchoMultiplayerMatch"/></para>
        /// </summary>
        ServerMultiMatchStart,

        /// <summary>
        /// Inform the client of the score of the other players.
        /// <para>Data: <see cref="BanchoScoreFrame"/></para>
        /// </summary>
        ClientMultiScoreUpdate,

        /// <summary>
        /// Inform Bancho of our score.
        /// <para>Data: <see cref="BanchoScoreFrame"/></para>
        /// </summary>
        ServerMultiScoreUpdate,

        /// <summary>
        /// Tell bancho that we finished the match.
        /// </summary>
        ServerMultiMatchCompleted,

        /// <summary>
        /// Tell the client we received host privileges.
        /// </summary>
        ServerMultiHostTransfer,

        /// <summary>
        /// Inform the server that we changed out current mods.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiChangeMods,

        /// <summary>
        /// TODO: inspect
        /// </summary>
        ClientMultiMatchLoadComplete,

        /// <summary>
        /// Tells the client that all players are loaded.
        /// TODO: some proper information instead of this vague bullshit
        /// </summary>
        ServerMultiAllPlayersLoaded,

        /// <summary>
        /// Tell bancho we don't have the selected beatmap.
        /// </summary>
        ClientMultiBeatmapMissing,

        /// <summary>
        /// Opposite of <seealso cref="ClientMultiReady"/>
        /// </summary>
        ClientMultiNotReady,

        /// <summary>
        /// Tell bancho we failed. Better luck next time!
        /// </summary>
        ClientMultiFailed,

        /// <summary>
        /// Tell the client that somebody failed. What a loser.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerMultiOtherFailed,

        /// <summary>
        /// Tell the client that all players finished the map, and they should
        /// go to the results screen.
        /// </summary>
        ServerMultiMatchFinished,

        /// <summary>
        /// Tell bancho that we have the beatmap. Opposite of 
        /// <see cref="ClientMultiBeatmapMissing"/>
        /// </summary>
        ClientMultiBeatmapAvailable,

        /// <summary>
        /// Ask bancho to skip the intro of a song.
        /// </summary>
        ClientMultiSkipRequest,

        /// <summary>
        /// Tell the client that everybody skipped.
        /// </summary>
        ServerMultiSkip,

        /// <summary>
        /// Originally meant "unauthorized". Currently not in use.
        /// </summary>
        ServerUnused7,

        /// <summary>
        /// Tell bancho we want to join a chat channel.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ClientChatChannelJoin,

        /// <summary>
        /// Tell the client that they succesfully joined a channel.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerChatChannelJoinSuccess,

        /// <summary>
        /// Tell the client that a chat channel is available
        /// <para>Data: <see cref="BanchoChatChannel"/></para>
        /// </summary>
        ServerChatChannelAvailable,

        /// <summary>
        /// Tell the client that they no longer have access to a channel.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerChatChannelRevoked,

        /// <summary>
        /// Tell the client that a chat channel is available, and they should
        /// auto-join it.
        /// <para>Data: <see cref="BanchoChatChannel"/></para>
        /// </summary>
        ServerChatChannelAvailableAutojoin,

        /// <summary>
        /// Ask bancho for information on beatmaps.
        /// <para>Data: <see cref="BanchoBeatmapInfoRequest"/></para>
        /// <para>Expected response: <see cref="ServerBeatmapInfoReply"/></para>
        /// </summary>
        ClientBeatmapInfoRequest,

        /// <summary>
        /// Respond to a <seealso cref="ClientBeatmapInfoRequest"/> packet.
        /// <para>Data: TODO create BanchoBeatmapInfoReply</para>
        /// </summary>
        ServerBeatmapInfoReply,

        /// <summary>
        /// Tell the server we want to transfer the host privileges to somebody
        /// else.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiTransferHost,

        /// <summary>
        /// Tell client what permissions we have. Response to login packet.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerUserPermissions,

        /// <summary>
        /// Tell the server who their friends are.
        /// <para>Data: <see cref="BanchoIntList"/></para>
        /// </summary>
        ServerFriendsList,

        /// <summary>
        /// Tell the server we just made a new friend!
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientFriendsAdd,

        /// <summary>
        /// Tell the server we just lost a friend!
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientFriendsRemove,

        /// <summary>
        /// Tell the client what Bancho version we are.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerBanchoVersion,

        /// <summary>
        /// Tell the client to show a clickable image on the bottom of the main
        /// menu, which acts as a hyperlink.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerMainMenuNews,

        /// <summary>
        /// Inform the server that we just toggled teams in the current 
        /// multiplayer match.
        /// </summary>
        ClientMultiChangeTeam,

        /// <summary>
        /// Tell the server we left a chat channel.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ClientChatChannelLeave,

        /// <summary>
        /// Ask the server for a list of players.
        /// <para>Expected response: TODO</para>
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientRequestPlayerList,

        /// <summary>
        /// Unused, originally used to trigger spyware (such as taking desktop
        /// screenshot, uploading files, uploading process list)
        /// </summary>
        ServerUnused8,

        /// <summary>
        /// Another player has requested a skip.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerMultiSkipRequestOther,

        /// <summary>
        /// The same as /away in IRC.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ClientAway,

        /// <summary>
        /// Gives the client user presence data.
        /// <para>Data: <see cref="BanchoUserPresence"/></para>
        /// </summary>
        ServerUserPresence,

        /// <summary>
        /// Unused, but seems to be used for IRC commands?
        /// </summary>
        UnknwnUnused9,

        /// <summary>
        /// Ask for <seealso cref="ServerUserData"/> for a list of users.
        /// <para>Data: <see cref="BanchoIntList"/></para>
        /// <para>Expected response: <see cref="ServerUserData"/></para>
        /// </summary>
        ClientUserStatsRequest,

        /// <summary>
        /// A bancho restart is scheduled.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerRestart,

        /// <summary>
        /// Tell server to send a multiplayer invite to a player.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiInvite,

        /// <summary>
        /// Tell client they received a multiplayer invite.
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ServerMultiInvite,

        /// <summary>
        /// Tell the client that we're done enumerating chat channels.
        /// </summary>
        ServerChatChannelListingComplete,

        /// <summary>
        /// Tell the server we want to change the password for the current 
        /// match.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ClientMultiChangePassword,

        /// <summary>
        /// Tell the client that the password has been changed.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerMultiChangePassword,

        /// <summary>
        /// Tell the client that their client should be locked for x seconds,
        /// meaning they can not log in.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerLockClient,

        /// <summary>
        /// Request match information update. Seems to be related to tourney.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientMultiMatchInfoRequest,

        /// <summary>
        /// Someone got muted.
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerUserSilenced,

        /// <summary>
        /// TODO
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ServerUserPresenceSingle,   //TODO: more informative name?

        /// <summary>
        /// Collection version of <seealso cref="ServerUserPresenceSingle"/>
        /// <para>Data: <see cref="BanchoIntList"/></para>
        /// </summary>
        ServerUserPresenceBundle,   //TODO: more informative name?

        /// <summary>
        /// Request presence information from the server.
        /// <para>Data: <see cref="BanchoIntList"/></para>
        /// </summary>
        ClientUserPresenceRequest,

        /// <summary>
        /// TODO
        /// <para>Data: <see cref="BanchoInt"/></para>
        /// </summary>
        ClientUserPresenceRequestAll,

        /// <summary>
        /// Tell the server we wish to toggle blocking non-friend PMs.
        /// </summary>
        ClientUserToggleBlockNonFriendPm,

        /// <summary>
        /// Tell the client that the user they are trying to reach has blocked
        /// PMs from non-friends.
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ServerChatPmBlocked,

        /// <summary>
        /// Tell the client that the user they are trying to reach is silenced.
        /// <para>Data: <see cref="BanchoChatMessage"/></para>
        /// </summary>
        ServerChatPmTargetSilenced,

        /// <summary>
        /// Tell the client that they should check for client updates, and
        /// restart right away after installing an update.
        /// </summary>
        ServerUpdateCheckForceRestart,

        /// <summary>
        /// Tell the client to use the backup bancho server c1.ppy.sh.
        /// </summary>
        ServerSwitchServer,

        /// <summary>
        /// Tells the client it is restricted, practically unused.
        /// </summary>
        ServerRestricted,

        /// <summary>
        /// Send the client a spooky message.
        /// <para>Data: <see cref="BanchoString"/></para>
        /// </summary>
        ServerRtx,                  //fancy message

        /// <summary>
        /// Tell the server we quit the multi match.
        /// </summary>
        ClientMultiAbort,

        /// <summary>
        /// TODO
        /// </summary>
        BanchoSwitchTourneyServer,

        /// <summary>
        /// Tell the server we want to join some multiplayer channel.
        /// Tournament only.
        /// TODO
        /// </summary>
        ClientMultiJoinChannel,

        /// <summary>
        /// Tell the server we left some multiplayer channel. Tournament only.
        /// TODO
        /// </summary>
        ClientMultiLeaveChannel //should be #109
    }
}
