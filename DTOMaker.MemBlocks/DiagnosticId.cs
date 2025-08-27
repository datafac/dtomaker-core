﻿namespace DTOMaker.SrcGen.MemBlocks
{
    public static class Constants
    {
        public const int BlobIdV1Size = 64;
    }
    internal static class DiagnosticId
    {
        public const string DMMB0001 = nameof(DMMB0001); // Invalid block length
        public const string DMMB0002 = nameof(DMMB0002); // Invalid field offset
        public const string DMMB0003 = nameof(DMMB0003); // Invalid field length
        public const string DMMB0004 = nameof(DMMB0004); // Invalid layout method
        public const string DMMB0005 = nameof(DMMB0005); // Missing [Layout] attribute
        public const string DMMB0006 = nameof(DMMB0006); // Missing [Offset] attribute
        public const string DMMB0007 = nameof(DMMB0007); // Unsupported member type
        public const string DMMB0008 = nameof(DMMB0008); // Member layout issue
        public const string DMMB0009 = nameof(DMMB0009); // Invalid length or array capacity
        public const string DMMB0010 = nameof(DMMB0010); // Missing assembly reference
        public const string DMMB0011 = nameof(DMMB0011); // not used
        public const string DMMB0012 = nameof(DMMB0012); // Invalid class height
    }
}