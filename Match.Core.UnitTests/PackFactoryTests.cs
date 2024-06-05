using NUnit.Framework.Interfaces;

namespace Match.Core.UnitTests;

public class Tests
{
    private PackFactory _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new PackFactory();
    }

    [Test]
    public void Test1()
    {
        var pack = _sut.CreatePack();

        foreach (var card in pack)
        {
            TestContext.Out.WriteLine(card);
        }
    }
}