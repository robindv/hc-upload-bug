var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<UploadType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();

public record TestMutationInput(
    [property: GraphQLType(typeof(NonNullType<UploadType>))]
    IFile File
);
public class Mutation
{
    public async Task<int> TestMutation(TestMutationInput input)
    {
        await using Stream stream = input.File.OpenReadStream();
        var reader = new StreamReader(stream);
        var lines = 0;
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            Console.WriteLine(line);
            lines++;
        }
        
        return lines;
    }
}

public class Query
{
    public int TestQuery() => 3;
}