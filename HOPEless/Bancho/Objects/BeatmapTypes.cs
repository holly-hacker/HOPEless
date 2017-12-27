﻿using System.Collections.Generic;
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
}
