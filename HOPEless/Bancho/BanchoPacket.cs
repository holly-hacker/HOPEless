using System.IO;
using HOPEless.osu;

namespace HOPEless.Bancho
{
    public class BanchoPacket : IBanchoSerializable
    {
        public PacketType Type;
        public byte[] Data;

        public BanchoPacket(CustomBinaryReader r)
        {
            ReadFromStream(r);
        }

        public BanchoPacket(PacketType t, IBanchoSerializable s)
        {
            Type = t;
            using (MemoryStream stream = new MemoryStream()) {
                using (CustomBinaryWriter writer = new CustomBinaryWriter(stream))
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

        public void ReadFromStream(CustomBinaryReader r)
        {
            Type = (PacketType)r.ReadInt16();
            r.ReadByte();
            int length = r.ReadInt32();
            Data = r.ReadBytes(length);
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write((short)Type);
            w.Write((byte)0);
            w.Write(Data.Length);
            w.WriteRaw(Data);
        }
    }
}
