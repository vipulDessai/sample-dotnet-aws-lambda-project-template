using MongoDB.Driver;

namespace sample_dotnet_aws_lambda_project_template.services
{
    public class MongoDbServer
    {
        public MongoClient client;

        public MongoDbServer()
        {
            var mongoClientSettings = MongoClientSettings.FromConnectionString(
                $"{Environment.GetEnvironmentVariable("MONGODB_URI")}"
            );
            mongoClientSettings.ServerApi = new ServerApi(ServerApiVersion.V1, strict: true);
            client = new MongoClient(mongoClientSettings);
        }
    }
}
