using HOPEless.Extensions;
using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoMultiplayerMatch : IBanchoSerializable
    {
        public string GameName;
        public int MatchId;
        public MultiTypes MultiType;

        public MutiSlotStatus[] MutiSlotStatus = new MutiSlotStatus[Constants.MultiplayerMaxPlayers];
        public int[] SlotId = new int[Constants.MultiplayerMaxPlayers];
        public SlotTeams[] SlotTeam = new SlotTeams[Constants.MultiplayerMaxPlayers];
        public Mods[] SlotMods = new Mods[Constants.MultiplayerMaxPlayers];

        public string BeatmapName;
        public string BeatmapChecksum;
        public int BeatmapId = -1;
        public bool InProgress;
        public Mods ActiveMods;
        public int HostId;
        public PlayModes PlayMode;
        public MultiWinConditions MultiWinCondition;
        public MultiTeamTypes MultiTeamType;
        public MultiSpecialModes SpecialModes;
        public int Seed;

        public string GamePassword; //can be null

        public BanchoMultiplayerMatch() { }
        public BanchoMultiplayerMatch(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
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
                MutiSlotStatus[i] = (MutiSlotStatus)r.ReadByte();

            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                SlotTeam[i] = (SlotTeams)r.ReadByte();

            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                SlotId[i] = (MutiSlotStatus[i] & (MutiSlotStatus)0b01111100) > 0 ? r.ReadInt32() : -1;

            HostId = r.ReadInt32();

            PlayMode = (PlayModes)r.ReadByte();

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

        public void WriteToStream(CustomBinaryWriter w)
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
                w.Write((byte)MutiSlotStatus[i]);

            //write each slot's team
            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                w.Write((byte)SlotTeam[i]);

            //write each used slot's player id
            for (int i = 0; i < Constants.MultiplayerMaxPlayers; i++)
                if ((MutiSlotStatus[i] & (MutiSlotStatus)0b1111100) > 0)
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
