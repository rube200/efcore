// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1
using System.Runtime.CompilerServices;

namespace Microsoft.EntityFrameworkCore.NetStandard2._1
{
    internal static class MissingMathF
    {
        public static float BitDecrement(float x)
        {
            int bits = BitConverter.SingleToInt32Bits(x);

            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns -Infinity
                // +Infinity returns float.MaxValue
                return (bits == 0x7F800000) ? float.MaxValue : x;
            }

            if (bits == 0x00000000)
            {
                // +0.0 returns -float.Epsilon
                return -float.Epsilon;
            }

            // Negative values need to be incremented
            // Positive values need to be decremented

            bits += ((bits < 0) ? +1 : -1);
            return BitConverter.Int32BitsToSingle(bits);
        }

        public static float BitIncrement(float x)
        {
            int bits = BitConverter.SingleToInt32Bits(x);

            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns float.MinValue
                // +Infinity returns +Infinity
                return (bits == unchecked((int)(0xFF800000))) ? float.MinValue : x;
            }

            if (bits == unchecked((int)(0x80000000)))
            {
                // -0.0 returns float.Epsilon
                return float.Epsilon;
            }

            // Negative values need to be decremented
            // Positive values need to be incremented

            bits += ((bits < 0) ? -1 : +1);
            return BitConverter.Int32BitsToSingle(bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CopySign(float x, float y)
        {
            const int signMask = 1 << 31;

            // This method is required to work for all inputs,
            // including NaN, so we operate on the raw bits.
            int xbits = BitConverter.SingleToInt32Bits(x);
            int ybits = BitConverter.SingleToInt32Bits(y);

            // Remove the sign from x, and remove everything but the sign from y
            xbits &= ~signMask;
            ybits &= signMask;

            // Simply OR them to get the correct sign
            return BitConverter.Int32BitsToSingle(xbits | ybits);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static float FusedMultiplyAdd(float x, float y, float z)
        {
            throw new NotImplementedException("MathF.FusedMultiplyAdd is not implemented");
        }

        private const int ILogB_NaN = 0x7fffffff;

        private const int ILogB_Zero = (-1 - 0x7fffffff);

        public static int ILogB(float x)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/ilogbf.c

            if (float.IsNaN(x))
            {
                return ILogB_NaN;
            }

            uint i = BitConverterEx.SingleToUInt32Bits(x);
            int e = (int)((i >> 23) & 0xFF);

            if (e == 0)
            {
                i <<= 9;
                if (i == 0)
                {
                    return ILogB_Zero;
                }

                for (e = -0x7F; (i >> 31) == 0; e--, i <<= 1) ;
                return e;
            }

            if (e == 0xFF)
            {
                return i << 9 != 0 ? ILogB_Zero : int.MaxValue;
            }

            return e - 0x7F;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static float Log2(float x)
        {
            throw new NotImplementedException("MathF.Log2 is not implemented");
        }

        public static float MaxMagnitude(float x, float y)
        {
            // This matches the IEEE 754:2019 `maximumMagnitude` function
            //
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a greater magnitude.
            // It treats +0 as greater than -0 as per the specification.

            float ax = MathF.Abs(x);
            float ay = MathF.Abs(y);

            if ((ax > ay) || float.IsNaN(ax))
            {
                return x;
            }

            if (ax == ay)
            {
                return float.IsNegative(x) ? y : x;
            }

            return y;
        }

        public static float MinMagnitude(float x, float y)
        {
            // This matches the IEEE 754:2019 `minimumMagnitude` function
            //
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a lesser magnitude.
            // It treats +0 as greater than -0 as per the specification.

            float ax = MathF.Abs(x);
            float ay = MathF.Abs(y);

            if ((ax < ay) || float.IsNaN(ax))
            {
                return x;
            }

            if (ax == ay)
            {
                return float.IsNegative(x) ? x : y;
            }

            return y;
        }

        /// <summary>Returns an estimate of the reciprocal of a specified number.</summary>
        /// <param name="x">The number whose reciprocal is to be estimated.</param>
        /// <returns>An estimate of the reciprocal of <paramref name="x" />.</returns>
        /// <remarks>
        ///    <para>On x86/x64 hardware this may use the <c>RCPSS</c> instruction which has a maximum relative error of <c>1.5 * 2^-12</c>.</para>
        ///    <para>On ARM64 hardware this may use the <c>FRECPE</c> instruction which performs a single Newton-Raphson iteration.</para>
        ///    <para>On hardware without specialized support, this may just return <c>1.0 / x</c>.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReciprocalEstimate(float x)
        {
            return 1.0f / x;
        }

        /// <summary>Returns an estimate of the reciprocal square root of a specified number.</summary>
        /// <param name="x">The number whose reciprocal square root is to be estimated.</param>
        /// <returns>An estimate of the reciprocal square root <paramref name="x" />.</returns>
        /// <remarks>
        ///    <para>On x86/x64 hardware this may use the <c>RSQRTSS</c> instruction which has a maximum relative error of <c>1.5 * 2^-12</c>.</para>
        ///    <para>On ARM64 hardware this may use the <c>FRSQRTE</c> instruction which performs a single Newton-Raphson iteration.</para>
        ///    <para>On hardware without specialized support, this may just return <c>1.0 / Sqrt(x)</c>.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReciprocalSqrtEstimate(float x)
        {
            return 1.0f / MathF.Sqrt(x);
        }

        private const float SCALEB_C1 = 1.7014118E+38f; // 0x1p127f

        private const float SCALEB_C2 = 1.1754944E-38f; // 0x1p-126f

        private const float SCALEB_C3 = 16777216f; // 0x1p24f

        public static float ScaleB(float x, int n)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/scalblnf.c
            //
            // Performs the calculation x * 2^n efficiently. It constructs a float from 2^n by building
            // the correct biased exponent. If n is greater than the maximum exponent (127) or less than
            // the minimum exponent (-126), adjust x and n to compute correct result.

            float y = x;
            if (n > 127)
            {
                y *= SCALEB_C1;
                n -= 127;
                if (n > 127)
                {
                    y *= SCALEB_C1;
                    n -= 127;
                    if (n > 127)
                    {
                        n = 127;
                    }
                }
            }
            else if (n < -126)
            {
                y *= SCALEB_C2 * SCALEB_C3;
                n += 126 - 24;
                if (n < -126)
                {
                    y *= SCALEB_C2 * SCALEB_C3;
                    n += 126 - 24;
                    if (n < -126)
                    {
                        n = -126;
                    }
                }
            }

            float u = BitConverter.Int32BitsToSingle(((int)(0x7f + n) << 23));
            return y * u;
        }
    }
}
#endif
