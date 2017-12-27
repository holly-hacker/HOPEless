using HOPEless.Extensions;
using HOPEless.osu;
using osu.Shared;
using osu.Shared.Serialization;

namespace HOPEless.Bancho.Objects
{
    public class BanchoUserData : ISerializable
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

        public void ReadFromStream(SerializationReader r)
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

        public void WriteToStream(SerializationWriter w)
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

    public class BanchoUserStatus : ISerializable
    {
        public BanchoAction Action;
        public string ActionText;
        public string BeatmapChecksum;
        public Mods CurrentMods;
        public GameMode PlayMode;
        public int BeatmapId;
        
        public BanchoUserStatus() { }
        public BanchoUserStatus(byte[] data) => this.Populate(data);

        public void ReadFromStream(SerializationReader r)
        {
            Action = (BanchoAction)r.ReadByte();
            ActionText = r.ReadString();
            BeatmapChecksum = r.ReadString();
            CurrentMods = (Mods)r.ReadUInt32();
            PlayMode = (GameMode)r.ReadByte();
            BeatmapId = r.ReadInt32();
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write((byte)Action);
            w.Write(ActionText);
            w.Write(BeatmapChecksum);
            w.Write((uint)CurrentMods);
            w.Write((byte)PlayMode);
            w.Write(BeatmapId);
        }
    }

    public class BanchoUserPresence : ISerializable
    {
        public int UserId;
        public bool UsesOsuClient;
        public string Username;
        public int Timezone;
        public byte CountryCode;
        public PlayerRank Permissions;
        public GameMode PlayMode;
        public float Longitude;
        public float Latitude;
        public int Rank;

        public BanchoUserPresence() { }
        public BanchoUserPresence(byte[] data) => this.Populate(data);

        public void ReadFromStream(SerializationReader r)
        {
            UserId = r.ReadInt32();
            if (UserId < 0) UserId = -UserId;
            else UsesOsuClient = UserId != 0;

            Username = r.ReadString();
            Timezone = r.ReadByte() - 24;
            CountryCode = r.ReadByte();

            byte permissionPlaymodeBitfield = r.ReadByte();
            Permissions = (PlayerRank)(permissionPlaymodeBitfield & 0b00011111);
            PlayMode = (GameMode)((permissionPlaymodeBitfield & 0b11100000) >> 5);

            Longitude = r.ReadSingle();
            Latitude = r.ReadSingle();
            Rank = r.ReadInt32();
        }

        public void WriteToStream(SerializationWriter w)
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

    public class BanchoUserQuit : ISerializable
    {
        public int UserId;
        public UserQuitType QuitType;


        public BanchoUserQuit() { }
        public BanchoUserQuit(byte[] data) => this.Populate(data);

        public BanchoUserQuit(int userId, UserQuitType quitType = UserQuitType.FullDisconnect)
        {
            UserId = userId;
            QuitType = quitType;
        }

        public void ReadFromStream(SerializationReader r)
        {
            UserId = r.ReadInt32();
            QuitType = (UserQuitType)r.ReadByte();
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write(UserId);
            w.Write((byte)QuitType);
        }
    }
}
