// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Reflection;
#if NETSTANDARD2_1
using Microsoft.EntityFrameworkCore.NetStandard2._1;
#endif
namespace Microsoft.EntityFrameworkCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class CallForwardingExpressionVisitor : ExpressionVisitor
{
    private static readonly IReadOnlyDictionary<MethodInfo, MethodInfo> _forwardedMethods = new Dictionary<MethodInfo, MethodInfo>
    {
        {
            typeof(byte).GetRuntimeMethod("Clamp", new[] { typeof(byte), typeof(byte), typeof(byte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(byte), typeof(byte), typeof(byte) })!
        },
        {
            typeof(byte).GetRuntimeMethod("Max", new[] { typeof(byte), typeof(byte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(byte), typeof(byte) })!
        },
        {
            typeof(byte).GetRuntimeMethod("Min", new[] { typeof(byte), typeof(byte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(byte), typeof(byte) })!
        },
        {
            typeof(decimal).GetRuntimeMethod("Abs", new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Ceiling), new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod("Clamp", new[] { typeof(decimal), typeof(decimal), typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(decimal), typeof(decimal), typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Floor), new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Floor), new[] { typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod("Max", new[] { typeof(decimal), typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(decimal), typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod("Min", new[] { typeof(decimal), typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(decimal), typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Round), new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Round), new[] { typeof(decimal), typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal), typeof(int) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Round), new[] { typeof(decimal), typeof(int), typeof(MidpointRounding) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal), typeof(int), typeof(MidpointRounding) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Round), new[] { typeof(decimal), typeof(MidpointRounding) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal), typeof(MidpointRounding) })!
        },
        {
            typeof(decimal).GetRuntimeMethod("Sign", new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(decimal) })!
        },
        {
            typeof(decimal).GetRuntimeMethod(nameof(decimal.Truncate), new[] { typeof(decimal) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), new[] { typeof(decimal) })!
        },
        {
            typeof(double).GetRuntimeMethod("Abs", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Acos", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Acos), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Acosh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Acosh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Asin", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Asin), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Asinh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Asinh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Atan", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Atan), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Atan2", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Atan2), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Atanh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Atanh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("BitDecrement", new[] { typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.BitDecrement), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.BitDecrement), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("BitIncrement", new[] { typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.BitIncrement), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.BitIncrement), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Cbrt", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Cbrt), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Ceiling", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Clamp", new[] { typeof(double), typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(double), typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("CopySign", new[] { typeof(double), typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.CopySign), new[] { typeof(double), typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.CopySign), new[] { typeof(double), typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Cos", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Cos), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Cosh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Cosh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Exp", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Exp), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Floor", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Floor), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("FusedMultiplyAdd", new[] { typeof(double), typeof(double), typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.FusedMultiplyAdd), new[] { typeof(double), typeof(double), typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.FusedMultiplyAdd), new[] { typeof(double), typeof(double), typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Ieee754Remainder", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.IEEERemainder), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("ILogB", new[] { typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.ILogB), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.ILogB), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Log", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Log), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Log", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Log), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Log10", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Log10), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Log2", new[] { typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.Log2), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.Log2), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Max", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("MaxMagnitude", new[] { typeof(double), typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.MaxMagnitude), new[] { typeof(double), typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.MaxMagnitude), new[] { typeof(double), typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Min", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("MinMagnitude", new[] { typeof(double), typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.MinMagnitude), new[] { typeof(double), typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.MinMagnitude), new[] { typeof(double), typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Pow", new[] { typeof(double), typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Pow), new[] { typeof(double), typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("ReciprocalEstimate", new[] { typeof(double) })!,
            
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.ReciprocalEstimate), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.ReciprocalEstimate), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("ReciprocalSqrtEstimate", new[] { typeof(double) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.ReciprocalSqrtEstimate), new[] { typeof(double) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.ReciprocalSqrtEstimate), new[] { typeof(double) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Round", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Round", new[] { typeof(double), typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double), typeof(int) })!
        },
        {
            typeof(double).GetRuntimeMethod("Round", new[] { typeof(double), typeof(int), typeof(MidpointRounding) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double), typeof(int), typeof(MidpointRounding) })!
        },
        {
            typeof(double).GetRuntimeMethod("Round", new[] { typeof(double), typeof(MidpointRounding) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double), typeof(MidpointRounding) })!
        },
        {
            typeof(double).GetRuntimeMethod("ScaleB", new[] { typeof(double), typeof(int) })!,
#if NETSTANDARD2_1
            typeof(MissingMath).GetRuntimeMethod(nameof(MissingMath.ScaleB), new[] { typeof(double), typeof(int) })!
#else
            typeof(Math).GetRuntimeMethod(nameof(Math.ScaleB), new[] { typeof(double), typeof(int) })!
#endif
        },
        {
            typeof(double).GetRuntimeMethod("Sign", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Sin", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sin), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Sinh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sinh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Sqrt", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sqrt), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Tan", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Tan), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Tanh", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Tanh), new[] { typeof(double) })!
        },
        {
            typeof(double).GetRuntimeMethod("Truncate", new[] { typeof(double) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), new[] { typeof(double) })!
        },
        {
            typeof(float).GetRuntimeMethod("Abs", new[] { typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Acos", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Acos), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Acosh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Acosh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Asin", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Asin), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Asinh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Asinh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Atan", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Atan2", new[] { typeof(float), typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan2), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Atanh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Atanh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("BitDecrement", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.BitDecrement), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.BitDecrement), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("BitIncrement", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.BitIncrement), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.BitIncrement), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Cbrt", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Cbrt), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Ceiling", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Ceiling), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Clamp", new[] { typeof(float), typeof(float), typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(float), typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("CopySign", new[] { typeof(float), typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.CopySign), new[] { typeof(float), typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.CopySign), new[] { typeof(float), typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Cos", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Cos), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Cosh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Cosh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Exp", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Exp), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Floor", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Floor), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("FusedMultiplyAdd", new[] { typeof(float), typeof(float), typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.FusedMultiplyAdd), new[] { typeof(float), typeof(float), typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.FusedMultiplyAdd), new[] { typeof(float), typeof(float), typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Ieee754Remainder", new[] { typeof(float), typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.IEEERemainder), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("ILogB", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.ILogB), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.ILogB), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Log", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Log), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Log", new[] { typeof(float), typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Log), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Log10", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Log10), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Log2", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.Log2), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Log2), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Max", new[] { typeof(float), typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("MaxMagnitude", new[] { typeof(float), typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.MaxMagnitude), new[] { typeof(float), typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.MaxMagnitude), new[] { typeof(float), typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Min", new[] { typeof(float), typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("MinMagnitude", new[] { typeof(float), typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.MinMagnitude), new[] { typeof(float), typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.MinMagnitude), new[] { typeof(float), typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Pow", new[] { typeof(float), typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Pow), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("ReciprocalEstimate", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.ReciprocalEstimate), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.ReciprocalEstimate), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("ReciprocalSqrtEstimate", new[] { typeof(float) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.ReciprocalSqrtEstimate), new[] { typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.ReciprocalSqrtEstimate), new[] { typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Round", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Round", new[] { typeof(float), typeof(int) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), new[] { typeof(float), typeof(int) })!
        },
        {
            typeof(float).GetRuntimeMethod("Round", new[] { typeof(float), typeof(int), typeof(MidpointRounding) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), new[] { typeof(float), typeof(int), typeof(MidpointRounding) })!
        },
        {
            typeof(float).GetRuntimeMethod("Round", new[] { typeof(float), typeof(MidpointRounding) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), new[] { typeof(float), typeof(MidpointRounding) })!
        },
        {
            typeof(float).GetRuntimeMethod("ScaleB", new[] { typeof(float), typeof(int) })!,
#if NETSTANDARD2_1
            typeof(MissingMathF).GetRuntimeMethod(nameof(MissingMathF.ScaleB), new[] { typeof(float), typeof(float) })!
#else
            typeof(MathF).GetRuntimeMethod(nameof(MathF.ScaleB), new[] { typeof(float), typeof(float) })!
#endif
        },
        {
            typeof(float).GetRuntimeMethod("Sign", new[] { typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Sin", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Sin), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Sinh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Sinh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Sqrt", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Sqrt), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Tan", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Tan), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Tanh", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Tanh), new[] { typeof(float) })!
        },
        {
            typeof(float).GetRuntimeMethod("Truncate", new[] { typeof(float) })!,
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Truncate), new[] { typeof(float) })!
        },
        {
            typeof(int).GetRuntimeMethod("Abs", new[] { typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(int) })!
        },
        {
            typeof(int).GetRuntimeMethod("Clamp", new[] { typeof(int), typeof(int), typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(int), typeof(int), typeof(int) })!
        },
        {
            typeof(int).GetRuntimeMethod("Max", new[] { typeof(int), typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(int), typeof(int) })!
        },
        {
            typeof(int).GetRuntimeMethod("Min", new[] { typeof(int), typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(int), typeof(int) })!
        },
        {
            typeof(int).GetRuntimeMethod("Sign", new[] { typeof(int) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(int) })!
        },
        {
            typeof(long).GetRuntimeMethod("Abs", new[] { typeof(long) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(long) })!
        },
        {
            typeof(long).GetRuntimeMethod("Clamp", new[] { typeof(long), typeof(long), typeof(long) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(long), typeof(long), typeof(long) })!
        },
        {
            typeof(long).GetRuntimeMethod("Max", new[] { typeof(long), typeof(long) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(long), typeof(long) })!
        },
        {
            typeof(long).GetRuntimeMethod("Min", new[] { typeof(long), typeof(long) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(long), typeof(long) })!
        },
        {
            typeof(long).GetRuntimeMethod("Sign", new[] { typeof(long) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(long) })!
        },
        {
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Abs), new[] { typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(float) })!
        },
        {
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Max), new[] { typeof(float), typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Min), new[] { typeof(float), typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(float), typeof(float) })!
        },
        {
            typeof(MathF).GetRuntimeMethod(nameof(MathF.Sign), new[] { typeof(float) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(float) })!
        },
        {
            typeof(sbyte).GetRuntimeMethod("Abs", new[] { typeof(sbyte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(sbyte) })!
        },
        {
            typeof(sbyte).GetRuntimeMethod("Clamp", new[] { typeof(sbyte), typeof(sbyte), typeof(sbyte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(sbyte), typeof(sbyte), typeof(sbyte) })!
        },
        {
            typeof(sbyte).GetRuntimeMethod("Max", new[] { typeof(sbyte), typeof(sbyte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(sbyte), typeof(sbyte) })!
        },
        {
            typeof(sbyte).GetRuntimeMethod("Min", new[] { typeof(sbyte), typeof(sbyte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(sbyte), typeof(sbyte) })!
        },
        {
            typeof(sbyte).GetRuntimeMethod("Sign", new[] { typeof(sbyte) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(sbyte) })!
        },
        {
            typeof(short).GetRuntimeMethod("Abs", new[] { typeof(short) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(short) })!
        },
        {
            typeof(short).GetRuntimeMethod("Clamp", new[] { typeof(short), typeof(short), typeof(short) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(short), typeof(short), typeof(short) })!
        },
        {
            typeof(short).GetRuntimeMethod("Max", new[] { typeof(short), typeof(short) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(short), typeof(short) })!
        },
        {
            typeof(short).GetRuntimeMethod("Min", new[] { typeof(short), typeof(short) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(short), typeof(short) })!
        },
        {
            typeof(short).GetRuntimeMethod("Sign", new[] { typeof(short) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(short) })!
        },
        {
            typeof(uint).GetRuntimeMethod("Clamp", new[] { typeof(uint), typeof(uint), typeof(uint) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(uint), typeof(uint), typeof(uint) })!
        },
        {
            typeof(uint).GetRuntimeMethod("Max", new[] { typeof(uint), typeof(uint) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(uint), typeof(uint) })!
        },
        {
            typeof(uint).GetRuntimeMethod("Min", new[] { typeof(uint), typeof(uint) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(uint), typeof(uint) })!
        },
        {
            typeof(ulong).GetRuntimeMethod("Clamp", new[] { typeof(ulong), typeof(ulong), typeof(ulong) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(ulong), typeof(ulong), typeof(ulong) })!
        },
        {
            typeof(ulong).GetRuntimeMethod("Max", new[] { typeof(ulong), typeof(ulong) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(ulong), typeof(ulong) })!
        },
        {
            typeof(ulong).GetRuntimeMethod("Min", new[] { typeof(ulong), typeof(ulong) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(ulong), typeof(ulong) })!
        },
        {
            typeof(ushort).GetRuntimeMethod("Clamp", new[] { typeof(ushort), typeof(ushort), typeof(ushort) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Clamp), new[] { typeof(ushort), typeof(ushort), typeof(ushort) })!
        },
        {
            typeof(ushort).GetRuntimeMethod("Max", new[] { typeof(ushort), typeof(ushort) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(ushort), typeof(ushort) })!
        },
        {
            typeof(ushort).GetRuntimeMethod("Min", new[] { typeof(ushort), typeof(ushort) })!,
            typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(ushort), typeof(ushort) })!
        }
    };

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        => _forwardedMethods.TryGetValue(methodCallExpression.Method, out var destinationMethod)
            ? VisitMethodCall(Expression.Call(destinationMethod, methodCallExpression.Arguments))
            : base.VisitMethodCall(methodCallExpression);
}
