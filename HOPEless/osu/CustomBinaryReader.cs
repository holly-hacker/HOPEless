using System;
using System.IO;
using System.Text;

namespace HOPEless.osu
{
    public class CustomBinaryReader : BinaryReader
    {
        public CustomBinaryReader(Stream input) : base(input) {}
        public CustomBinaryReader(Stream input, Encoding encoding) : base(input, encoding) {}
        public CustomBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen) {}
        
        public override string ReadString()
        {
            if (ReadByte() == 0) return null;   //string cannot be null, so this is weird
            return base.ReadString();
        }

        public byte[] ReadByteArray()
        {
            int count = ReadInt32();
            if (count > 0) return ReadBytes(count);
            if (count < 0) return null;
            return new byte[0];
        }

        public char[] ReadCharArray()
        {
            int count = ReadInt32();
            if (count > 0) return ReadChars(count);
            if (count < 0) return null;
            return new char[0];
        }

        public DateTime ReadDateTime() => new DateTime(ReadInt64(), DateTimeKind.Utc);
    }
}
