﻿using System;
using System.Threading.Tasks;

namespace DataFac.Storage.RocksDbStore;

internal readonly struct AsyncOp
{
    public readonly AsyncOpKind Kind;
    public readonly BlobIdV1 Id;
    public readonly ReadOnlyMemory<byte> Data;
    public readonly TaskCompletionSource<ReadOnlyMemory<byte>?>? Completion;

    public AsyncOp(AsyncOpKind kind, BlobIdV1 id, ReadOnlyMemory<byte> data, TaskCompletionSource<ReadOnlyMemory<byte>?>? completion)
    {
        Kind = kind;
        Id = id;
        Data = data;
        Completion = completion;
    }

    /// <summary>
    /// Async SYNC
    /// </summary>
    /// <param name="completion"></param>
    public AsyncOp(TaskCompletionSource<ReadOnlyMemory<byte>?> completion)
    {
        Kind = AsyncOpKind.Sync;
        Completion = completion;
    }

    /// <summary>
    /// Async GET
    /// </summary>
    /// <param name="id"></param>
    /// <param name="completion"></param>
    public AsyncOp(BlobIdV1 id, TaskCompletionSource<ReadOnlyMemory<byte>?> completion)
    {
        Kind = AsyncOpKind.Get;
        Id = id;
        Completion = completion;
    }

    /// <summary>
    /// Async PUT
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    public AsyncOp(BlobIdV1 id, ReadOnlyMemory<byte> data, TaskCompletionSource<ReadOnlyMemory<byte>?>? completion)
    {
        Kind = AsyncOpKind.Put;
        Id = id;
        Data = data;
        Completion = completion;
    }
}
