namespace DTOMaker.Gentime.Tests
{
    public enum TokenKind : byte
    {
        None,
        Whitespace,
        String,
        Number,
        Identifier,
        LeftCurly,
        RightCurly,
        Comma,
        Equals,
        LeftSquare,
        RightSquare,
        // todo more special chars
        Error,
    }
}