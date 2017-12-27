using System.IO;
using osu.Shared.Serialization;

namespace HOPEless.Extensions
{
    public static class Extensions
    {
        public static void Populate(this ISerializable s, byte[] data)
        {
            using (var stream = new MemoryStream(data))
            using (var r = new SerializationReader(stream))
                s.ReadFromStream(r);
        }

        public static byte[] Serialize(this ISerializable s)
        {
            using (var stream = new MemoryStream()) {
                using (var w = new SerializationWriter(stream))
                    s.WriteToStream(w);
                return stream.ToArray();
            }
        }
    }
}
