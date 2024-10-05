﻿using System;
using System.Buffers.Binary;

namespace DTOMaker.Runtime
{
#if NET8_0_OR_GREATER
    public sealed class Codec_Int128_LE : ISpanCodec<Int128>
    {
        public static Int128 ReadFromSpan(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt128LittleEndian(source);
        public static void WriteToSpan(Span<byte> target, in Int128 input) => BinaryPrimitives.WriteInt128LittleEndian(target, input);
    }
#endif
}
