using System.Collections.Generic;
using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoBeatmapInfoRequest : IBanchoSerializable
    {
        //could be done better, I think
        public List<string> Filenames => _filenames.Value;
        public List<int> BeatmapIds => _beatmapIds.Value;

        private readonly BanchoStringList _filenames = new BanchoStringList();
        private readonly BanchoIntList _beatmapIds = new BanchoIntList();
        
        public void ReadFromStream(CustomBinaryReader r)
        {
            _filenames.ReadFromStream(r);
            _beatmapIds.ReadFromStream(r);
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            _filenames.WriteToStream(w);
            _beatmapIds.WriteToStream(w);
        }
    }
}
