﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualBasic.FileIO;
using FluentAssertions;

namespace Practice1MsTest
{
    [TestClass]
    public class DataDriveCSV
    {

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void Test(double Number, double Ex)
        {
            double Result = App.Program.Formula(Number);
            Assert.AreEqual(Ex, Result);
        }

        public static System.Collections.Generic.IEnumerable<object[]> TestData()
        {
            var path = @"‪C:\Users\volod\Desktop\Data.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    double Number = Convert.ToDouble(fields[0].Replace('.', ','));
                    double Exp = Convert.ToDouble(fields[1].Replace('.', ','));
                    yield return new object[] { Number, Exp };
                }
            }
        }
    }

    [TestClass]
    public class DataDrivenRandom
    {

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void Test(double Number)
        {
            double Result = App.Program.Formula(Number);
            Assert.IsTrue(Result > 0);
        }
        private static System.Collections.Generic.IEnumerable<object[]> TestData()
        {
            var rand = new Random(73247823);

            var n = 10;

            for (int i = 0; i < n + 1; i++)
            {
                yield return new object[] { rand.Next(50, 100) };
            }

        }
    }

    [TestClass]
    public class DataDriven
    {

        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void Test(double Number, double Exp)
        {
            double Result = App.Program.Formula(Number);
            Assert.AreEqual(Exp, Result);
        }
        private static System.Collections.Generic.IEnumerable<object[]> TestData()
        {

            yield return new object[] { 5, 1 };
            yield return new object[] { -1, 3 };

        }

    }

    [TestClass]
    public class TestReloadAndTimeOut
    {
        [TestMethod]
        [Timeout(100)]
        [DataRow(5, 1)]
        public void Test
        (double Number, double Exp)
        {
            double Result = App.Program.Formula(Number);
            Assert.AreEqual(Exp, Result);
        }
    }
}
