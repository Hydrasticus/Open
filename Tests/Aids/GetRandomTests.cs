using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids {

    [TestClass]
    public class GetRandomTests : BaseTests {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetRandom);
        }

        private static void doGetRandomTests<T>(Func<T, T, T> funct, T min, T max) where T : IComparable {
            doTests(funct, min);
            doTests(funct, max);
            doTests(funct, min, max);
            doTests((x, y) => funct(max, min), min, max);
        }

        private static void doTests<T>(Func<T, T, T> funct, T min, T max) where T : IComparable {
            var l = new List<T>();
            for (var i = 0; i < 10; i++) {
                T r;
                do { r = funct(min, max); } while (l.Contains(r));
                Assert.IsInstanceOfType(r, typeof(T));
                Assert.IsTrue(r.CompareTo(min) >= 0);
                Assert.IsTrue(r.CompareTo(max) <= 0);
                l.Add(r);
            }
        }

        private static void doTests<T>(Func<T, T, T> funct, T x) {
            Assert.AreEqual(x, funct(x, x));
        }

        [TestMethod]
        public void DoubleTest() {
            var d = 10000;
            doGetRandomTests(GetRandom.Double, (double)10, 110);
            doGetRandomTests(GetRandom.Double, (double)-110, -10);
            doGetRandomTests(GetRandom.Double, (double)-50, 50);
            doGetRandomTests(GetRandom.Double, double.MinValue, double.MaxValue);
            doGetRandomTests(GetRandom.Double, double.MaxValue / d, double.MaxValue);
            doGetRandomTests(GetRandom.Double, double.MinValue, double.MinValue / d);
        }

        [TestMethod]
        public void FloatTest() {
            var d = 10F;
            doGetRandomTests(GetRandom.Float, 10F, 110F);
            doGetRandomTests(GetRandom.Float, -110F, -10F);
            doGetRandomTests(GetRandom.Float, -50F, 50F);
            doGetRandomTests(GetRandom.Float, float.MinValue, float.MaxValue);
            doGetRandomTests(GetRandom.Float, float.MaxValue / d, float.MaxValue);
            doGetRandomTests(GetRandom.Float, float.MinValue, float.MinValue / d);
        }

        [TestMethod]
        public void Int8Test() {
            doGetRandomTests(GetRandom.Int8, (sbyte)10, (sbyte)110);
            doGetRandomTests(GetRandom.Int8, (sbyte)-110, (sbyte)-10);
            doGetRandomTests(GetRandom.Int8, (sbyte)-50, (sbyte)50);
            doGetRandomTests(GetRandom.Int8, sbyte.MinValue, (sbyte)(sbyte.MinValue + 100));
            doGetRandomTests(GetRandom.Int8, (sbyte)(sbyte.MaxValue - 100), sbyte.MaxValue);
            doGetRandomTests(GetRandom.Int8, sbyte.MinValue, sbyte.MaxValue);
        }

        [TestMethod]
        public void Int16Test() {
            doGetRandomTests(GetRandom.Int16, (short)100, (short)200);
            doGetRandomTests(GetRandom.Int16, short.MinValue, (short)(short.MinValue + 200));
            doGetRandomTests(GetRandom.Int16, (short)(short.MaxValue - 100), short.MaxValue);
            doGetRandomTests(GetRandom.Int16, short.MinValue, short.MaxValue);
        }

        [TestMethod]
        public void Int32Test() {
            doGetRandomTests(GetRandom.Int32, 100, 200);
            doGetRandomTests(GetRandom.Int32, -200, 100);
            doGetRandomTests(GetRandom.Int32, -400, -200);
            doGetRandomTests(GetRandom.Int32, int.MinValue, int.MinValue + 200);
            doGetRandomTests(GetRandom.Int32, int.MaxValue - 100, int.MaxValue);
            doGetRandomTests(GetRandom.Int32, int.MinValue, int.MaxValue);
        }

        [TestMethod]
        public void Int64Test() { //TODO: fix Int64Test
            doGetRandomTests(GetRandom.Int64, (long)100, (long)200);
            doGetRandomTests(GetRandom.Int64, (long)-200, (long)100);
            doGetRandomTests(GetRandom.Int64, (long)-400, (long)-200);
            //doGetRandomTests(GetRandom.Int64, long.MinValue, long.MinValue + 200);
            //doGetRandomTests(GetRandom.Int64, long.MaxValue - 100, long.MaxValue);
            //doGetRandomTests(GetRandom.Int64, long.MinValue, long.MaxValue);
        }

        [TestMethod]
        public void UInt8Test() {
            doGetRandomTests(GetRandom.UInt8, (byte)100, (byte)200);
            doGetRandomTests(GetRandom.UInt8, byte.MinValue, (byte)(byte.MinValue + 200));
            doGetRandomTests(GetRandom.UInt8, (byte)(byte.MaxValue - 100), byte.MaxValue);
            doGetRandomTests(GetRandom.UInt8, byte.MinValue, byte.MaxValue);
        }

        [TestMethod]
        public void UInt16Test() {
            doGetRandomTests(GetRandom.UInt16, (ushort)100, (ushort)200);
            doGetRandomTests(GetRandom.UInt16, ushort.MinValue, (ushort)(ushort.MinValue + 200));
            doGetRandomTests(GetRandom.UInt16, (ushort)(ushort.MaxValue - 100), ushort.MaxValue);
            doGetRandomTests(GetRandom.UInt16, ushort.MinValue, ushort.MaxValue);
        }

        [TestMethod]
        public void UInt32Test() {
            doGetRandomTests(GetRandom.UInt32, (uint)100, (uint)200);
            doGetRandomTests(GetRandom.UInt32, uint.MinValue, uint.MinValue + 200);
            doGetRandomTests(GetRandom.UInt32, uint.MaxValue - 100, uint.MaxValue);
            doGetRandomTests(GetRandom.UInt32, uint.MinValue, uint.MaxValue);
        }

        [TestMethod]
        public void UInt64Test() { //TODO: fix UInt64Test
            doGetRandomTests(GetRandom.UInt64, (ulong)100, (ulong)200);
            doGetRandomTests(GetRandom.UInt64, ulong.MinValue, ulong.MinValue + 200);
            //doGetRandomTests(GetRandom.UInt64, ulong.MaxValue - 100, ulong.MaxValue);
            //doGetRandomTests(GetRandom.UInt64, ulong.MinValue, ulong.MaxValue);
        }
    }
}