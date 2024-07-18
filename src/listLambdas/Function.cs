using Amazon.Lambda.Core;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace listLambdas;

public class GenerateLambdaList
{

    public async Task<List<FunctionConfiguration>> ListOfAllLambdaFunctions()
    {
        var lambdaClient = new AmazonLambdaClient();
        var listOfLambdas = new List<FunctionConfiguration>();
        //Excel Library
        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("First Sheet");
        try {
            using (FileStream stream = new FileStream("outfile.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        } 
        catch (IOException exception)
        {
            Console.WriteLine($"Exception - {exception}");
        }

        var functionPaginator = lambdaClient.Paginators.ListFunctions(new ListFunctionsRequest());

        await foreach(var function in functionPaginator.Functions)
        {
            Console.WriteLine($"Function Name: {function.FunctionName}");
            Console.WriteLine($"Function ARN: {function.FunctionArn}");
            Console.WriteLine($"Function Description: {function.Description}");
            Console.WriteLine($"Function Runtime: {function.Runtime}");
            Console.WriteLine($"Function Last Execute: ");
            Console.WriteLine($"Function Logging Enabled: {function.LoggingConfig.LogGroup}");
            Console.WriteLine($"Function Region: ");
            Console.WriteLine($"Function Memory size: {function.MemorySize}");
            Console.WriteLine($"Function Timeout: {function.Timeout}");
            Console.WriteLine($"Function Environment Variables: ");
            Console.WriteLine($"Function Hander: {function.Handler}");
            Console.WriteLine($"Function StackName: ");
            Console.WriteLine($"Function Triggers: ");
            listOfLambdas.Add(function);
        }
        return listOfLambdas;
    }
}
