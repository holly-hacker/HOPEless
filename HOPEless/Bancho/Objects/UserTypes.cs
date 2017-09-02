using HOPEless.Extensions;
using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoUserData : IBanchoSerializable
    {
        public int UserId;
        public BanchoUserStatus Status = new BanchoUserStatus();
        public long RankedScore;
        public float Accuracy;
        public int Playcount;
        public long TotalScore;
        public int Rank;
        public short Performance;

        public BanchoUserData() { }
        public BanchoUserData(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            UserId = r.ReadInt32();
            Status.ReadFromStream(r);
            RankedScore = r.ReadInt64();
            Accuracy = r.ReadSingle();
            Playcount = r.ReadInt32();
            TotalScore = r.ReadInt64();
            Rank = r.ReadInt32();
            Performance = r.ReadInt16();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(UserId);
            Status.WriteToStream(w);
            w.Write(RankedScore);
            w.Write(Accuracy);
            w.Write(Playcount);
            w.Write(TotalScore);
            w.Write(Rank);
            w.Write(Performance);
        }
    }

    public class BanchoUserStatus : IBanchoSerializable
    {
        public BanchoAction Action;
        public string ActionText;
        public string BeatmapChecksum;
        public Mods CurrentMods;
        public PlayModes PlayMode;
        public int BeatmapId;
        
        public BanchoUserStatus() { }
        public BanchoUserStatus(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            Action = (BanchoAction)r.ReadByte();
            ActionText = r.ReadString();
            BeatmapChecksum = r.ReadString();
            CurrentMods = (Mods)r.ReadUInt32();
            PlayMode = (PlayModes)r.ReadByte();
            BeatmapId = r.ReadInt32();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write((byte)Action);
            w.Write(ActionText);
            w.Write(BeatmapChecksum);
            w.Write((uint)CurrentMods);
            w.Write((byte)PlayMode);
            w.Write(BeatmapId);
        }
    }

    public class BanchoUserPresence : IBanchoSerializable
    {
        public int UserId;
        public bool UsesOsuClient;
        public string Username;
        public int Timezone;
        public byte CountryCode;
        public UserPermissions Permissions;
        public PlayModes PlayMode;
        public float Longitude;
        public float Latitude;
        public int Rank;

        public BanchoUserPresence() { }
        public BanchoUserPresence(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            UserId = r.ReadInt32();
            if (UserId < 0) UserId = -UserId;
            else UsesOsuClient = UserId != 0;

            Username = r.ReadString();
            Timezone = r.ReadByte() - 24;
            CountryCode = r.ReadByte();

            byte permissionPlaymodeBitfield = r.ReadByte();
            Permissions = (UserPermissions)(permissionPlaymodeBitfield & 0b00011111);
            PlayMode = (PlayModes)((permissionPlaymodeBitfield & 0b11100000) >> 5);

            Longitude = r.ReadSingle();
            Latitude = r.ReadSingle();
            Rank = r.ReadInt32();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(UsesOsuClient ? UserId : -UserId);
            w.Write(Username);
            w.Write((byte)(Timezone + 24));
            w.Write(CountryCode);
            w.Write((byte)(((byte)Permissions & 0b00011111) | (((byte)PlayMode & 0b00000111) << 5)));   //bitwise and isn't needed, but it looks cool and is consistent with the reading
            w.Write(Longitude);
            w.Write(Latitude);
            w.Write(Rank);
        }
    }

    public class BanchoUserQuit : IBanchoSerializable
    {
        public int UserId;
        public UserQuitType QuitType;


        public BanchoUserQuit() { }
        public BanchoUserQuit(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            UserId = r.ReadInt32();
            QuitType = (UserQuitType)r.ReadByte();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(UserId);
            w.Write((byte)QuitType);
        }
    }
}
