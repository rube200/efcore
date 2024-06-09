// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1
using System.Runtime.CompilerServices;

namespace Microsoft.EntityFrameworkCore.NetStandard2._1
{
    internal static class MissingMath
    {
        public static double BitDecrement(double x)
        {
            long bits = BitConverter.DoubleToInt64Bits(x);

            if (((bits >> 32) & 0x7FF00000) >= 0x7FF00000)
            {
                // NaN returns NaN
                // -Infinity returns -Infinity
                // +Infinity returns double.MaxValue
                return (bits == 0x7FF00000_00000000) ? double.MaxValue : x;
            }

            if (bits == 0x00000000_00000000)
            {
                // +0.0 returns -double.Epsilon
                return -double.Epsilon;
            }

            // Negative values need to be incremented
            // Positive values need to be decremented

            bits += ((bits < 0) ? +1 : -1);
            return BitConverter.Int64BitsToDouble(bits);
        }

        public static double BitIncrement(double x)
        {
            long bits = BitConverter.DoubleToInt64Bits(x);

            if (((bits >> 32) & 0x7FF00000) >= 0x7FF00000)
            {
                // NaN returns NaN
                // -Infinity returns double.MinValue
                // +Infinity returns +Infinity
                return (bits == unchecked((long)(0xFFF00000_00000000))) ? double.MinValue : x;
            }

            if (bits == unchecked((long)(0x80000000_00000000)))
            {
                // -0.0 returns double.Epsilon
                return double.Epsilon;
            }

            // Negative values need to be decremented
            // Positive values need to be incremented

            bits += ((bits < 0) ? -1 : +1);
            return BitConverter.Int64BitsToDouble(bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CopySign(double x, double y)
        {
            const long signMask = 1L << 63;

            // This method is required to work for all inputs,
            // including NaN, so we operate on the raw bits.
            long xbits = BitConverter.DoubleToInt64Bits(x);
            long ybits = BitConverter.DoubleToInt64Bits(y);

            // Remove the sign from x, and remove everything but the sign from y
            xbits &= ~signMask;
            ybits &= signMask;

            // Simply OR them to get the correct sign
            return BitConverter.Int64BitsToDouble(xbits | ybits);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static double FusedMultiplyAdd(double x, double y, double z)
        {
            throw new NotImplementedException("Math.FusedMultiplyAdd is not implemented");
        }

        private const int ILogB_NaN = 0x7FFFFFFF;
        private const int ILogB_Zero = (-1 - 0x7FFFFFFF);

        public static int ILogB(double x)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/ilogb.c

            if (double.IsNaN(x))
            {
                return ILogB_NaN;
            }

            ulong i = BitConverterEx.DoubleToUInt64Bits(x);
            int e = (int)((i >> 52) & 0x7FF);

            if (e == 0)
            {
                i <<= 12;
                if (i == 0)
                {
                    return ILogB_Zero;
                }

                for (e = -0x3FF; (i >> 63) == 0; e--, i <<= 1) ;
                return e;
            }

            if (e == 0x7FF)
            {
                return (i << 12) != 0 ? ILogB_Zero : int.MaxValue;
            }

            return e - 0x3FF;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static double Log2(double x)
        {
            throw new NotImplementedException("Math.Log2 is not implemented");
        }

        public static double MaxMagnitude(double x, double y)
        {
            // This matches the IEEE 754:2019 `maximumMagnitude` function
            //
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a greater magnitude.
            // It treats +0 as greater than -0 as per the specification.

            double ax = Math.Abs(x);
            double ay = Math.Abs(y);

            if ((ax > ay) || double.IsNaN(ax))
            {
                return x;
            }

            if (ax == ay)
            {
                return double.IsNegative(x) ? y : x;
            }

            return y;
        }

        public static double MinMagnitude(double x, double y)
        {
            // This matches the IEEE 754:2019 `minimumMagnitude` function
            //
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a lesser magnitude.
            // It treats +0 as greater than -0 as per the specification.

            double ax = Math.Abs(x);
            double ay = Math.Abs(y);

            if ((ax < ay) || double.IsNaN(ax))
            {
                return x;
            }

            if (ax == ay)
            {
                return double.IsNegative(x) ? x : y;
            }

            return y;
        }

        /// <summary>Returns an estimate of the reciprocal of a specified number.</summary>
        /// <param name="d">The number whose reciprocal is to be estimated.</param>
        /// <returns>An estimate of the reciprocal of <paramref name="d" />.</returns>
        /// <remarks>
        ///    <para>On ARM64 hardware this may use the <c>FRECPE</c> instruction which performs a single Newton-Raphson iteration.</para>
        ///    <para>On hardware without specialized support, this may just return <c>1.0 / d</c>.</para>
        /// </remarks>
        public static double ReciprocalEstimate(double d)
        {
            return 1.0 / d;
        }

        /// <summary>Returns an estimate of the reciprocal square root of a specified number.</summary>
        /// <param name="d">The number whose reciprocal square root is to be estimated.</param>
        /// <returns>An estimate of the reciprocal square root <paramref name="d" />.</returns>
        /// <remarks>
        ///    <para>On ARM64 hardware this may use the <c>FRSQRTE</c> instruction which performs a single Newton-Raphson iteration.</para>
        ///    <para>On hardware without specialized support, this may just return <c>1.0 / Sqrt(d)</c>.</para>
        /// </remarks>
        public static double ReciprocalSqrtEstimate(double d)
        {
            return 1.0 / Math.Sqrt(d);
        }

        private const double SCALEB_C1 = 8.98846567431158E+307; // 0x1p1023

        private const double SCALEB_C2 = 2.2250738585072014E-308; // 0x1p-1022

        private const double SCALEB_C3 = 9007199254740992; // 0x1p53
        public static double ScaleB(double x, int n)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/scalbln.c
            //
            // Performs the calculation x * 2^n efficiently. It constructs a double from 2^n by building
            // the correct biased exponent. If n is greater than the maximum exponent (1023) or less than
            // the minimum exponent (-1022), adjust x and n to compute correct result.

            double y = x;
            if (n > 1023)
            {
                y *= SCALEB_C1;
                n -= 1023;
                if (n > 1023)
                {
                    y *= SCALEB_C1;
                    n -= 1023;
                    if (n > 1023)
                    {
                        n = 1023;
                    }
                }
            }
            else if (n < -1022)
            {
                y *= SCALEB_C2 * SCALEB_C3;
                n += 1022 - 53;
                if (n < -1022)
                {
                    y *= SCALEB_C2 * SCALEB_C3;
                    n += 1022 - 53;
                    if (n < -1022)
                    {
                        n = -1022;
                    }
                }
            }

            double u = BitConverter.Int64BitsToDouble(((long)(0x3ff + n) << 52));
            return y * u;
        }
    }
}
#endif
