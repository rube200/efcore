// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1
namespace Microsoft.EntityFrameworkCore.NetStandard2._1
{
    internal static class BitConverterEx
    {
        /// <summary>
        /// Converts the specified single-precision floating point number to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 32-bit signed integer whose bits are identical to <paramref name="value"/>.</returns>
        public static unsafe int SingleToInt32Bits(float value) => UnsafeEx.BitCast<float, int>(value);

        /// <summary>
        /// Converts the specified single-precision floating point number to a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 32-bit unsigned integer whose bits are identical to <paramref name="value"/>.</returns>
        public static unsafe uint SingleToUInt32Bits(float value) => UnsafeEx.BitCast<float, uint>(value);

        /// <summary>
        /// Converts the specified double-precision floating point number to a 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 64-bit unsigned integer whose bits are identical to <paramref name="value"/>.</returns>
        public static unsafe ulong DoubleToUInt64Bits(double value) => UnsafeEx.BitCast<double, ulong>(value);
    }
}
#endif
