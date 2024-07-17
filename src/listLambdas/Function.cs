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
        int numberCount = 1;
        await foreach(var function in functionPaginator.Functions)
        {
            var response = lambdaClient.GetFunctionAsync(new GetFunctionRequest
            {
                FunctionName = function.FunctionName
            });
            // Console.WriteLine($"Function Name: {function.FunctionName}. Function Name Data Type: {function.FunctionName.GetType()}");
            // Console.WriteLine($"Function Description: {function.Description}. Function Description Data Type: {function.FunctionName.GetType()}");
            // Console.WriteLine($"Function AWSARN:{function.FunctionArn}. Function ARN Data Type: {function.FunctionArn.GetType()}");
            // Console.WriteLine($"Function Handler:{function.Handler}. Function Handler Data Type: {function.Handler.GetType()}");
            // Console.WriteLine($"Function Runtime: {function.Runtime}. Function Runtime Data Type: {function.Runtime.GetType()}");
            // Console.WriteLine($"Function Last Modified On: {function.LastModified}. Function Last Modified Data Type: {function.LastModified.GetType()}");
            // Console.WriteLine($"Function Layers: {function.Layers}. Function Layers DataType: {function.LastModified.GetType()}");
            // Console.WriteLine($"Function Role: {function.Role}. Function Role Data Type: {function.Role.GetType()}");
            Console.WriteLine(response);
            listOfLambdas.Add(function);
        }
        return listOfLambdas;
    }
}
