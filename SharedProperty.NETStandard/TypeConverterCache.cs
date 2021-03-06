﻿using SharedProperty.NETStandard.TypeConverters;
using System;
using System.Collections;

namespace SharedProperty.NETStandard
{
    public static class TypeConverterCache
    {
        internal static readonly Hashtable TypeConverters = new Hashtable {
            { typeof(double), new DoubleTypeConverter() },
            { typeof(decimal), new DecimalTypeConverter() },
            { typeof(float), new FloatTypeConverter() },
            { typeof(long), new LongTypeConverter() },
            { typeof(ulong), new UnsignedLongTypeConverter() },
            { typeof(int), new IntTypeConverter() },
            { typeof(uint), new UnsignedIntTypeConverter() },
            { typeof(short), new ShortTypeConverter() },
            { typeof(ushort), new UnsignedShortTypeConverter() }
        };
    }

    public static class TypeConverterCache<T>
    {
        public static ITypeConverter TypeConverter { get; }

        static TypeConverterCache()
        {
            TypeConverter = toTypeConverter(typeof(T));
        }

        private static ITypeConverter toTypeConverter(Type type)
        {
            return (ITypeConverter)TypeConverterCache.TypeConverters[type];
        }
    }
}
