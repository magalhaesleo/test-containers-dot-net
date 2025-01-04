namespace TestContainersMongoDB;

[CollectionDefinition(nameof(MongoCollection))]
public class MongoCollection : ICollectionFixture<MongoFixture>
{
}
