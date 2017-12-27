using System.Collections.Generic;
using System.Linq;
using HOPEless.Extensions;
using osu.Shared.Serialization;

namespace HOPEless.Bancho.Objects
{
    public class BanchoInt : ISerializable
    {
        public int Value;
        public BanchoInt() { }
        public BanchoInt(byte[] data) => this.Populate(data);
        public BanchoInt(int val) => Value = val;
        public void ReadFromStream(SerializationReader r) => Value = r.ReadInt32();
        public void WriteToStream(SerializationWriter w) => w.Write(Value);
    }

    public class BanchoIntList : ISerializable
    {
        public List<int> Value = new List<int>();

        public BanchoIntList() { }
        public BanchoIntList(byte[] data) => this.Populate(data);
        public BanchoIntList(IEnumerable<int> val) => Value = val.ToList();

        public void ReadFromStream(SerializationReader r)
        {
            Value = new List<int>();

            int length = r.ReadInt16();
            for (int i = 0; i < length; i++) Value.Add(r.ReadInt32());
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write(Value.Count);
            foreach (int i in Value) w.Write(i);
        }
    }

    public class BanchoString : ISerializable
    {
        public string Value;
        public BanchoString() { }
        public BanchoString(byte[] data) => this.Populate(data);
        public BanchoString(string val) => Value = val;
        public void ReadFromStream(SerializationReader r) => Value = r.ReadString();
        public void WriteToStream(SerializationWriter w) => w.Write(Value);
    }

    public class BanchoStringList : ISerializable
    {
        public List<string> Value = new List<string>();

        public BanchoStringList() { }
        public BanchoStringList(byte[] data) => this.Populate(data);
        public BanchoStringList(IEnumerable<string> val) => Value = val.ToList();

        public void ReadFromStream(SerializationReader r)
        {
            Value = new List<string>();

            int length = r.ReadInt16();
            for (int i = 0; i < length; i++) Value.Add(r.ReadString());
        }

        public void WriteToStream(SerializationWriter w)
        {
            w.Write(Value.Count);
            foreach (string s in Value) w.Write(s);
        }
    }
}
