using System;

namespace Open.Aids {

    public static class GetRandom {

        private static readonly Random r = new Random();

        public static double Double(double min = double.MinValue, double max = double.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            toTheSequenceOfGrowing(ref min, ref max);
            var d = r.NextDouble();
            if (max > 0) return min + d * max - d * min;
            return min - d * min + d * max;
        }

        private static void toTheSequenceOfGrowing(ref double min, ref double max) {
            if (min <= max) return;
            var d = min;
            min = max;
            max = d;
        }

        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) {
            return (sbyte) Int32(min, max);
        }

        public static short Int16(short min = short.MinValue, short max = short.MaxValue) {
            return Convert.ToInt16(Double(min, max));
        }

        public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            if (min.CompareTo(max) <= 0) return r.Next(min, max);
            return r.Next(max, min);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
            return Convert.ToInt64(Double(min, max));
        }

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue) {
            return Convert.ToByte(Double(min, max));
        }

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue) {
            return Convert.ToUInt16(Double(min, max));
        }

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue) {
            return Convert.ToUInt32(Double(min, max));
        }

        public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) {
            return Convert.ToUInt64(Double(min, max));
        }

        public static float Float(float min = float.MinValue, float max = float.MaxValue) {
            return Convert.ToSingle(Double(min, max));
        }
    }
}