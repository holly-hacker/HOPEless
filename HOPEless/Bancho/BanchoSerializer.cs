using System.Collections.Generic;
using System.IO;
using osu.Shared.Serialization;

namespace HOPEless.Bancho
{
    public static class BanchoSerializer
    {
        public static IEnumerable<BanchoPacket> DeserializePackets(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
                return DeserializePackets(stream);
        }

        public static IEnumerable<BanchoPacket> DeserializePackets(Stream stream)
        {
            using (var r = new SerializationReader(stream))
                while (stream.Position != stream.Length)
                    yield return new BanchoPacket(r);
        }

        public static byte[] Serialize(IEnumerable<BanchoPacket> packets)
        {
            return Serialize(packets, new MemoryStream()).ToArray();
        }

        public static T Serialize<T>(IEnumerable<BanchoPacket> packets, T stream) where T : Stream
        {
            using (var w = new SerializationWriter(stream))
                foreach (var packet in packets)
                    packet.WriteToStream(w);

            return stream;
        }
    }
}
