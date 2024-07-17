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
        int numberCount = 1;
        await foreach(var function in functionPaginator.Functions)
        {
            numberCount++;
            Console.WriteLine($"Function Name: {function.FunctionName}.");
            Console.WriteLine($"Function Description: {function.Description}");
            Console.WriteLine($"Function AWSARN:{function.FunctionArn}");
            Console.WriteLine($"Function Handler:{function.Handler}");
            Console.WriteLine($"Function Runtime: {function.Runtime}");
            Console.WriteLine($"Function Last Modified On: {function.LastModified}");
            Console.WriteLine($"Function Layers: {function.Layers}");
            Console.WriteLine($"Function Role: {function.Role}");
            Console.WriteLine(numberCount);
            listOfLambdas.Add(function);
        }
        Console.WriteLine(listOfLambdas.Count);
        return listOfLambdas;
    }
}
