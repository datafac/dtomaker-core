﻿using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace DataFac.Storage.Tests;

public class BlobHashTests
{
    [Fact]
    public void BlobHash01Empty()
    {
        ReadOnlyMemory<byte> orig = default;
        BlobIdV1 id = orig.Span.GetBlobId();
        id.IsEmbedded.ShouldBeTrue();
        id.ToString().ShouldBe("U:0:");
    }

    [Fact]
    public void BlobHash02NonEmpty()
    {
        ReadOnlyMemory<byte> orig = new ReadOnlyMemory<byte>(Enumerable.Range(0, 256).Select(i => (byte)i).ToArray());
        BlobIdV1 id = orig.Span.GetBlobId();
        id.IsEmbedded.ShouldBeFalse();
        id.ToString().ShouldBe("V1.0:256:0:0:1:QK/y6dLYki5Hr9RkjmlnSXFYeF+9Hahw5xECZr+USIA=");
    }
}
