using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AnonymousIncomeComparisonTool.Tests
{
    [TestFixture]
    class PassingTests
    {
        [Test]
        public void Test1()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("5\n10\n15\n20"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    Program.Main();

                    var result = sw.ToString().Trim();
                    var arr = result.Split('\n', '\r').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    Assert.IsTrue(arr[0].Trim() == "Anonymous Income Comparison Program", "Your Header is wrong.");
                    Assert.IsTrue(arr[1].Trim() == "Person 1", "It is supposed to exactly say 'Person 1' on the line.");
                    Assert.IsTrue(arr[2].Trim() == "Hourly Rate?", "It is supposed to exactly say 'Hourly Rate?'");
                    Assert.IsTrue(arr[3].Trim() == "Hours worked per week?", "It is supposed to exactly say 'Hours worked per week?'");
                    Assert.IsTrue(arr[4].Trim() == "Person 2", "It is supposed to exactly say 'Person 1' on the line.");
                    Assert.IsTrue(arr[5].Trim() == "Hourly Rate?", "It is supposed to exactly say 'Hourly Rate?'");
                    Assert.IsTrue(arr[6].Trim() == "Hours worked per week?", "It is supposed to exactly say 'Hours worked per week?'");
                    Assert.IsTrue(arr[7].Trim() == "Does Person 1 make more money than Person 2?", "Error on line asking which person makes more money.");
                    Assert.IsTrue(arr[8].Trim() == "False", "Person 1 doesn't make more money than person 2.");
                }
            }
        }
    }
}
