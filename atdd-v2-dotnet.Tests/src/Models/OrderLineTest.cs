using System;
using atdd_v2_dotnet.Models;
using NUnit.Framework;

namespace atdd_v2_dotnet.Tests.Models;

[TestFixture]
[TestOf(typeof(OrderLine))]
public class OrderLineTest
{

    [Test]
    public void quantity_should_not_equal_0()
    {
        var orderLine = new OrderLine();

        Assert.Throws<ArgumentException>(() => orderLine.Quantity = 0);
    }

    [Test]
    public void quantity_should_not_less_than_0()
    {
        var orderLine = new OrderLine();

        Assert.Throws<ArgumentException>(() => orderLine.Quantity = -1);
    }
}