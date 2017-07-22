using System.Collections.Generic;
using System.IO;
using HOPEless.osu;

namespace HOPEless.Bancho
{
    public static class BanchoSerializer
    {
        public static IEnumerable<BanchoPacket> DeserializePackets(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            using (var r = new CustomBinaryReader(stream))
                while (stream.Position != stream.Length)
                    yield return new BanchoPacket(r);
        }

        public static byte[] Serialize(IEnumerable<BanchoPacket> packets)
        {
            using (MemoryStream stream = new MemoryStream()) {
                using (var w = new CustomBinaryWriter(stream))
                    foreach (var packet in packets)
                        packet.WriteToStream(w);

                return stream.ToArray();
            }
        }
    }
}
