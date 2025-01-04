using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace TestContainersMongoDB;

public class MongoFixture : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer = new MongoDbBuilder().WithReplicaSet().Build();    
    public Task InitializeAsync() => _mongoDbContainer.StartAsync();
    public Task DisposeAsync() => _mongoDbContainer.DisposeAsync().AsTask();
    public MongoClient GetMongoClient()
    {
        var connectionString = _mongoDbContainer.GetConnectionString();
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.DirectConnection = true;
        return new MongoClient(settings);
    }
}
