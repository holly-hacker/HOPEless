using System.IO;
using HOPEless.Bancho;
using HOPEless.osu;

namespace HOPEless.Extensions
{
    public static class Extensions
    {
        public static void Populate(this IBanchoSerializable s, byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            using (CustomBinaryReader r = new CustomBinaryReader(stream))
                s.ReadFromStream(r);
        }

        public static byte[] Serialize(this IBanchoSerializable s)
        {
            using (MemoryStream stream = new MemoryStream()) {
                using (CustomBinaryWriter w = new CustomBinaryWriter(stream))
                    s.WriteToStream(w);
                return stream.ToArray();
            }
        }
    }
}
