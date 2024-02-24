﻿using Amazon.Lambda.APIGatewayEvents;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using sample_dotnet_aws_lambda_project_template.Models;
using sample_dotnet_aws_lambda_project_template.services;
using System.Net;
using System.Text.Json;

namespace sample_dotnet_aws_lambda_project_template;

public class Query
{
    public async Task<APIGatewayProxyResponse> GetRestuarants(
        [GlobalState("currentUser")] CurrentUser user,
        GetRestuarantsInput input
    )
    {
        var dbServer = new MongoDbServer();
        var db = dbServer.client.GetDatabase("sample_restaurants");
        var _restaurantsCollection = db.GetCollection<Restaurant>("restaurants");
        var filter = Builders<Restaurant>.Filter.Eq(input.FilterKey, input.FilterValue);
        var findOptions = new FindOptions { BatchSize = input.BatchSize };

        var res = new List<string>();
        using (var cursor = _restaurantsCollection.Find(filter, findOptions).ToCursor())
        {
            if (cursor.MoveNext())
            {
                var d = cursor.Current.ToList();

                for (int i = 0; i < d.Count; i++)
                {
                    res.Add(d[i].Name);
                }
            }
        }

        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = JsonSerializer.Serialize(res.ToArray()),
            Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        };

        return response;
    }

    public string Unauthorized()
    {
        return "unauthorized";
    }

    [Authorize(Policy = "hr")]
    public List<string> Authorized([Service] IHttpContextAccessor contextAccessor)
    {
        var res = contextAccessor
            .HttpContext.User.Claims.Select(x => $"{x.Type} : {x.Value}")
            .ToList();

        return res;
    }

    [Authorize(Policy = "hr")]
    public List<string> AuthorizedBetterWay([GlobalState("currentUser")] CurrentUser user)
    {
        return user.Claims;
    }

    [Authorize(Roles = new[] { "leader" })]
    public List<string> AuthorizedLeader([GlobalState("currentUser")] CurrentUser user)
    {
        return user.Claims;
    }

    [Authorize(Roles = new[] { "dev" })]
    public List<string> AuthorizedDev([GlobalState("currentUser")] CurrentUser user)
    {
        return user.Claims;
    }

    [Authorize(Policy = "DevDepartment")]
    public List<string> AuthorizedDevDepartment([GlobalState("currentUser")] CurrentUser user)
    {
        return user.Claims;
    }

    public Task<List<Book>> GetBooks([Service] Repository repository) => repository.GetBooksAsync();

    public Task<Author?> GetAuthor(GetAuthorInput input, [Service] Repository r) =>
        r.GetAuthor(input.authorId);
}
