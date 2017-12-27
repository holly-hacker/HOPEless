using System.IO;
using osu.Shared.Serialization;

namespace HOPEless.Bancho
{
    public class BanchoPacket : ISerializable
    {
        public PacketType Type;
        public byte[] Data;

        public BanchoPacket(SerializationReader r)
        {
            ReadFromStream(r);
        }

        public BanchoPacket(PacketType t, ISerializable s)
        {
            Type = t;
            using (var stream = new MemoryStream()) {
                using (var writer = new SerializationWriter(stream))
                    writer.Write(s);
                Data = stream.ToArray();
            }
        }

        public BanchoPacket(PacketType t, byte[] data)
        {
            Type = t;
            Data = data;
        }

        public override string ToString() => $"Type: {Type}, Data length: {Data?.Length ?? 0}";

        public void ReadFromStream(SerializationReader r)
        {
            Type = (PacketType)r.ReadInt16();
            r.ReadByte();
            int length = r.ReadInt32();
            Data = r.ReadBytes(length);
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write((short)Type);
            w.Write((byte)0);
            w.Write(Data.Length);
            w.Write(Data);
        }
    }
}
