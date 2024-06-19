// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json;
#if NETSTANDARD2_1
using Microsoft.EntityFrameworkCore.NetStandard2._1;
#endif
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Microsoft.EntityFrameworkCore.Sqlite.Storage.Json.Internal;

/// <summary>
///     The Sqlite-specific JsonValueReaderWrite for byte[]. Generates the SQLite representation (e.g. X'0102') rather than base64, in order
///     to match our SQLite non-JSON representation.
/// </summary>
/// <remarks>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </remarks>
public sealed class SqliteJsonByteArrayReaderWriter : JsonValueReaderWriter<byte[]>
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static SqliteJsonByteArrayReaderWriter Instance { get; } = new();

    private SqliteJsonByteArrayReaderWriter()
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override byte[] FromJsonTyped(ref Utf8JsonReaderManager manager, object? existingObject = null)
#if NETSTANDARD2_1
        => ConvertEx.FromHexString(manager.CurrentReader.GetString()!);
#else
        => Convert.FromHexString(manager.CurrentReader.GetString()!);
#endif

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override void ToJsonTyped(Utf8JsonWriter writer, byte[] value)
#if NETSTANDARD2_1
        => writer.WriteStringValue(ConvertEx.ToHexString(value));
#else
        => writer.WriteStringValue(Convert.ToHexString(value));
#endif
}
