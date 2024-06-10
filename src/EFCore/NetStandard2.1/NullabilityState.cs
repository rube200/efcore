// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1
namespace System.Reflection.NST
{
    /// <summary>
    /// An enum that represents nullability state
    /// </summary>
    public enum NullabilityState
    {
        /// <summary>
        /// Nullability context not enabled (oblivious)
        /// </summary>
        Unknown,
        /// <summary>
        /// Non nullable value or reference type
        /// </summary>
        NotNull,
        /// <summary>
        /// Nullable value or reference type
        /// </summary>
        Nullable
    }
}
#endif
