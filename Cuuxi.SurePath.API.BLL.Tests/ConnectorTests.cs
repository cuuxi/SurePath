using Cuuxi.SurePath.API.BLL;

namespace Cuuxi.SurePath.API.BLL.Tests;

public class ConnectorTests : IDisposable
{
    private readonly Connector _connector;

    public ConnectorTests()
    {
        _connector = new Connector(new Settings());
    }

    [Fact]
    public void TestService_Test_Executes()
    {
        _connector.Test.Test();
    }

    public void Dispose()
    {
        _connector.Dispose();
    }
}
