using HOPEless.Extensions;
using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoChatMessage : IBanchoSerializable
    {
        public string Sender, Message, Channel;
        public int SenderId;

        public BanchoChatMessage() { }
        public BanchoChatMessage(byte[] data) => this.Populate(data);

        public BanchoChatMessage(string sender, string message, string channel, int senderId)
        {
            Sender = sender;
            Message = message;
            Channel = channel;
            SenderId = senderId;
        }

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

        public BanchoChatChannel() { }
        public BanchoChatChannel(byte[] data) => this.Populate(data);

        public BanchoChatChannel(string name, string topic, short userCount)
        {
            Name = name;
            Topic = topic;
            UserCount = userCount;
        }

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
