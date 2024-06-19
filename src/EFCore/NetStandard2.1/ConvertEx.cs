// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1

namespace Microsoft.EntityFrameworkCore.NetStandard2._1
{
#pragma warning disable CS1591 // Missing XML comment
    public static class ConvertEx
    {
        /// <summary>
        /// Converts the specified string, which encodes binary data as hex characters, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is null.</exception>
        /// <exception cref="FormatException">The length of <paramref name="s"/>, is not zero or a multiple of 2.</exception>
        /// <exception cref="FormatException">The format of <paramref name="s"/> is invalid. <paramref name="s"/> contains a non-hex character.</exception>
        public static byte[] FromHexString(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            return FromHexString(s.AsSpan());
        }

        /// <summary>
        /// Converts the span, which encodes binary data as hex characters, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="chars">The span to convert.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="chars"/>.</returns>
        /// <exception cref="FormatException">The length of <paramref name="chars"/>, is not zero or a multiple of 2.</exception>
        /// <exception cref="FormatException">The format of <paramref name="chars"/> is invalid. <paramref name="chars"/> contains a non-hex character.</exception>
        public static byte[] FromHexString(ReadOnlySpan<char> chars)
        {
            if (chars.Length == 0)
                return Array.Empty<byte>();
            if ((uint)chars.Length % 2 != 0)
                throw new FormatException("The input is not a valid hex string as its length is not a multiple of 2.");

            var result = new byte[chars.Length >> 1];

            if (!HexConverterEx.TryDecodeFromUtf16(chars, result))
                throw new FormatException("The input is not a valid hex string as it contains a non-hex character.");

            return result;
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with uppercase hex characters.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation in hex of the elements in <paramref name="inArray"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inArray"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="inArray"/> is too large to be encoded.</exception>
        public static string ToHexString(byte[] inArray)
        {
            if (inArray == null)
                throw new ArgumentNullException(nameof(inArray));

            return ToHexString(new ReadOnlySpan<byte>(inArray));
        }

        /// <summary>
        /// Converts a span of 8-bit unsigned integers to its equivalent string representation that is encoded with uppercase hex characters.
        /// </summary>
        /// <param name="bytes">A span of 8-bit unsigned integers.</param>
        /// <returns>The string representation in hex of the elements in <paramref name="bytes"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bytes"/> is too large to be encoded.</exception>
        public static string ToHexString(ReadOnlySpan<byte> bytes)
        {
            if (bytes.Length == 0)
                return string.Empty;

            if (bytes.Length > int.MaxValue / 2)
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length, string.Format("'{0}' must be less than or equal to '{1}'.", nameof(bytes), bytes.Length, int.MaxValue / 2));

            return HexConverterEx.ToString(bytes, HexConverterEx.Casing.Upper);
        }
    }
#pragma warning restore CS1591 // Missing XML comment
}
#endif
