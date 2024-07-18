using Amazon.Lambda.Core;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using listLambdas.Models;
using Microsoft.VisualBasic;

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
            Console.WriteLine($"Function Name: {function.FunctionName}");
            Console.WriteLine($"Function ARN: {function.FunctionArn}");
            Console.WriteLine($"Function Description: {function.Description}");
            Console.WriteLine($"Function Runtime: {function.Runtime}");
            Console.WriteLine($"Function Last Execute: ");
            Console.WriteLine($"Function Logging Enabled: {function.LoggingConfig.ApplicationLogLevel}");
            Console.WriteLine($"Function Region: ");
            Console.WriteLine($"Function Memory size: {function.MemorySize}");
            Console.WriteLine($"Function Timeout: {function.Timeout}");
            Console.WriteLine($"Function Environment Variables: {function.Environment.Variables}");
            Console.WriteLine($"Function Hander: {function.Handler}");
            Console.WriteLine($"Function StackName: ");
            Console.WriteLine($"Function Triggers: ");
            listOfLambdas.Add(function);
        }
        return listOfLambdas;
    }
}
