using Amazon.Lambda.Core;
using Amazon.Lambda;
using Microsoft.VisualBasic;
using Amazon.Lambda.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace listLambdas;

public class GenerateLambdaList
{

    public async Task<List<FunctionConfiguration>> ListOfAllLambdaFunctions()
    {
        var lambdaClient = new AmazonLambdaClient();
        var listOfLambdas = new List<FunctionConfiguration>();

        var functionPaginator = lambdaClient.Paginators.ListFunctions(new ListFunctionsRequest());
        
        await foreach(var function in functionPaginator.Functions)
        {
            Console.WriteLine($"Function Name: {function.FunctionName} - Function Runtime: {function.Runtime}");
            listOfLambdas.Add(function);
        }
        return listOfLambdas;
    }
}
