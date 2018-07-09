using System.Collections.Generic;
using HOPEless.Extensions;
using osu.Shared.Serialization;

namespace HOPEless.Bancho.Objects
{
    public class BanchoBeatmapInfoRequest : ISerializable
    {
        //could be done better, I think
        public List<string> Filenames => _filenames.Value;
        public List<int> BeatmapIds => _beatmapIds.Value;

        private readonly BanchoStringList _filenames = new BanchoStringList();
        private readonly BanchoIntList _beatmapIds = new BanchoIntList();

        public BanchoBeatmapInfoRequest() { }
        public BanchoBeatmapInfoRequest(byte[] data) => this.Populate(data);

        public BanchoBeatmapInfoRequest(IEnumerable<string> filenames, IEnumerable<int> beatmapIds)
        {
            _filenames = new BanchoStringList(filenames);
            _beatmapIds = new BanchoIntList(beatmapIds);
        }

        public void ReadFromStream(SerializationReader r)
        {
            _filenames.ReadFromStream(r);
            _beatmapIds.ReadFromStream(r);
        }

        public void WriteToStream(SerializationWriter w)
        {
            _filenames.WriteToStream(w);
            _beatmapIds.WriteToStream(w);
        }
    }

    public class BanchoBeatmapInfoReply : ISerializable
    {
        public List<BanchoBeatmapInfo> Value;

        public BanchoBeatmapInfoReply() { }
        public BanchoBeatmapInfoReply(byte[] data) => this.Populate(data);

        public void ReadFromStream(SerializationReader r) => Value = r.ReadSerializableList<BanchoBeatmapInfo>();
        public void WriteToStream(SerializationWriter w) => w.WriteSerializableList(Value);
    }

    public class BanchoBeatmapInfo : ISerializable
    {
        public short Id;
        public int BeatmapId;
        public int BeatmapSetId;
        public int ThreadId;
        public byte Ranked;
        public byte RankStandard;
        public byte RankTaiko;
        public byte RankCtB;
        public byte RankMania;
        public string Checksum;

        public BanchoBeatmapInfo() { }
        public BanchoBeatmapInfo(byte[] data) => this.Populate(data);

        public void ReadFromStream(SerializationReader sr)
        {
            Id = sr.ReadInt16();
            BeatmapId = sr.ReadInt32();
            BeatmapSetId = sr.ReadInt32();
            ThreadId = sr.ReadInt32();
            Ranked = sr.ReadByte();
            RankStandard = sr.ReadByte();
            RankCtB = sr.ReadByte();
            RankTaiko = sr.ReadByte();
            RankMania = sr.ReadByte();
            Checksum = sr.ReadString();
        }

        public void WriteToStream(SerializationWriter sw)
        {
            sw.Write(Id);
            sw.Write(BeatmapId);
            sw.Write(BeatmapSetId);
            sw.Write(ThreadId);
            sw.Write(Ranked);
            sw.Write(RankStandard);
            sw.Write(RankCtB);
            sw.Write(RankTaiko);
            sw.Write(RankMania);
            sw.Write(Checksum);
        }
    }
}
