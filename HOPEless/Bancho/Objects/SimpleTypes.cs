using System.Collections.Generic;
using HOPEless.Extensions;
using HOPEless.osu;

namespace HOPEless.Bancho.Objects
{
    public class BanchoInt : IBanchoSerializable
    {
        public int Value;
        public BanchoInt() { }
        public BanchoInt(byte[] data) => this.Populate(data);
        public void ReadFromStream(CustomBinaryReader r) => Value = r.ReadInt32();
        public void WriteToStream(CustomBinaryWriter w) => w.Write(Value);
    }

    public class BanchoIntList : IBanchoSerializable
    {
        public List<int> Value = new List<int>();

        public BanchoIntList() { }
        public BanchoIntList(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            Value = new List<int>();

            int length = r.ReadInt16();
            for (int i = 0; i < length; i++) Value.Add(r.ReadInt32());
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(Value.Count);
            foreach (int i in Value) w.Write(i);
        }
    }

    public class BanchoString : IBanchoSerializable
    {
        public string Value;
        public BanchoString() { }
        public BanchoString(byte[] data) => this.Populate(data);
        public void ReadFromStream(CustomBinaryReader r) => Value = r.ReadString();
        public void WriteToStream(CustomBinaryWriter w) => w.Write(Value);
    }

    public class BanchoStringList : IBanchoSerializable
    {
        public List<string> Value = new List<string>();

        public BanchoStringList() { }
        public BanchoStringList(byte[] data) => this.Populate(data);

        public void ReadFromStream(CustomBinaryReader r)
        {
            Value = new List<string>();

            int length = r.ReadInt16();
            for (int i = 0; i < length; i++) Value.Add(r.ReadString());
        }

        public void WriteToStream(CustomBinaryWriter w)
        {
            w.Write(Value.Count);
            foreach (string s in Value) w.Write(s);
        }
    }
}
