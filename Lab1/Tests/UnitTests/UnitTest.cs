namespace UnitTests;
using Lab1;
[TestClass]
public class UnitTest
{
    private List<Item> _testItems = new List<Item>([
            new Item { Id = 0, Value = 10, Weight = 1 }, // 10
            new Item { Id = 1, Value = 10, Weight = 5 }, // 2
            new Item { Id = 2, Value = 10, Weight = 10 }, // 1
            new Item { Id = 3, Value = 10, Weight = 99 },
        ]
    );
    [TestMethod]
    public void TestMethodAnyItem()
    {
        Problem problem = new Problem(_testItems);
        Assert.AreEqual(problem.Solve(3).SumValue, 10);
    }

    [TestMethod]
    public void TestMethodEmptySolution()
    {
        Problem problem = new Problem(_testItems);
        Assert.AreEqual(problem.Solve(0).SumValue, 0);
    }

    [TestMethod]
    public void TestMethodFullCheck()
    {
        Problem problem = new Problem(_testItems);
        Result result = problem.Solve(100);
        Assert.AreEqual(result.SumValue, 30);
        Assert.AreEqual(result.SumWeight, 16);
    }

    [TestMethod]
    public void TestMethodOverweight()
    {
        Problem problem = new Problem(_testItems);
        Result result = problem.Solve(100);
        Assert.IsTrue(result.SumWeight < 100 );
    }

    [TestMethod]
    public void TestMethodNullList()
    {
        Problem problem = new Problem([]);
        Result result = problem.Solve(100);
        Assert.IsFalse(result.Backpack.Count != 0);
    }
}