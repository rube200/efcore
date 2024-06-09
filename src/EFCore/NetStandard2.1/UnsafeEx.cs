// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1
using System.Runtime.CompilerServices;

namespace Microsoft.EntityFrameworkCore.NetStandard2._1
{
    internal static class UnsafeEx
    {
        /// <summary>
        /// Reinterprets the given value of type <typeparamref name="TFrom" /> as a value of type <typeparamref name="TTo" />.
        /// </summary>
        /// <exception cref="NotSupportedException">The sizes of <typeparamref name="TFrom" /> and <typeparamref name="TTo" /> are not the same
        /// or the type parameters are not <see langword="struct"/>s.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TTo BitCast<TFrom, TTo>(TFrom source)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            if (sizeof(TFrom) != sizeof(TTo))
            {
                throw new NotSupportedException();
            }
            return Unsafe.ReadUnaligned<TTo>(ref Unsafe.As<TFrom, byte>(ref source));
        }
    }
}
#endif
