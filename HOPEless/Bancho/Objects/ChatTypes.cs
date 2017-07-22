using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoChatMessage : IBanchoSerializable
    {
        public string Sender, Message, Channel;
        public int SenderId;

        public void ReadFromStream(CustomBinaryReader r)
        {
            Sender = r.ReadString();
            Message = r.ReadString();
            Channel = r.ReadString();
            SenderId = r.ReadInt32();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(Sender);
            w.Write(Message);
            w.Write(Channel);
            w.Write(SenderId);
        }
    }

    public class BanchoChatChannel : IBanchoSerializable
    {
        public string Name, Topic;
        public short UserCount;

        public void ReadFromStream(CustomBinaryReader r)
        {
            Name = r.ReadString();
            Topic = r.ReadString();
            UserCount = r.ReadInt16();
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(Name);
            w.Write(Topic);
            w.Write(UserCount);
        }
    }
}
