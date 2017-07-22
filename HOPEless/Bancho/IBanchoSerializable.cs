using HOPEless.osu;

namespace HOPEless.Bancho
{
    public interface IBanchoSerializable
    {
        void ReadFromStream(CustomBinaryReader r);
        void WriteToStream(CustomBinaryWriter w);
    }
}
