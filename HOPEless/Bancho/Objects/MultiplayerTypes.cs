using HOPEless.Extensions;
using HOPEless.osu;
using osu.Shared;
using osu.Shared.Serialization;

namespace HOPEless.Bancho.Objects
{
    public class BanchoMultiplayerJoin : ISerializable
    {
        public int MatchId;
        public string Password;

        public BanchoMultiplayerJoin() { }
        public BanchoMultiplayerJoin(byte[] data) => this.Populate(data);
        public BanchoMultiplayerJoin(int matchId, string password)
        {
            MatchId = matchId;
            Password = password;
        }

        public void ReadFromStream(SerializationReader r)
        {
            MatchId = r.ReadInt32();
            Password = r.ReadString();
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write(MatchId);
            w.Write(Password);
        }
    }

    public class BanchoMultiplayerMatch : ISerializable
    {
        public string GameName;
        public int MatchId;
        public MultiTypes MultiType;

        public MultiSlotStatus[] MultiSlotStatus = new MultiSlotStatus[Constants.MultiplayerMaxPlayers];
        public int[] SlotId = new int[Constants.MultiplayerMaxPlayers];
        public SlotTeams[] SlotTeam = new SlotTeams[Constants.MultiplayerMaxPlayers];
        public Mods[] SlotMods = new Mods[Constants.MultiplayerMaxPlayers];

        public string BeatmapName;
        public string BeatmapChecksum;
        public int BeatmapId = -1;
        public bool InProgress;
        public Mods ActiveMods;
        public int HostId;
        public GameMode PlayMode;
        public MultiWinConditions MultiWinCondition;
        public MultiTeamTypes MultiTeamType;
        public MultiSpecialModes SpecialModes;
        public int Seed;

        public string GamePassword; //can be null

        public BanchoMultiplayerMatch() { }
        public BanchoMultiplayerMatch(byte[] data) => this.Populate(data);

        public void ReadFromStream(SerializationReader r)
        {
            MatchId = r.ReadUInt16();
            InProgress = r.ReadBoolean();
            MultiType = (MultiTypes)r.ReadByte();
            ActiveMods = (Mods)r.ReadUInt32();
            GameName = r.ReadString();
            GamePassword = r.ReadString();
            BeatmapName = r.ReadString();
            BeatmapId = r.ReadInt32();
            BeatmapChecksum = r.ReadString();

            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                MultiSlotStatus[i] = (MultiSlotStatus)r.ReadByte();

            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                SlotTeam[i] = (SlotTeams)r.ReadByte();

            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                SlotId[i] = (MultiSlotStatus[i] & (MultiSlotStatus)0b01111100) > 0 ? r.ReadInt32() : -1;

            HostId = r.ReadInt32();

            PlayMode = (GameMode)r.ReadByte();

            MultiWinCondition = (MultiWinConditions)r.ReadByte();
            MultiTeamType = (MultiTeamTypes)r.ReadByte();
            
            SpecialModes = (MultiSpecialModes)r.ReadByte();

            if (GameName.Length > 50)
                GameName = GameName.Remove(50);

            if ((SpecialModes & MultiSpecialModes.FreeMod) > 0)
                for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                    SlotMods[i] = (Mods)r.ReadInt32();
            Seed = r.ReadInt32();
        }

        public void WriteToStream(SerializationWriter w)
        {
            //write basic info
            w.Write((short)MatchId);
            w.Write(InProgress);
            w.Write((byte)MultiType);
            w.Write((uint)ActiveMods);
            w.Write(GameName);
            w.Write(GamePassword);
            w.Write(BeatmapName);
            w.Write(BeatmapId);
            w.Write(BeatmapChecksum);

            //write each slot's status
            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                w.Write((byte)MultiSlotStatus[i]);

            //write each slot's team
            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                w.Write((byte)SlotTeam[i]);

            //write each used slot's player id
            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                if ((MultiSlotStatus[i] & (MultiSlotStatus)0b1111100) > 0)
                    w.Write(SlotId[i]);

            //write id of the host, so someone can have the crown!
            w.Write(HostId);

            //write enums
            w.Write((byte)PlayMode);
            w.Write((byte)MultiWinCondition);
            w.Write((byte)MultiTeamType);
            w.Write((byte)SpecialModes);

            //if freemod is enabled, read all mods
            if ((SpecialModes & MultiSpecialModes.FreeMod) > 0)
                for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                    w.Write((int)SlotMods[i]);

            //write shared random seed, used for CtB I assume
            w.Write(Seed);
        }
    }
}
