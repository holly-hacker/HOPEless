using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using HOPEless.Bancho;

namespace HOPEless.osu
{
    public class CustomBinaryWriter : BinaryWriter
    {
        public CustomBinaryWriter(Stream output) : base(output) {}
        public CustomBinaryWriter(Stream output, Encoding encoding) : base(output, encoding) {}
        public CustomBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen) {}

        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        public override void Write(string str)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (str == null) {
                Write((byte)0x00);
                return;
            }
            Write((byte)0x0B);
            base.Write(str);
        }

        public override void Write(byte[] b)
        {
            Write(b.Length);
            base.Write(b);
        }

        public void WriteRaw(byte[] b) => base.Write(b);

        public override void Write(char[] c)
        {
            Write(c.Length);
            base.Write(c);
        }

        public void Write(DateTime t)
        {
            Write(t.ToUniversalTime().Ticks);
        }

        public void Write(IBanchoSerializable s)
        {
            s.WriteToStream(this);
        }
    }
}
