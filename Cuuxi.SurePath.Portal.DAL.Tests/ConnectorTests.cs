using Cuuxi.SurePath.Portal.DAL;

namespace Cuuxi.SurePath.Portal.DAL.Tests;

public class ConnectorTests : IDisposable
{
    private readonly Connector _connector;

    public ConnectorTests()
    {
        _connector = new Connector(new Settings());
    }

    [Fact]
    public void TestRepository_Test_Executes()
    {
        _connector.Test.Test();
    }

    public void Dispose()
    {
        _connector.Dispose();
    }
}
