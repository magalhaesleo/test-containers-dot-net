using MongoDB.Driver;

namespace TestContainersMongoDB;

[Collection(nameof(MongoCollection))]
public class MongoTests(MongoFixture mongoFixture)
{
    [Fact]
    public async Task Given_mongo_client_should_validate_its_databases()
    {
        // Given
        using var client = mongoFixture.GetMongoClient();

        // When
        using var cursor = await client.ListDatabaseNamesAsync();
        var databases = await cursor.ToListAsync();

        // Then
        Assert.NotEmpty(databases);
    }
}