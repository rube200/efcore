// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NETSTANDARD2_1

using System.Runtime.Serialization;

namespace System.Diagnostics
{
#pragma warning disable CS1591 // Missing XML comment
    public class UnreachableException : ArgumentException
    {
        public UnreachableException()
        {
        }

        public UnreachableException(string? message) : base(message)
        {
        }

        public UnreachableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UnreachableException(string? message, string? paramName) : base(message, paramName)
        {
        }

        public UnreachableException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
        {
        }

        protected UnreachableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
#pragma warning restore CS1591 // Missing XML comment
}
#endif
