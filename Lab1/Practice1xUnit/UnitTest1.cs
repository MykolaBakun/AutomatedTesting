using System;
using Xunit;
using Microsoft.VisualBasic.FileIO;
using FluentAssertions;
using App;

namespace Practice1xUnit
{
    public class UnitTest1
    {
        public class DataDriven
        {
            [Theory]
            [MemberData(nameof(TestData))]
            public void Test (double Number, double Exp)
            {
                double Result = Program.Formula(Number);
                Assert.Equal(Exp, Result);
            }
            public static System.Collections.Generic.IEnumerable<object[]> TestData()
            {

                yield return new object[] { 5, 1 };
                yield return new object[] { -7, -3 };

            }
        }

        public class DataDrivenCSV
        {
            [Theory]
            [MemberData(nameof(TestData))]
            public void Test(double Number, double Exp)
            {
                double Result = Program.Formula(Number);
                Assert.Equal(Exp, Result);
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

        public class DataDrivenRandom
        {
            [Theory]
            [MemberData(nameof(TestData))]
            public void Test(double Number)
            {
                double Result = Program.Formula(Number);
                Assert.True(Result > 0);
            }
            public static System.Collections.Generic.IEnumerable<object[]> TestData()
            {
                var rand = new Random(73247823);
                var n = 10;

                for (int i = 0; i < n+1; i++) {
                    yield return new object[] { rand.Next(50, 100) };
                }

            }
        }

        public class TestReloadAndTimeOut
        {
            [Theory]
            [InlineData(-7, -3)]
            public void Test(double Number, double Ex)
            {
                double Result = Program.Formula(Number);
                Assert.Equal(Ex, Result);
            }
        }
    }
 
}
